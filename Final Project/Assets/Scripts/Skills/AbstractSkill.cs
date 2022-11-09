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
        public StatType statType;
        [Range(0,1)]
        public float damageMultiplier;

        public SkillIndicatorSettings SkillIndicatorSettings;
        public GameEvent OnFinishedSkill;

        public float SkillDuration;
        public float m_Damage;
        
        
        public virtual void StartSkill(){}
        public virtual void PerformSkill(Vector3 shootDirection){}
        public virtual void CancelSkill(){}
        public virtual void CastSkill(){}
        public virtual void OnFinishedSkillAnimation(){}

        public virtual void ShowSkillIndicator(SkillIndicator skillIndicator ,Vector3 shootDirection){}

        public virtual Vector3 FindTargetPosition(Transform player)
        {
            return Vector3.zero;
        }

        public void SetDamage(float baseDamage)
        {
            m_Damage = baseDamage + (baseDamage * damageMultiplier);
        }
    }
}