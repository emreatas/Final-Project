using UnityEngine;

namespace Skills
{
    public class BasicSkillProjectile : AbstractProjectile
    {
        [SerializeField] private float maxRange;
        
        private Vector3 m_PlayerForwardDir;
        private Vector3 m_SpawnPosition;
        
        public override void FireProjectile(Vector3 dir)
        {
            m_PlayerForwardDir = dir;
            m_SpawnPosition = transform.position;
        }
        
        private void Update()
        {
            if (m_HasTarget && !IsTargetDestroyed)
            {
                transform.position = Vector3.MoveTowards(transform.position, m_TargetTransform.position, m_AttackSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, m_SpawnPosition + (m_PlayerForwardDir * maxRange), m_AttackSpeed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            IHealth enemy = other.GetComponent<IHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(m_Damage);
                Destroy(gameObject);
            }
        }

       
    } 
}

