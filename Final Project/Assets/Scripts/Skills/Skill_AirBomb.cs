using System;
using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/Mage/Primary/AirBomb")]
    public class Skill_AirBomb : AbstractSkill
    {
        public override void RotatePlayer(Action<Vector3> LerpPlayer)
        {
            LerpPlayer(m_Player.position + ShootDirection);
        }
        
        public override void CastSkill()
        {
            var instansiated = Instantiate(prefab, m_Player.position, Quaternion.identity);
            // instansiated.InitializeStats(m_Damage, m_AttackSpeed);
            instansiated.InitializeStats(m_CharacterStat);
            instansiated.FireProjectile(m_ShootDirection);
        }

        public override void ShowSkillIndicator(SkillIndicator skillIndicator, Vector3 shootDirection)
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