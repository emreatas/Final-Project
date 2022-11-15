using System;
using System.Collections;
using System.Collections.Generic;
using Skills;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/Mage/Secondary/Shield")]
    public class SkillSettingsShield : AbstractSkillSettings
    {
        
        public override void CastSkill()
        {
            var instansiated = Instantiate(prefab, m_Player.position, Quaternion.identity, m_Player);
            // instansiated.InitializeStats(m_Damage, m_AttackSpeed);
            instansiated.InitializeStats(m_CharacterStat);
            instansiated.FireProjectile();
        }

        public override void ShowSkillIndicator(DecalSkillIndicator skillIndicator, Vector3 shootDirection)
        {
            skillIndicator.InitIndicatorSettings(SkillIndicatorSettings);
            skillIndicator.UpdateIndicatorDirection(shootDirection);
        }

        public override void OnFinishedSkillAnimation()
        {
            OnFinishedSkill.Invoke();
        }
    }
 
}
