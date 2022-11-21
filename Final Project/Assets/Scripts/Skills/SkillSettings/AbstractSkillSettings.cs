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
    public abstract class AbstractSkillSettings : ScriptableObject
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
        [SerializeField] protected AbstractSkill prefab;
        
        [Header("Skill Indicator")]
        public SkillIndicatorSettings SkillIndicatorSettings;
        
        protected CharacterStat m_CharacterStat;
        protected Transform m_Player;
        protected Vector3 m_ShootDirection;

        protected Action<Vector3> m_LerpPlayerRotationAction;
        
        //public GameEvent OnFinishedSkill;
        
        public void InitializeSkill(CharacterStat characterStat, Transform playerTransform, Action<Vector3> lerpPlayerRotationAction)
        {
            m_CharacterStat = characterStat;
            m_Player = playerTransform;
            m_LerpPlayerRotationAction = lerpPlayerRotationAction;
        } 
        public void ResetParams()
        {
            m_Player = null;
            m_CharacterStat = null;
            m_LerpPlayerRotationAction = null;
        }

        public void SetShootDirection(Vector3 shootDir)
        {
            m_ShootDirection = shootDir;
        }

        public virtual void StartSkill(){}
        public abstract void CastSkill();
        public virtual void ShowSkillIndicator(DecalSkillIndicator skillIndicator, Vector3 shootDirection){}
        public virtual void OnFinishedSkillAnimation(){}
    }
}