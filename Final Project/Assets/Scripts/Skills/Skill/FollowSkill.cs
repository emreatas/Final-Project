using System;
using System.Collections;
using System.Collections.Generic;
using Stat;
using UnityEngine;

public class FollowSkill : AbstractNewSkill
{
    // [SerializeField] private ParticleSystem thrustParticleSystem;
        
    [SerializeField] private StatType attackType;
    [SerializeField][Range(0,1)] private float attackMultiplicator;
    [SerializeField] private float speed;

    private float m_Damage;
    private Vector3 m_ShootDir;
    private Target m_Target;

    private bool HasTarget => m_Target != null;
    
    protected override void OnInitialized()
    {
        m_Damage = m_PlayerSkillController.PlayerStats.CharacterStats.GetValue(attackType) * attackMultiplicator;
        
        m_ShootDir = m_PlayerSkillController.ShootDirection;
        m_Target = m_PlayerSkillController.PlayerTarget.GetTarget();
        AddListeners();
        // thrustParticleSystem.Play();
    }
    
    private void Update()
    {
        Vector3 dir = FindDirection();

        Vector3 moveSpeed = dir * (Time.deltaTime * speed);
        transform.position += moveSpeed;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHealth health))
        {
            health.TakeDamage(m_Damage, m_PlayerSkillController.gameObject);
            Release();
        }
    }

    private Vector3 FindDirection()
    {
        if (HasTarget)
        {
            return (m_Target.transform.position - transform.position).normalized;
        }
        else
        {
            return m_ShootDir.normalized;
        }
    }

    protected override void OnDisableCallback()
    {
        RemoveListeners();
    }
    
    private void HandleOnTargetDestroyed()
    {
        RemoveListeners();
        m_Target = null;
    }
    
    private void AddListeners()
    {
        if (m_Target != null)
        {
            m_Target.OnDestroyed.AddListener(HandleOnTargetDestroyed);
        }
    }

    private void RemoveListeners()
    {
        if (m_Target != null)
        {
            m_Target.OnDestroyed.RemoveListener(HandleOnTargetDestroyed);
        }
    }
}
