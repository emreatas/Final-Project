using System.Collections.Generic;
using Player;
using UnityEngine;

namespace StateMachine
{
    public class FiniteStateMachine : MonoBehaviour
    {
        [SerializeField] private PlayerStates initialPlayerState;
        [SerializeField] private PlayerInputSystem inputSystem;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private PlayerMovementSettings movementSettings;

        public PlayerMovementSettings MovementSettings => movementSettings;
        public CharacterController CharacterController => characterController;
        public PlayerInputSystem InputSystem => inputSystem;
        
        
        private BaseState m_CurrentState;

        private Dictionary<PlayerStates, BaseState> m_StateDictionary;
        
        private void Awake()
        {
             m_StateDictionary = 
                new Dictionary<PlayerStates, BaseState>()
                {
                    { PlayerStates.Idle , new IdleState(this)},
                    { PlayerStates.Move , new MoveState(this)},
                    { PlayerStates.Attack , new AttackState(this)}
                };
        }

        private void Start()
        {
            SwitchState(initialPlayerState);
        }

        private void Update()
        {
            m_CurrentState?.OnUpdate();
        }
        
        public void SwitchState(PlayerStates newState)
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