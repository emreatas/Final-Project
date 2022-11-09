using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using Stat;
using UnityEngine;
using Utils;

namespace Skills
{
    public abstract class AbstractSkill : ScriptableObject
    {
        [Header("Animations Name")]
        public string AnimationName;
        
        [Header("Attributes")]
        public StatType damageStatType;
        [Range(0,1)] public float damageMultiplier;
        
        public StatType attackSpeedStatType;
        [Range(0,1)] public float attackSpeedMultiplier;
      
        [Header("Projectile Prefab")]
        [SerializeField] protected AbstractProjectile prefab;
        
        [Header("Skill Indicator")]
        public SkillIndicatorSettings SkillIndicatorSettings;
        
        public GameEvent OnFinishedSkill;
        
        protected float m_Damage;
        protected float m_AttackSpeed;
        
        protected Transform m_Player;
        protected Vector3 m_ShootDirection;
        
        public Vector3 ShootDirection
        {
            get => m_ShootDirection;
            set => m_ShootDirection = value;
        }
        
        public virtual void CastSkill(){}
        
        public virtual void ShowSkillIndicator(SkillIndicator skillIndicator ,Vector3 shootDirection){}

        public virtual void RotatePlayer(Action<Vector3> LerpPlayer) { }
        
        public virtual void OnFinishedSkillAnimation()
        {
            ResetParams();
        }
        
        protected virtual void ResetParams()
        {
            m_Player = null;
        }
        
        public void SetAttributes(float baseDamage, float baseAttackSpeed)
        {
            m_Damage = baseDamage + (baseDamage * damageMultiplier);
            m_AttackSpeed = baseAttackSpeed * attackSpeedMultiplier;
        }

        public void SetPlayerTransform(Transform player)
        {
            m_Player = player;
        }
    }
}