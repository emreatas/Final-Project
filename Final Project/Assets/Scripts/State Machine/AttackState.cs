using UnityEngine;

namespace StateMachine
{
    public class AttackState : BaseState
    {
        public AttackState(FiniteStateMachine stateMachine) : base(stateMachine) { }

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
            m_StateMachine.SkillController.PerformBasicSkill();
            m_StateMachine.AnimationController.PlayBasicAttackAnimation();
        }
        
        private void HandleOnFinishedBasicSkill()
        {
            m_StateMachine.SwitchState(PlayerStates.Idle);
        }
        
        private void HandleOnPrimarySkillPerformed(Vector3 skillVector)
        {
            m_StateMachine.SkillController.PerformPrimarySkill(skillVector);
        }

        private void HandleOnPrimarySkillCanceled(Vector3 skillVector)
        {
            m_StateMachine.SkillController.CancelPrimarySkill(skillVector);
        }

        private void HandleOnFinishedPrimarySkill()
        {
            m_StateMachine.SwitchState(PlayerStates.Idle);
        }
        
        private void HandleOnSecondarySkillPerformed(Vector3 skillVector)
        {
            m_StateMachine.SkillController.PerformSecondarySkill(skillVector);
        }

        private void HandleOnSecondarySkillCanceled(Vector3 skillVector)
        {
            m_StateMachine.SkillController.CancelSecondarySkill(skillVector);
        }

        private void HandleOnFinishedSecondarySkill()
        {
            m_StateMachine.SwitchState(PlayerStates.Idle);
        }
        
        private void AddListeners()
        {
            m_StateMachine.InputSystem.OnBasicAttackPerformed.AddListener(HandleOnBasicAttackPerformed);
            // m_StateMachine.SkillController.BasicSkill.OnFinishedSkill.AddListener(HandleOnFinishedBasicSkill);
            m_StateMachine.AnimationController.OnAttackAnimFinished.AddListener(HandleOnFinishedBasicSkill);
            
            m_StateMachine.InputSystem.OnPrimarySkillPerfomed.AddListener(HandleOnPrimarySkillPerformed);
            m_StateMachine.InputSystem.OnPrimarySkillCanceled.AddListener(HandleOnPrimarySkillCanceled);
            // m_StateMachine.SkillController.PrimarySkill.OnFinishedSkill.AddListener(HandleOnFinishedPrimarySkill);
            
            
            
            m_StateMachine.InputSystem.OnSecondarySkillPerfomed.AddListener(HandleOnSecondarySkillPerformed);
            m_StateMachine.InputSystem.OnSecondarySkillCanceled.AddListener(HandleOnSecondarySkillCanceled);
            // m_StateMachine.SkillController.SecondarySkill.OnFinishedSkill.AddListener(HandleOnFinishedSecondarySkill);
        }

        private void RemoveListeners()
        {
            m_StateMachine.InputSystem.OnBasicAttackPerformed.RemoveListener(HandleOnBasicAttackPerformed);
            // m_StateMachine.SkillController.BasicSkill.OnFinishedSkill.RemoveListener(HandleOnFinishedBasicSkill);
            m_StateMachine.AnimationController.OnAttackAnimFinished.RemoveListener(HandleOnFinishedBasicSkill);
            
            m_StateMachine.InputSystem.OnPrimarySkillPerfomed.RemoveListener(HandleOnPrimarySkillPerformed);
            m_StateMachine.InputSystem.OnPrimarySkillCanceled.RemoveListener(HandleOnPrimarySkillCanceled);
            // m_StateMachine.SkillController.PrimarySkill.OnFinishedSkill.RemoveListener(HandleOnFinishedPrimarySkill);
            
            m_StateMachine.InputSystem.OnSecondarySkillPerfomed.RemoveListener(HandleOnSecondarySkillPerformed);
            m_StateMachine.InputSystem.OnSecondarySkillCanceled.RemoveListener(HandleOnSecondarySkillCanceled);
            // m_StateMachine.SkillController.SecondarySkill.OnFinishedSkill.RemoveListener(HandleOnFinishedSecondarySkill);
        }
    }
}

