using UnityEngine;

namespace StateMachine
{
    public class IdleState : BaseState
    {
        public IdleState(FiniteStateMachine stateMachine) : base(stateMachine) { }

        public override void OnEnter()
        {
            Debug.Log("Play Idle Animation");
            AddListeners();
        }

        public override void OnExit()
        {
            Debug.Log("Stop Idle Animation");
            RemoveListeners();
        }

        private void HandleOnMoveStarted(Vector3 movementVector)
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
        
        private void AddListeners()
        {
            m_StateMachine.InputSystem.OnMoveStarted.AddListener(HandleOnMoveStarted);
            
            m_StateMachine.InputSystem.OnBasicAttackStarted.AddListener(HandleOnAttackStart);
            m_StateMachine.InputSystem.OnPrimarySkillStarted.AddListener(HandleOnAttackStart);
            m_StateMachine.InputSystem.OnSecondarySkillStarted.AddListener(HandleOnAttackStart);
        }

        private void RemoveListeners()
        {
            m_StateMachine.InputSystem.OnMoveStarted.RemoveListener(HandleOnMoveStarted);
            
            m_StateMachine.InputSystem.OnBasicAttackStarted.RemoveListener(HandleOnAttackStart);
            m_StateMachine.InputSystem.OnPrimarySkillStarted.RemoveListener(HandleOnAttackStart);
            m_StateMachine.InputSystem.OnSecondarySkillStarted.RemoveListener(HandleOnAttackStart);
        }
    }
}