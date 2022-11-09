using System;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/TestFire")]
    public class TestFireSkill : AbstractSkill
    {
        public override void RotatePlayer(Action<Vector3> LerpPlayer)
        {
            LerpPlayer(m_Player.position + ShootDirection);
        }

        public override void CastSkill()
        {
            var instansiated = Instantiate(prefab, m_Player.position, Quaternion.identity);
            instansiated.InitializeParams(m_Damage, m_Damage);
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