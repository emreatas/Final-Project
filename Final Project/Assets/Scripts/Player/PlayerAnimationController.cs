using System;
using System.Collections;
using System.Collections.Generic;
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
        
        private int m_IdleState = Animator.StringToHash(IDLE);
        private int m_WalkState = Animator.StringToHash(WALK);
        private int m_Speed = Animator.StringToHash(SPEED);
        private int m_BasicAttack = Animator.StringToHash(BASICATTACK);

        private const string BASICATTACK = "BasicAttack";
        private const string WALK = "Walk";
        private const string SPEED = "Speed";
        private const string IDLE = "Idle";

        public GameEvent OnAttackAnimFinished;

 
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
        }
    }
}