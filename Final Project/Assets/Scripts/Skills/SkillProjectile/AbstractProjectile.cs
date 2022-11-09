using System.Collections;
using System.Collections.Generic;
using EpicToonFX;
using UnityEngine;

namespace Skills
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class AbstractProjectile : MonoBehaviour
    {
        [SerializeField] protected Rigidbody rb;
        
        protected float m_Damage;
        protected float m_AttackSpeed;
        
        protected bool m_HasTarget;
        protected Transform m_TargetTransform;

        protected bool IsTargetDestroyed => m_TargetTransform == null; 
        
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
        
        public abstract void FireProjectile(Vector3 dir);
    }

}