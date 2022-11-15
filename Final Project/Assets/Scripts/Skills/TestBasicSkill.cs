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

        public override void StartSkill()
        {
            Transform target = FindTarget();

            if (target != null)
            {
                m_LerpPlayerRotationAction(target.position);
            }
        }

        public override void CastSkill()
        {
            var projectile = Instantiate(prefab, m_Player.position, quaternion.identity);
            // projectile.InitializeParams(m_Damage, m_AttackSpeed);
            projectile.InitializeStats(m_CharacterStat);
            projectile.FireProjectile( m_Player.forward,m_Target);
        }

        public override void ShowSkillIndicator(DecalSkillIndicator skillIndicator, Vector3 shootDirection)
        {
            throw new NotImplementedException();
        }

        public override void OnFinishedSkillAnimation()
        {
            OnFinishedSkill.Invoke();
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