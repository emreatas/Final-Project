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

        public override void CancelSkill()
        {
            Debug.Log("Cast Fire Skill");
        }

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