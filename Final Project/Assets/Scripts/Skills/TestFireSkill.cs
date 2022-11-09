using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/TestFire")]
    public class TestFireSkill : AbstractSkill
    {
        public override void StartSkill()
        {
            Debug.Log("Start Fire Skill");
        }

        public override void CastSkill()
        {
            throw new System.NotImplementedException();
        }

        public override void PerformSkill(Vector3 shootDirection)
        {
            
        }

        public override void CancelSkill()
        {
            Debug.Log("Cast Fire Skill");
        }

        public override void FinishedSkill()
        {
            OnFinishedSkill.Invoke();
        }

        public override IEnumerator<float> SkillCoroutine(Transform player)
        {
            throw new System.NotImplementedException();
        }
    }
}