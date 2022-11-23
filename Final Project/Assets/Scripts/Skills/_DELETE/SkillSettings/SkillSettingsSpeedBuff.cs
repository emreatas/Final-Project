using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/Mage/Secondary/SpeedBuff")]
    public class SkillSettingsSpeedBuff : AbstractSkillSettings
    {
        public override void CastSkill()
        {
            var instansiated = Instantiate(prefab, m_Player);
            // instansiated.InitializeStats(m_Damage, m_AttackSpeed);
            instansiated.InitializeStats(m_CharacterStat);
            instansiated.FireProjectile();
        }
        
        
    }

}

