using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerAnimationClips
    {
        
    }
    
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

        private const string BASICATTACK = "BasicAttack";
        private const string WALK = "Walk";
        private const string SPEED = "Speed";
        private const string IDLE = "Idle";
        private const string COMBO = "Combo";
        
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
            animator.SetTrigger(BASICATTACK + skillController.BasicSkill.AnimationName);
        }
        
        public void StopBasicAttackAnimation()
        {
            animator.SetBool(m_BasicAttack,false);
        }
        
        public void _OnAttackAnimationFinished()
        {
            OnAttackAnimFinished.Invoke();
            skillController.OnFinishedBasicSkill();
            
            SetCombo();
            m_ComboCoroutine = Timing.RunCoroutine(ResetCombo());
        }

        public void _OnBasicAttackCast()
        {
            skillController.CastBasicSkill();
        }

        private void SetCombo()
        {
            if (animator.GetInteger(COMBO) == 1)
            {
                animator.SetInteger(COMBO, 2);
            }
            else if (animator.GetInteger(COMBO) == 2)
            {
                animator.SetInteger(COMBO, 3);
            }
            else
            {
                animator.SetInteger(COMBO, 1);
            }
        }
        
        IEnumerator<float> ResetCombo()
        {
            yield return Timing.WaitForSeconds(comboThreshold);
            animator.SetInteger(COMBO, 1);
        }
    }
}