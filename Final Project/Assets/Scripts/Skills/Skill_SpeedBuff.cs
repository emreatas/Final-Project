using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/Mage/Secondary/SpeedBuff")]
    public class Skill_SpeedBuff : AbstractSkill
    {
        public override void RotatePlayer(Action<Vector3> LerpPlayer)
        {
        }
        
        public override void CastSkill()
        {
            var instansiated = Instantiate(prefab, m_Player);
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
            base.OnFinishedSkillAnimation();
            OnFinishedSkill.Invoke();
        }
    }

}

