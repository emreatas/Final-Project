using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyStateMachine
{
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private EnemyStates initialEnemyState;

        private EnemyBaseState m_CurrentState;

        private Dictionary<EnemyStates, EnemyBaseState> m_StateDictionary;

        private void Awake()
        {
            m_StateDictionary =
               new Dictionary<EnemyStates, EnemyBaseState>()
               {
                    { EnemyStates.Idle , new EnemyIdle(this)},
                    { EnemyStates.Move , new EnemyMove(this)},
                    { EnemyStates.Attack , new EnemyAttack(this)}
               };
        }

        private void Start()
        {
            SwitchState(initialEnemyState);
        }

        private void Update()
        {
            m_CurrentState?.OnUpdate();
        }

        public void SwitchState(EnemyStates newState)
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
