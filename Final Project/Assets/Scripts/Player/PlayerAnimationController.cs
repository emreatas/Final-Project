using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private int m_IdleState = Animator.StringToHash("Idle");
        private int m_WalkState = Animator.StringToHash("Walk");
        private int m_Speed = Animator.StringToHash("Speed");
        private int m_BasicAttack = Animator.StringToHash("BasicAttack");

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
            animator.SetTrigger(m_BasicAttack);
        }

        public void _OnAttackAnimationFinished()
        {
            OnAttackAnimFinished.Invoke();
        }
    }
}