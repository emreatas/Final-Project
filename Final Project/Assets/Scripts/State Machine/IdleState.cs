using UnityEngine;

namespace StateMachine
{
    public class IdleState : BaseState
    {
        public IdleState(FiniteStateMachine stateMachine) : base(stateMachine) { }

        public override void OnEnter()
        {
            Debug.Log("Play Idle Animation");
            m_StateMachine.AnimationController.PlayIdleAnimation();
            AddListeners();
        }

        public override void OnExit()
        {
            Debug.Log("Stop Idle Animation");
            m_StateMachine.AnimationController.StopIdleAnimation();
            RemoveListeners();
        }

        private void HandleOnMoveStarted()
        {
            m_StateMachine.SwitchState(PlayerStates.Move);
        }
        
        private void HandleOnMovePerformed(Vector3 movementVector)
        {
            m_StateMachine.SwitchState(PlayerStates.Move);
        }
        
        private void HandleOnAttackStart()
        {
            m_StateMachine.SwitchState(PlayerStates.Attack);
        }
        private void HandleOnAttackStart(Vector3 vector)
        {
            m_StateMachine.SwitchState(PlayerStates.Attack);
        }

        private void HandleOnSkillStarted(Vector3 vector)
        {
            m_StateMachine.SwitchState(PlayerStates.MoveAttack);
        }
        
        private void AddListeners()
        {
            m_StateMachine.InputSystem.OnMoveStarted.AddListener(HandleOnMoveStarted);
            m_StateMachine.InputSystem.OnMovePerformed.AddListener(HandleOnMovePerformed);
            
            m_StateMachine.InputSystem.OnBasicAttackStarted.AddListener(HandleOnAttackStart);
            m_StateMachine.InputSystem.OnBasicAttackPerformed.AddListener(HandleOnAttackStart);
            
            m_StateMachine.InputSystem.OnPrimarySkillStarted.AddListener(HandleOnSkillStarted);
            m_StateMachine.InputSystem.OnSecondarySkillStarted.AddListener(HandleOnSkillStarted);
        }

        private void RemoveListeners()
        {
            m_StateMachine.InputSystem.OnMoveStarted.RemoveListener(HandleOnMoveStarted);
            m_StateMachine.InputSystem.OnMovePerformed.RemoveListener(HandleOnMovePerformed);
            
            m_StateMachine.InputSystem.OnBasicAttackStarted.RemoveListener(HandleOnAttackStart);
            m_StateMachine.InputSystem.OnBasicAttackPerformed.RemoveListener(HandleOnAttackStart);
            
            m_StateMachine.InputSystem.OnPrimarySkillStarted.RemoveListener(HandleOnSkillStarted);
            m_StateMachine.InputSystem.OnSecondarySkillStarted.RemoveListener(HandleOnSkillStarted);
        }
    }
}