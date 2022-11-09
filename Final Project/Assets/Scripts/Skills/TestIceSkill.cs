using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/TestIce")]
    public class TestIceSkill : AbstractSkill
    {
        
        public override void CastSkill()
        {
            throw new System.NotImplementedException();
        }
        
        public override void OnFinishedSkillAnimation()
        {
            OnFinishedSkill.Invoke();
        }
        
    }
}