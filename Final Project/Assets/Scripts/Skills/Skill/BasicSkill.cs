using Stat;
using UnityEngine;

namespace Skills
{
    public class BasicSkill : AbstractSkill
    {
        [SerializeField] private float maxRange;

        [SerializeField] private StatType damageType;
        [SerializeField] private StatType attackSpeedType;

        private float m_AttackSpeed;
        private float m_Damage;
        
        private Vector3 m_PlayerForwardDir;
        private Vector3 m_SpawnPosition;

        protected override void SetStats()
        {
            m_AttackSpeed = m_CharacterStat.GetValue(attackSpeedType);
            m_Damage = m_CharacterStat.GetValue(damageType);
        }

        public override void FireProjectile(Vector3 dir, Transform target)
        {
            SetTarget(target);
            m_PlayerForwardDir = dir;
            m_SpawnPosition = transform.position;
        }
        
        private void Update()
        {
            if (HasTarget)
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

