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
        public string AnimationName;
        
        public StatType damageStatType;
        [Range(0,1)] public float damageMultiplier;
        
        public StatType attackSpeedStatType;
        [Range(0,1)] public float attackSpeedMultiplier;

        public SkillIndicatorSettings SkillIndicatorSettings;
        public GameEvent OnFinishedSkill;
        
        public float m_Damage;
        public float m_AttackSpeed;
        protected Transform m_Player;
        protected Vector3 m_ShootDirection;
        [SerializeField] protected AbstractProjectile prefab;

        public Vector3 ShootDirection
        {
            get => m_ShootDirection;
            set => m_ShootDirection = value;

        }

        public virtual void StartSkill(){}
        public virtual void PerformSkill(Vector3 shootDirection){}
        public virtual void CancelSkill(){}
        public virtual void CastSkill(){}
        public virtual void OnFinishedSkillAnimation(){}

        public virtual void ShowSkillIndicator(SkillIndicator skillIndicator ,Vector3 shootDirection){}

        public virtual Vector3 FindTargetPosition()
        {
            return Vector3.zero;
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