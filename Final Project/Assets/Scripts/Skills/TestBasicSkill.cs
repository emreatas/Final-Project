using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using Unity.Mathematics;
using UnityEngine;
using Utils;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/TestBasic")]
    public class TestBasicSkill : AbstractSkill
    {
        [Header("Enemy")]
        [SerializeField] private float enemyDetectRadius;
        [SerializeField] private LayerMask enemyLayerMask;

        private Transform m_Target;

        public override void RotatePlayer(Action<Vector3> LerpPlayer)
        {
            Transform target = FindTarget();

            if (target != null)
            {
                LerpPlayer(target.position);
            }
        }

        public override void CastSkill()
        {
            var projectile = Instantiate(prefab, m_Player.position, quaternion.identity);
            // projectile.InitializeParams(m_Damage, m_AttackSpeed);
            projectile.InitializeStats(m_CharacterStat);
            projectile.FireProjectile( m_Player.forward,m_Target);
        }
        
        public override void OnFinishedSkillAnimation()
        {
            base.OnFinishedSkillAnimation();
            OnFinishedSkill.Invoke();
        }
        
        protected override void ResetParams()
        {
            base.ResetParams();
            m_Target = null;
        }
        
        private Transform FindTarget()
        {
            Collider[] hitColliders = Physics.OverlapSphere(m_Player.position, enemyDetectRadius, enemyLayerMask);
            
            if ( hitColliders.Length > 0)
            {
                m_Target = FindClosestEnemy(m_Player.position, hitColliders).transform;
            }
            
            return m_Target ;
        }

        private Collider FindClosestEnemy(Vector3 playerPos, Collider[] hitCollider)
        {
            Collider closest = hitCollider[0];
            float closestDistance = Mathf.Infinity;
            
            for (int i = 0; i < hitCollider.Length; i++)
            {
                float distance = (playerPos - hitCollider[i].transform.position).sqrMagnitude;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = hitCollider[i];
                }
            }
            return closest;
        }
    }
}