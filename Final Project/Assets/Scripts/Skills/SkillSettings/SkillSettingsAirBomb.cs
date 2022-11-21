using System;
using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/Mage/Primary/AirBomb")]
    public class SkillSettingsAirBomb : AbstractSkillSettings
    {
        public override void StartSkill()
        {
            m_LerpPlayerRotationAction(m_Player.position + m_ShootDirection);
        }
        
        public override void CastSkill()
        {
            var instansiated = Instantiate(prefab, m_Player.position, Quaternion.identity);
            // instansiated.InitializeStats(m_Damage, m_AttackSpeed);
            instansiated.InitializeStats(m_CharacterStat);
            instansiated.FireProjectile(m_ShootDirection);
        }

        public override void ShowSkillIndicator(DecalSkillIndicator skillIndicator, Vector3 shootDirection)
        {
            skillIndicator.InitIndicatorSettings(SkillIndicatorSettings);
            skillIndicator.UpdateIndicatorDirection(shootDirection);
        }
    }
}