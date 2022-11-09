using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/TestIce")]
    public class TestIceSkill : AbstractSkill
    {
        public override void StartSkill()
        {
            Debug.Log("Start Fire Skill");
        }
        
        public override void CastSkill()
        {
            throw new System.NotImplementedException();
        }

        public override void CancelSkill()
        {
            Debug.Log("Cast Fire Skill");
        }

        public override void OnFinishedSkillAnimation()
        {
            OnFinishedSkill.Invoke();
        }

        public override IEnumerator<float> PerformSkillCoroutine(Transform player)
        {
            throw new System.NotImplementedException();
        }
    }
}