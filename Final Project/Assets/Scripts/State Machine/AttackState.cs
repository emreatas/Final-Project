using UnityEngine;

namespace StateMachine
{
    public class AttackState : BaseState
    {
        public AttackState(FiniteStateMachine stateMachine) : base(stateMachine) { }

        private bool m_IsPressingBasicAttack;

        private bool m_PerformingAttack;

        private bool m_IsPressingMove;
        
        public override void OnEnter()
        {
            Debug.Log("Enter Attack State");
            AddListeners();
        }

        public override void OnExit()
        {
            Debug.Log("Exit Attack State");
            RemoveListeners();
        }

        private void HandleOnBasicAttackPerformed()
        {
            m_IsPressingBasicAttack = true;
            
            if (!m_PerformingAttack)
            {
                m_PerformingAttack = true;
                
                m_StateMachine.SkillController.StartBasicSkill();
                m_StateMachine.AnimationController.PlayBasicAttackAnimation();
            }
        }
        
        private void HandleOnBasicAttackCanceled()
        {
            m_IsPressingBasicAttack = false;
        }
        
        private void HandleOnFinishedBasicSkill()
        {
            if (!m_IsPressingBasicAttack)
            {
                m_StateMachine.AnimationController.StopBasicAttackAnimation();
                m_StateMachine.InvokeFunction(ChangeState,0.1f);
            }
            else
            {
                ResetPerformAttack();
            }
        }
        
        private void HandleOnMoveStarted()
        {
            m_StateMachine.IsPressingMove = true;
        }

        private void HandleOnMoveCanceled()
        {
            m_StateMachine.IsPressingMove = false;
        }
        
        private void ChangeState()
        {
            ResetPerformAttack();

            if (!m_IsPressingBasicAttack)
            {
                if (m_StateMachine.IsPressingMove)
                {
                    m_StateMachine.SwitchState(PlayerStates.Move);
                }
                else
                {
                    m_StateMachine.SwitchState(PlayerStates.Idle);
                }
            }
        }
        
        private void ResetPerformAttack()
        {
            m_PerformingAttack = false;
        }
        
        private void AddListeners()
        {
            m_StateMachine.InputSystem.OnBasicAttackPerformed.AddListener(HandleOnBasicAttackPerformed);
            m_StateMachine.InputSystem.OnBasicAttackCanceled.AddListener(HandleOnBasicAttackCanceled);
  
            m_StateMachine.AnimationController.OnAttackAnimFinished.AddListener(HandleOnFinishedBasicSkill);
  
            m_StateMachine.InputSystem.OnMoveStarted.AddListener(HandleOnMoveStarted);
            m_StateMachine.InputSystem.OnMoveCanceled.AddListener(HandleOnMoveCanceled);
        }
        
        private void RemoveListeners()
        {
            m_StateMachine.InputSystem.OnBasicAttackPerformed.RemoveListener(HandleOnBasicAttackPerformed);
            m_StateMachine.InputSystem.OnBasicAttackCanceled.RemoveListener(HandleOnBasicAttackCanceled);

            m_StateMachine.AnimationController.OnAttackAnimFinished.RemoveListener(HandleOnFinishedBasicSkill);
            
            m_StateMachine.InputSystem.OnMoveStarted.RemoveListener(HandleOnMoveStarted);
            m_StateMachine.InputSystem.OnMoveCanceled.RemoveListener(HandleOnMoveCanceled);

        }
    }
}

