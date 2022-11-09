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
        [SerializeField] private float enemyDetectRadius;
        [SerializeField] private LayerMask enemyLayerMask;

        private Transform m_Target;

        public override Vector3 FindTargetPosition()
        {
            Collider[] hitColliders = Physics.OverlapSphere(m_Player.position, enemyDetectRadius, enemyLayerMask);
            
            if ( hitColliders.Length > 0)
            {
                m_Target = FindClosestEnemy(m_Player.position, hitColliders).transform;
                
                Debug.Log("Hit " + m_Target.name);
                return m_Target.position;
            }
            
            return Vector3.zero;
        }

        public override void CastSkill()
        {
            var projectile = Instantiate(prefab, m_Player.position, quaternion.identity);
            projectile.InitializeParams(m_Damage, m_AttackSpeed);
            projectile.FireProjectile( m_Player.forward,m_Target);
        }
        
        public override void OnFinishedSkillAnimation()
        {
            OnFinishedSkill.Invoke();
            ResetParams();
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
        
        private void ResetParams()
        {
            m_Player = null;
            m_Target = null;
        }
    }
}