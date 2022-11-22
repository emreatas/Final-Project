using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class MoveAttackState : BaseState
    {
        public MoveAttackState(FiniteStateMachine stateMachine) : base(stateMachine) { }

        private bool m_PerfomingAttack;
        private Vector3 m_lastPrimaryAttackDirection;
        
        public override void OnEnter()
        {
            Debug.Log("Enter Attack Move State");
            AddListeners();
            StartCurrentAnimation();
        }

        public override void OnExit()
        {
            Debug.Log("Exit Attack Move State");
            RemoveListeners();
            StopCurrentAnimation();
        }
        
        private void HandleOnMoveStarted()
        {
            m_StateMachine.IsPressingMove = true;
            m_StateMachine.AnimationController.StopIdleAnimation();
            m_StateMachine.AnimationController.PlayWalkAnimation();
        }
        
        private void HandleOnMovePerformed(Vector3 movementVector)
        {
            MovePlayer(movementVector);
            RotatePlayer(movementVector);
            // Debug.Log(movementVector.magnitude);
            m_StateMachine.AnimationController.SetSpeed(movementVector.magnitude);
        }
        
        private void HandleOnMoveCanceled()
        {
            m_StateMachine.IsPressingMove = false;
            m_StateMachine.AnimationController.StopWalkAnimation();
            m_StateMachine.AnimationController.PlayIdleAnimation();
        }

        
        private void MovePlayer(Vector3 movementVector)
        {
            m_StateMachine.MovementController.MovePlayer(movementVector);
        }

        private void RotatePlayer(Vector3 movementVector)
        {
            m_StateMachine.MovementController.RotatePlayer(movementVector);
        }
        
        private void HandleOnPerfomedPrimarySkill(Vector3 skillDirection)
        {
            m_StateMachine.SkillController.PerformPrimarySkill(skillDirection);
            
            m_lastPrimaryAttackDirection = skillDirection;
        }
        
        private void HandleOnPrimarySkillCanceled()
        {
            m_StateMachine.AnimationController.PlayPrimaryAttackAnimation();
            m_StateMachine.SkillController.StartPrimarySkill(m_lastPrimaryAttackDirection);

            RemoveMovementListeners();
            RemoveSkillListeners();
            
            StopCurrentAnimation();
        }
        
        private void HandleOnPerformedSecondarySkill(Vector3 skillDirection)
        {
            m_StateMachine.SkillController.PerformSecondarySkill(skillDirection);
            
            m_lastPrimaryAttackDirection = skillDirection;
        }

        private void HandleOnSecondarySkillCanceled(Vector3 obj)
        {
            m_StateMachine.AnimationController.PlaySecondaryAttackAnimation();
            m_StateMachine.SkillController.StartSecondarySkill(m_lastPrimaryAttackDirection);

            RemoveMovementListeners();
            RemoveSkillListeners();
            
            StopCurrentAnimation();
        }

        private void StartCurrentAnimation()
        {
            if (m_StateMachine.IsPressingMove)
            {
                m_StateMachine.AnimationController.StopIdleAnimation();
                m_StateMachine.AnimationController.PlayWalkAnimation();
            }
            else
            {
                m_StateMachine.AnimationController.StopWalkAnimation();
                m_StateMachine.AnimationController.PlayIdleAnimation();
            }
        }

        private void StopCurrentAnimation()
        {
            if (m_StateMachine.IsPressingMove)
            {
                m_StateMachine.AnimationController.StopWalkAnimation();
            }
            else
            {
                m_StateMachine.AnimationController.StopIdleAnimation();
            }
        }
        
        private void HandleAttackFinished()
        {
            m_StateMachine.AnimationController.StopAttackAnimations();
            m_StateMachine.InvokeFunction(ChangeState,0.1f);
        }
        
        private void ChangeState()
        {
            m_StateMachine.SwitchState(PlayerStates.Idle);
        }
        
        private void AddListeners()
        {
            AddMovementListeners();
            AddSkillListeners();
            
            m_StateMachine.AnimationController.OnAttackAnimFinished.AddListener(HandleAttackFinished);
        }

        
        private void RemoveListeners()
        {
            RemoveMovementListeners();
            RemoveSkillListeners();
            
            m_StateMachine.AnimationController.OnAttackAnimFinished.RemoveListener(HandleAttackFinished);
        }
        
        private void AddMovementListeners()
        {
            m_StateMachine.InputSystem.OnMoveStarted.AddListener(HandleOnMoveStarted);
            m_StateMachine.InputSystem.OnMovePerformed.AddListener(HandleOnMovePerformed);
            m_StateMachine.InputSystem.OnMoveCanceled.AddListener(HandleOnMoveCanceled);

        }

        private void RemoveMovementListeners()
        {
            m_StateMachine.InputSystem.OnMoveStarted.RemoveListener(HandleOnMoveStarted);
            m_StateMachine.InputSystem.OnMovePerformed.RemoveListener(HandleOnMovePerformed);
            m_StateMachine.InputSystem.OnMoveCanceled.RemoveListener(HandleOnMoveCanceled);
        }

        private void AddSkillListeners()
        {
            m_StateMachine.InputSystem.OnPrimarySkillPerfomed.AddListener(HandleOnPerfomedPrimarySkill);
            m_StateMachine.InputSystem.OnPrimarySkillCanceled.AddListener(HandleOnPrimarySkillCanceled);
            
            m_StateMachine.InputSystem.OnSecondarySkillPerfomed.AddListener(HandleOnPerformedSecondarySkill);
            m_StateMachine.InputSystem.OnSecondarySkillCanceled.AddListener(HandleOnSecondarySkillCanceled);
        }

        private void RemoveSkillListeners()
        {
            m_StateMachine.InputSystem.OnPrimarySkillPerfomed.RemoveListener(HandleOnPerfomedPrimarySkill);
            m_StateMachine.InputSystem.OnPrimarySkillCanceled.RemoveListener(HandleOnPrimarySkillCanceled);
            
            m_StateMachine.InputSystem.OnSecondarySkillPerfomed.RemoveListener(HandleOnPerformedSecondarySkill);
            m_StateMachine.InputSystem.OnSecondarySkillCanceled.RemoveListener(HandleOnSecondarySkillCanceled);
        }
    }
}