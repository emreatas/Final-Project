using System.Collections;
using System.Collections.Generic;
using MEC;
using Skills;
using Stat;
using UnityEngine;

namespace Skills
{
    public class Projectile_Shield : AbstractProjectile
    {
        [SerializeField] private StatType armorType;
        [SerializeField] private float armorMultiplicator;

        [SerializeField] private float armorDuration;
        
        private float m_Armor;
        private AttributeModifier m_Modifier;
        
        protected override void SetStatValues()
        {
            float baseValue = m_CharacterStat.GetValue(armorType);
            m_Armor = baseValue * armorMultiplicator;
        }
        
        public override void FireProjectile()
        {
            AddToCharacterAttributes();
        }

        private void AddToCharacterAttributes()
        {
            m_Modifier = new AttributeModifier(m_Armor, armorType);
            m_CharacterStat.AddModifier(m_Modifier);
        }

        private void RemoveFromCharacterAttributes()
        {
            m_CharacterStat.RemoveModifier(m_Modifier);
        }

        private IEnumerator<float> _EndSkill()
        {
            yield return Timing.WaitForSeconds(armorDuration);
            RemoveFromCharacterAttributes();
            Destroy(gameObject);
        }

    }
}
