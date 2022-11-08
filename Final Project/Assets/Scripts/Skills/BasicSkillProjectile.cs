using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class BasicSkillProjectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float maxRange;
        private Transform m_TargetTransform;
        private Vector3 m_PlayerForwardDir;
        private Vector3 m_SpawnPosition;
        
        private bool m_HasTarget = true;
        
        public void InitializeProjectile(Transform target, Vector3 playerForwardDir)
        {
            m_TargetTransform = target;
            m_PlayerForwardDir = playerForwardDir;
            m_SpawnPosition = transform.position;
            
            if (m_TargetTransform == null)
            {
                m_HasTarget = false;
            }
        }
        
        private void Update()
        {
            if (m_HasTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, m_TargetTransform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, m_SpawnPosition + (m_PlayerForwardDir * maxRange), speed * Time.deltaTime);
            }
        }
    } 
}

