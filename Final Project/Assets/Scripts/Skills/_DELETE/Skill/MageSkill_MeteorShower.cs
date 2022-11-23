using System.Collections;
using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace Skills
{
    public class MageSkill_MeteorShower : AbstractSkill
    {
        [SerializeField] protected Rigidbody rb;
        
        [SerializeField] private float attackSpeedMultiplicator;
        [SerializeField] private float damageMultiplicator;

        [SerializeField] private StatType damageType;
        [SerializeField] private StatType attackSpeedType;

        private float m_AttackSpeed;
        private float m_Damage;
   
        protected override void SetStats()
        {
            m_AttackSpeed = m_CharacterStat.GetValue(attackSpeedType);
            m_Damage = m_CharacterStat.GetValue(damageType);
        }
        public override void FireProjectile(Vector3 direction, Transform target)
        {
            rb.velocity = Vector3.down * m_AttackSpeed * attackSpeedMultiplicator;
        }

        private void OnTriggerEnter(Collider other)
        {
            IHealth enemy = other.GetComponent<IHealth>();
            if (enemy != null)
            {
                //enemy.TakeDamage(m_Damage * damageMultiplicator);
            }

            Debug.Log("Interacted with " + other.name);
        }
    }

}
