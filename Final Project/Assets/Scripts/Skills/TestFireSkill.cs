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

        public override void PerformSkill()
        {
            Debug.Log("Perform Fire Skill");
        }

        public override void CancelSkill()
        {
            Debug.Log("Cast Fire Skill");
        }
    }
}