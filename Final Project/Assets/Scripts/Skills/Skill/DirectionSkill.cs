using System;
using System.Collections;
using System.Collections.Generic;
using Skills;
using Stat;
using UnityEngine;

namespace Skills
{
    public class DirectionSkill : AbstractNewSkill
    {
        [SerializeField] private ParticleSystem thrustParticleSystem;
        
        [SerializeField] private StatType attackType;
        [SerializeField][Range(0,1)] private float attackMultiplicator;

        private float m_Damage;
        
        protected override void OnInitialized()
        {
            m_Damage = m_PlayerSkillController.PlayerStats.CharacterStats.GetValue(attackType) * attackMultiplicator;
            
            thrustParticleSystem.Play();
        }

        protected override void OnDisableCallback() { }


        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("On Trigger entered +" + other.name);
            if (other.TryGetComponent(out IHealth health))
            {
                Debug.Log("Call on take damage " + m_Damage);
                health.TakeDamage(m_Damage, m_PlayerSkillController.gameObject);
            }
        }
    }
}
