using UnityEngine;

namespace StateMachine
{
    public class AttackState : BaseState
    {
        public AttackState(FiniteStateMachine stateMachine) : base(stateMachine) { }

        public override void OnEnter()
        {
            Debug.Log("Entered Attack State");
            AddListeners();
        }

        public override void OnExit()
        {
            RemoveListeners();
        }

        private void HandleOnBasicAttackStarted()
        {
            Debug.Log("Holaaaaaaaaaa");
        }
        
        private void AddListeners()
        {
            m_StateMachine.InputSystem.OnBasicAttackStarted.AddListener(HandleOnBasicAttackStarted);
        }

        private void RemoveListeners()
        {
            m_StateMachine.InputSystem.OnBasicAttackStarted.RemoveListener(HandleOnBasicAttackStarted);
        }
    }
}

