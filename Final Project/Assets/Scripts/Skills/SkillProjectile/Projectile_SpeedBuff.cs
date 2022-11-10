using System.Collections;
using System.Collections.Generic;
using MEC;
using Stat;
using UnityEngine;

namespace Skills
{
    public class Projectile_SpeedBuff : AbstractProjectile
    {
        [SerializeField] private StatType speedType;
        [SerializeField] private float speedMultiplicator;

        [SerializeField] private float skillduration;
        
        private float m_Speed;
        private AttributeModifier m_Modifier;
        
        protected override void SetStatValues()
        {
            float baseValue = m_CharacterStat.GetValue(speedType);
            m_Speed = baseValue * speedMultiplicator;
        }
        
        public override void FireProjectile()
        {
            AddToCharacterAttributes();
        }

        private void AddToCharacterAttributes()
        {
            m_Modifier = new AttributeModifier(m_Speed, speedType);
            m_CharacterStat.AddModifier(m_Modifier);
        }

        private void RemoveFromCharacterAttributes()
        {
            m_CharacterStat.RemoveModifier(m_Modifier);
        }

        private IEnumerator<float> _EndSkill()
        {
            yield return Timing.WaitForSeconds(skillduration);
            RemoveFromCharacterAttributes();
            Destroy(gameObject);
        }
    }

}
