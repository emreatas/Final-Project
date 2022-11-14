using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using Player;
using Stat;
using UnityEngine;
using Utils;

namespace Skills
{
    public abstract class AbstractSkill : ScriptableObject
    {
        [Header("Skill")] 
        public string SkillName;
        public PlayerSkillType skillType;
        public Sprite SkillIcon;
        [TextArea(10,100)] 
        public string SkillDescription;
        
        [Header("Animations Name")]
        public string AnimationName;
        
        [Header("Projectile Prefab")]
        [SerializeField] protected AbstractProjectile prefab;
        
        [Header("Skill Indicator")]
        public SkillIndicatorSettings SkillIndicatorSettings;
        
        public GameEvent OnFinishedSkill;

        protected CharacterStat m_CharacterStat;
        
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
        
        public virtual void ShowSkillIndicator(DecalSkillIndicator skillIndicator, Vector3 shootDirection){}

        public virtual void RotatePlayer(Action<Vector3> LerpPlayer) { }
        
        public virtual void OnFinishedSkillAnimation()
        {
            ResetParams();
        }
        
        protected virtual void ResetParams()
        {
            m_Player = null;
        }
        
        // public void SetAttributes(float baseDamage, float baseAttackSpeed)
        // {
        //     m_Damage = baseDamage + (baseDamage * damageMultiplier);
        //     m_AttackSpeed = baseAttackSpeed * attackSpeedMultiplier;
        // }
        
        public void SetAttributes(CharacterStat characterStat)
        {
            m_CharacterStat = characterStat;
        }

        public void SetPlayerTransform(Transform player)
        {
            m_Player = player;
        }
    }
}