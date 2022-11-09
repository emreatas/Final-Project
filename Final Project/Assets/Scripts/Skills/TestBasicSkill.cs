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
        [SerializeField] private float skillSpeed;
        [SerializeField] private float rotatateLerpDuration;
        [SerializeField] private float enemyDetectRadius;
        [SerializeField] private float maxDistance;
        [SerializeField] private LayerMask enemyLayerMask;
        [SerializeField] private BasicSkillProjectile projectilePrefab;

        private Transform m_Player;
        private Transform m_Target;
        
        public override void StartSkill()
        {
            Debug.Log("Start Basic Attack");
        }

        public override IEnumerator<float> SkillCoroutine(Transform player)
        {
            Debug.Log("Perform Basic Attack");
            m_Player = player;

            Collider[] hitColliders = Physics.OverlapSphere(player.position, enemyDetectRadius, enemyLayerMask);
            
            if ( hitColliders.Length > 0)
            {
                m_Target = FindClosestEnemy(player.position, hitColliders).transform;
                
                Debug.Log("Hit " + m_Target.name);
                
                float lerpedTime = 0;
            
                Quaternion startRot = player.rotation;
                Quaternion targetRot = Quaternion.LookRotation(m_Target.position - player.position);
            
                while (rotatateLerpDuration > lerpedTime)
                {
                    player.rotation = Quaternion.Slerp(startRot, targetRot, lerpedTime/rotatateLerpDuration);        
        
                    lerpedTime += Time.deltaTime;
                    
                    yield return Timing.WaitForOneFrame;
                }
            }
        }

        public override void CastSkill()
        {
            var projectile = Instantiate(projectilePrefab, m_Player.position, quaternion.identity);
            projectile.InitializeProjectile(m_Target, m_Player.forward, m_Damage);
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
        
        public override void CancelSkill()
        {
            Debug.Log("Cancel Basic Attack");
        }
        
        private void ResetParams()
        {
            m_Player = null;
            m_Target = null;
        }

        public override void FinishedSkill()
        {
            OnFinishedSkill.Invoke();
            ResetParams();
        }
    }
}