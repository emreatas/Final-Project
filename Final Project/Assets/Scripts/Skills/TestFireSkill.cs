using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/TestFire")]
    public class TestFireSkill : AbstractSkill
    {
        public override void PerformSkill(Vector3 shootDirection)
        {
            
        }
        
        public override void CastSkill()
        {
            
        }

        public override void ShowSkillIndicator(SkillIndicator skillIndicator, Vector3 shootDirection)
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