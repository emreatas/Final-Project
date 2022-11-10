using System.Collections;
using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace Skills
{
    public class SkillProjectile_MeteorShower : AbstractProjectile
    {
        [SerializeField] private float attackSpeedMultiplicator;
        
        [SerializeField] private StatType damageType;
        [SerializeField] private StatType attackSpeedType;

        private float m_AttackSpeed;
        private float m_Damage;
   
        protected override void SetStatValues()
        {
            m_AttackSpeed = m_CharacterStat.GetValue(attackSpeedType);
            m_Damage = m_CharacterStat.GetValue(damageType);
        }
        public override void FireProjectile()
        {
            rb.velocity = Vector3.down * m_AttackSpeed * attackSpeedMultiplicator;
        }

        private void OnTriggerEnter(Collider other)
        {
            IHealth enemy = other.GetComponent<IHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(m_Damage);
            }
            Destroy(gameObject);
        }
    }

}
