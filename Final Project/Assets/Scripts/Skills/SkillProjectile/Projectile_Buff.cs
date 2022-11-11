using System.Collections;
using System.Collections.Generic;
using MEC;
using Skills;
using Stat;
using UnityEngine;

namespace Skills
{
    public class Projectile_Buff : AbstractProjectile
    {
        [SerializeField] private StatType buffType;
        [SerializeField] private float buffMultiplicator;
        
        private float m_BuffValue;
        private AttributeModifier m_Modifier;
        
        protected override void SetStatValues()
        {
            float baseValue = m_CharacterStat.GetValue(buffType);
            m_BuffValue = baseValue * buffMultiplicator;
        }
        
        public override void FireProjectile()
        {
            AddToCharacterAttributes();
        }

        private void AddToCharacterAttributes()
        {
            m_Modifier = new AttributeModifier(m_BuffValue, buffType);
            m_CharacterStat.AddModifier(m_Modifier);
        }

        private void RemoveFromCharacterAttributes()
        {
            m_CharacterStat.RemoveModifier(m_Modifier);
        }

        protected override IEnumerator<float> _Destroy()
        {
            yield return Timing.WaitForSeconds(lifeTime);
            RemoveFromCharacterAttributes();
            Destroy(gameObject);
        }

    }
}
