using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class FiniteStateMachine : MonoBehaviour
    {
        [SerializeField] private FSMStates initialFsmState;

        private BaseState m_CurrentState;

        private Dictionary<FSMStates, BaseState> m_StateDictionary;
        
        private void Awake()
        {
             m_StateDictionary = 
                new Dictionary<FSMStates, BaseState>()
                {
                    { FSMStates.Idle , new IdleState(this)},
                    { FSMStates.Move , new MoveState(this)},
                    { FSMStates.Attack , new AttackState(this)}
                };
        }

        private void Start()
        {
            SwitchState(initialFsmState);
        }

        private void Update()
        {
            m_CurrentState?.OnUpdate();
        }
        
        public void SwitchState(FSMStates newState)
        {
            OnStateExit();
            m_CurrentState = m_StateDictionary[newState];
            OnStateEnter();
        }

        private void OnStateEnter()
        {
            m_CurrentState?.OnEnter();
        }
        
        private void OnStateExit()
        {
            m_CurrentState?.OnExit();
        }
    }
}