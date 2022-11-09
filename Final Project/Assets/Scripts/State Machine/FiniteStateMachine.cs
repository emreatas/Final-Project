using System;
using System.Collections.Generic;
using Player;
using UnityEngine;
using MEC;

namespace StateMachine
{
    public class FiniteStateMachine : MonoBehaviour
    {
        [SerializeField] private PlayerStates initialPlayerState;
        [SerializeField] private PlayerInputSystem inputSystem;
        [SerializeField] private PlayerSkillController skillController;
        [SerializeField] private PlayerAnimationController animationController;
        [SerializeField] private PlayerMovementController movementController;
        
        public PlayerAnimationController AnimationController => animationController;
        public PlayerSkillController SkillController => skillController;
        public PlayerInputSystem InputSystem => inputSystem;
        public PlayerMovementController MovementController => movementController;
        
        public bool IsPressingMove
        {
            get => m_IsPressingMove;
            set => m_IsPressingMove = value;
        }

        
        private PlayerStates m_CurrentPlayerState;
        private BaseState m_CurrentState;

        private bool m_IsPressingMove;
        
        private Dictionary<PlayerStates, BaseState> m_StateDictionary;
        
        private void Awake()
        {
             m_StateDictionary = 
                new Dictionary<PlayerStates, BaseState>()
                {
                    { PlayerStates.Idle , new IdleState(this)},
                    { PlayerStates.Move , new MoveState(this)},
                    { PlayerStates.Attack , new AttackState(this)},
                    { PlayerStates.MoveAttack , new MoveAttackState(this)}
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
            m_CurrentPlayerState = newState;
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

        public void InvokeFunction(Action action, float delay)
        {
            Timing.RunCoroutine(_InvokeCoroutine(action, delay));
        }

        IEnumerator<float> _InvokeCoroutine(Action action, float delay)
        {
            yield return Timing.WaitForSeconds(delay);

            action.Invoke();
        }
    }
}