using System;
using System.Collections;
using System.Collections.Generic;
using EpicToonFX;
using MEC;
using UnityEngine;

namespace Skills
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class AbstractProjectile : MonoBehaviour
    {
        [SerializeField] protected Rigidbody rb;
        [SerializeField] private float lifeTime;
        
        protected float m_Damage;
        protected float m_AttackSpeed;
        
        protected bool m_HasTarget;
        protected Transform m_TargetTransform;

        private CoroutineHandle m_DestroyCoroutine;
        
        protected bool IsTargetDestroyed => m_TargetTransform == null;

        private void Start()
        {
            m_DestroyCoroutine = Timing.RunCoroutine(_Destroy());
        }
        
        private void OnDestroy()
        {
            Timing.KillCoroutines(m_DestroyCoroutine);
        }
        
        public void InitializeParams(float damage, float attackSpeed)
        {
            m_Damage = damage;
            m_AttackSpeed = attackSpeed;
        }
        protected void SetHasTarget()
        {
            if (m_TargetTransform == null)
            {
                m_HasTarget = false;
            }
            else
            {
                m_HasTarget = true;
            }
        }
        
        public void FireProjectile(Vector3 dir, Transform target)
        {
            m_TargetTransform = target;
            SetHasTarget();
            
            FireProjectile(dir);
        }
        
        public virtual void FireProjectile(Vector3 dir){}
        public virtual void FireProjectile(){}

        private IEnumerator<float> _Destroy()
        {
            yield return Timing.WaitForSeconds(lifeTime);
            
            Destroy(gameObject);
        }
    }

}