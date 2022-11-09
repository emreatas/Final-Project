using UnityEngine;

namespace StateMachine
{
    public class MoveState : BaseState
    {
        public MoveState(FiniteStateMachine stateMachine) : base(stateMachine) { }

        public override void OnEnter()
        {
            Debug.Log("Enter Move");
            m_StateMachine.AnimationController.PlayWalkAnimation();
            m_StateMachine.IsPressingMove = true;
            AddListeners();
        }

        public override void OnExit()
        {
            Debug.Log("Exit Move");
            m_StateMachine.AnimationController.StopWalkAnimation();
            
            RemoveListeners();
        }
        
        private void HandleOnMovePerformed(Vector3 movementVector)
        {
            MovePlayer(movementVector);
            RotatePlayer(movementVector);
            // Debug.Log(movementVector.magnitude);
            m_StateMachine.AnimationController.SetSpeed(movementVector.magnitude);
        }

        private void HandleOnMoveCanceled(Vector3 movementVector)
        {
            m_StateMachine.SwitchState(PlayerStates.Idle);
            m_StateMachine.IsPressingMove = false;
        }
        
        private void HandleOnAttackStart()
        {
            m_StateMachine.SwitchState(PlayerStates.Attack);
        }
        
        private void HandleOnAttackStart(Vector3 vector)
        {
            m_StateMachine.SwitchState(PlayerStates.Attack);
        }
        
        private void MovePlayer(Vector3 movementVector)
        {
            m_StateMachine.Rigidbody.MovePosition(
                m_StateMachine.transform.position + 
                m_StateMachine.MovementSettings.MovementSpeed * 
                 Time.deltaTime * 
                movementVector 
                );
        }

        private void RotatePlayer(Vector3 movementVector)
        {
            Quaternion newRot = Quaternion.RotateTowards(
                m_StateMachine.Rigidbody.rotation, 
                Quaternion.LookRotation(movementVector,  m_StateMachine.transform.up), 
                m_StateMachine.MovementSettings.RotationSpeed * Time.deltaTime);
            
            m_StateMachine.Rigidbody.MoveRotation(newRot);
        }
        
        private void HandleOnSkillStarted(Vector3 vector)
        {
            m_StateMachine.SwitchState(PlayerStates.MoveAttack);
        }

        protected virtual void AddListeners()
        {
            m_StateMachine.InputSystem.OnMovePerformed.AddListener(HandleOnMovePerformed);
            m_StateMachine.InputSystem.OnMoveCanceled.AddListener(HandleOnMoveCanceled);
            
            m_StateMachine.InputSystem.OnBasicAttackStarted.AddListener(HandleOnAttackStart);
            m_StateMachine.InputSystem.OnBasicAttackPerformed.AddListener(HandleOnAttackStart);
            
            m_StateMachine.InputSystem.OnPrimarySkillStarted.AddListener(HandleOnSkillStarted);
            m_StateMachine.InputSystem.OnSecondarySkillStarted.AddListener(HandleOnSkillStarted);
        }

        protected virtual void RemoveListeners()
        {
            m_StateMachine.InputSystem.OnMovePerformed.RemoveListener(HandleOnMovePerformed);
            m_StateMachine.InputSystem.OnMoveCanceled.RemoveListener(HandleOnMoveCanceled);
            
            m_StateMachine.InputSystem.OnBasicAttackStarted.RemoveListener(HandleOnAttackStart);
            m_StateMachine.InputSystem.OnBasicAttackPerformed.RemoveListener(HandleOnAttackStart);
            
            m_StateMachine.InputSystem.OnPrimarySkillStarted.RemoveListener(HandleOnSkillStarted);
            m_StateMachine.InputSystem.OnSecondarySkillStarted.RemoveListener(HandleOnSkillStarted);
        }
    }
}