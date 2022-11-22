using System.Collections;
using System.Collections.Generic;
using MEC;
using Stat;
using UnityEngine;

namespace Skills
{
    public class BuffSkill : AbstractNewSkill
    {
        [SerializeField] private List<SkillBuff> skillBuffs = new List<SkillBuff>();
        
        private List<AttributeModifier> m_Modifier = new List<AttributeModifier>();

        protected override void Start()
        {
            base.Start();
            
            for (int i = 0; i < skillBuffs.Count; i++)
            {
                float buffAmount = m_PlayerSkillController.PlayerStats.GetValue(skillBuffs[i].buffType) * skillBuffs[i].buffMultiplicator;
                var modifier = new AttributeModifier(buffAmount, skillBuffs[i].buffType);
                m_Modifier.Add(modifier);
            }
            
            AddToCharacterAttributes();
        }
        
        protected override IEnumerator<float> _Destroy()
        {
            yield return Timing.WaitForSeconds(lifeTime);
            RemoveFromCharacterAttributes();
            Destroy(gameObject);
        }

        
        private void AddToCharacterAttributes()
        {
            for (int i = 0; i < m_Modifier.Count; i++)
            {
                m_PlayerSkillController.PlayerStats.CharacterStats.AddModifier(m_Modifier[i]);
            }
        }
        
        private void RemoveFromCharacterAttributes()
        {
            for (int i = 0; i < m_Modifier.Count; i++)
            {
                m_PlayerSkillController.PlayerStats.CharacterStats.RemoveModifier(m_Modifier[i]);
            }
        }
    }

}
