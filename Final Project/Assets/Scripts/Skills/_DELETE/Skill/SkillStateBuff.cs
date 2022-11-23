using System.Collections;
using System.Collections.Generic;
using MEC;
using Skills;
using Stat;
using UnityEngine;

namespace Skills
{
    public class SkillStateBuff : AbstractSkill
    {
        [SerializeField] private List<SkillBuff> skillBuffs = new List<SkillBuff>();
        
        private List<AttributeModifier> m_Modifier = new List<AttributeModifier>();
        
        protected override void SetStats()
        {
            for (int i = 0; i < skillBuffs.Count; i++)
            {
                float buffAmount = m_CharacterStat.GetValue(skillBuffs[i].buffType) * skillBuffs[i].buffMultiplicator;
                var modifier = new AttributeModifier(buffAmount, skillBuffs[i].buffType);
                m_Modifier.Add(modifier);
            }
        }
        
        public override void FireProjectile(Vector3 direction, Transform target)
        {
            AddToCharacterAttributes();
        }

        private void AddToCharacterAttributes()
        {
            for (int i = 0; i < m_Modifier.Count; i++)
            {
                m_CharacterStat.AddModifier(m_Modifier[i]);
            }
        }

        private void RemoveFromCharacterAttributes()
        {
            for (int i = 0; i < m_Modifier.Count; i++)
            {
                m_CharacterStat.RemoveModifier(m_Modifier[i]);
            }
        }

        protected override IEnumerator<float> _Destroy()
        {
            yield return Timing.WaitForSeconds(lifeTime);
            RemoveFromCharacterAttributes();
            Destroy(gameObject);
        }
    }
}
