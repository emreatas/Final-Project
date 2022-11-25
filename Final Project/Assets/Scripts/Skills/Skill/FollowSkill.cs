using System;
using System.Collections;
using System.Collections.Generic;
using Stat;
using UnityEngine;

public class FollowSkill : AbstractNewSkill
{
    [SerializeField] private ParticleSystem thrustParticleSystem;
        
    [SerializeField] private StatType attackType;
    [SerializeField][Range(0,1)] private float attackMultiplicator;
    [SerializeField] private float speed;

    private float m_Damage;
        
    protected override void OnInitialized()
    {
        m_Damage = m_PlayerSkillController.PlayerStats.CharacterStats.GetValue(attackType) * attackMultiplicator;
            
        thrustParticleSystem.Play();
    }
    
    private void Update()
    {
        if (m_PlayerSkillController.PlayerTarget.HasTarget)
        {
            Vector3 dir = (m_PlayerSkillController.PlayerTarget.GetTargetPosition() - transform.position).normalized;
            Vector3 moveSpeed = dir * (Time.deltaTime * speed);
            transform.position += moveSpeed;
        }
        else
        {
            Vector3 moveSpeed = transform.forward * (Time.deltaTime * speed);
            transform.position += moveSpeed;
        }
       
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
