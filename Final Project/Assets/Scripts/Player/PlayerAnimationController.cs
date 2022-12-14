using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerSkillController skillController;
        [SerializeField] private float comboThreshold;
        
        private int m_IdleState = Animator.StringToHash(IDLE);
        private int m_WalkState = Animator.StringToHash(WALK);
        private int m_Speed = Animator.StringToHash(SPEED);
        private int m_BasicAttack = Animator.StringToHash(BASICATTACK);
        private int m_ComboCount = Animator.StringToHash(COMBO);
        private int m_PrimaryAttack = Animator.StringToHash(PRIMARYATTACK);
        private int m_SecondaryAttack = Animator.StringToHash(SECONDARYATTACK);

        private const string BASICATTACK = "BasicAttack";
        private const string PRIMARYATTACK = "PrimaryAttack";
        private const string SECONDARYATTACK = "SecondaryAttack";
        private const string WALK = "Walk";
        private const string SPEED = "Speed";
        private const string IDLE = "Idle";
        private const string COMBO = "Combo";

        public int GetComboCount => animator.GetInteger(m_ComboCount);
        
        public GameEvent OnAttackAnimFinished;
        
        private CoroutineHandle m_ComboCoroutine;

        public void PlayIdleAnimation()
        {
            animator.SetBool(m_IdleState,true);
        }
        
        public void StopIdleAnimation()
        {
            animator.SetBool(m_IdleState,false);
        }
        
        public void PlayWalkAnimation()
        {
            animator.SetBool(m_WalkState,true);
        }
        
        public void StopWalkAnimation()
        {
            animator.SetBool(m_WalkState,false);
        }

        public void SetSpeed(float speed)
        {
            animator.SetFloat(m_Speed, speed);
        }

        public void PlayBasicAttackAnimation()
        {
            if (m_ComboCoroutine != null)
            {
                Timing.KillCoroutines(m_ComboCoroutine);
            }
            
            animator.SetBool(m_BasicAttack,true);
            animator.SetTrigger(BASICATTACK + skillController.BasicSkillSettings.AnimationName);
        }
        
        public void StopBasicAttackAnimation()
        {
            animator.SetBool(m_BasicAttack,false);
            Debug.Log("Basic attack set to false");
        }

        public void PlayPrimaryAttackAnimation()
        {
            animator.SetBool(m_PrimaryAttack, true);
            animator.SetTrigger(PRIMARYATTACK + skillController.PrimarySkillSettings.AnimationName);
        }

        public void PlaySecondaryAttackAnimation()
        {
            animator.SetBool(m_SecondaryAttack, true);
            animator.SetTrigger(SECONDARYATTACK + skillController.SecondarySkillSettings.AnimationName);
        }

        public void StopAttackAnimations()
        {
            animator.SetBool(m_PrimaryAttack, false);
            animator.SetBool(m_SecondaryAttack, false);
        }

        public void _OnActiveSkillAnimationFinished()
        {
            OnAttackAnimFinished.Invoke();
        }

        public void _OnActiveSkillCast()
        {
            skillController.CastActiveSkill();
        }

        public void _OnAttackAnimationFinished()
        {
            OnAttackAnimFinished.Invoke();
            
            SetCombo();
            m_ComboCoroutine = Timing.RunCoroutine(ResetCombo());
        }
        
        public void _OnBasicAttackCast()
        {
            skillController.CastActiveSkill();
        }

        public void SetCombo()
        {
            if (animator.GetInteger(m_ComboCount) == 1)
            {
                animator.SetInteger(m_ComboCount, 2);
            }
            else if (animator.GetInteger(m_ComboCount) == 2)
            {
                animator.SetInteger(m_ComboCount, 3);
            }
            else
            {
                animator.SetInteger(m_ComboCount, 1);
            }
        }
        
        IEnumerator<float> ResetCombo()
        {
            yield return Timing.WaitForSeconds(comboThreshold);
            animator.SetInteger(m_ComboCount, 1);
        }
    }
}