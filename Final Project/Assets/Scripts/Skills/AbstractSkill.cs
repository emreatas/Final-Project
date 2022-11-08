using System.Collections;
using System.Collections.Generic;
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
        
        public GameEvent OnFinishedSkill;

        public float SkillDuration;
        public float m_Damage;
        
        
        public abstract void StartSkill();
        public abstract IEnumerator<float> PerformSkill(Transform player);
        public abstract void CastSkill();
        public abstract void CancelSkill();
        public abstract void FinishedSkill();

        public void SetDamage(float baseDamage)
        {
            m_Damage = baseDamage + (baseDamage * damageMultiplier);
        }
    }
}