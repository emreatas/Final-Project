using System.Collections;
using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace Skills
{
    public class MeteorSkill : AbstractNewSkill
    {
        [SerializeField] protected Rigidbody rb;
        
        [SerializeField] private float attackSpeedMultiplicator;
        [SerializeField] private float damageMultiplicator;

        [SerializeField] private StatType damageType;
        [SerializeField] private StatType attackSpeedType;
        
        private float m_AttackSpeed;
        private float m_Damage;
        
        protected override void OnInitialized()
        {
            m_AttackSpeed = m_PlayerSkillController.PlayerStats.CharacterStats.GetValue(attackSpeedType);
            m_Damage = m_PlayerSkillController.PlayerStats.CharacterStats.GetValue(damageType);
            
            rb.velocity = Vector3.down * m_AttackSpeed * attackSpeedMultiplicator;
        }

        protected override void OnReleaseObject() { }

        private void OnTriggerEnter(Collider other)
        {
            IHealth enemy = other.GetComponent<IHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(m_Damage * damageMultiplicator);
            }

            Debug.Log("Interacted with " + other.name);
        }
    }
}
