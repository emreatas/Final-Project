using System;
using System.Collections;
using System.Collections.Generic;
using EpicToonFX;
using MEC;
using Stat;
using UnityEngine;

namespace Skills
{
    public abstract class AbstractSkill : MonoBehaviour
    {
        [SerializeField] protected float lifeTime;
        
        protected Transform m_TargetTransform;

        private CoroutineHandle m_DestroyCoroutine;
        
        protected CharacterStat m_CharacterStat;

        protected bool HasTarget => m_TargetTransform != null;

        private void Start()
        {
            m_DestroyCoroutine = Timing.RunCoroutine(_Destroy());
        }
        
        private void OnDestroy()
        {
            Timing.KillCoroutines(m_DestroyCoroutine);
        }
        
        public void InitializeStats(CharacterStat characterStat)
        {
            m_CharacterStat = characterStat;
            SetStats();
        }

        protected void SetTarget(Transform target)
        {
            m_TargetTransform = target;
        }

        public void FireProjectile()
        {
            FireProjectile(Vector3.zero, null);
        }

        public void FireProjectile(Vector3 dir)
        {
            FireProjectile(dir,null);
        }

        public abstract void FireProjectile(Vector3 dir, Transform target);
        protected abstract void SetStats();

        protected virtual IEnumerator<float> _Destroy()
        {
            yield return Timing.WaitForSeconds(lifeTime);
            
            Destroy(gameObject);
        }
    }

}