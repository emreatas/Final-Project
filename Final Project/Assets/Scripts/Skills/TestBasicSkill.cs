using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/TestBasic")]
    public class TestBasicSkill : AbstractSkill
    {
        public override void StartSkill()
        {
            Debug.Log("Start Basic Attack");
        }

        public override void PerformSkill()
        {
            Debug.Log("Perform Basic Attack");
        }

        public override void CancelSkill()
        {
            Debug.Log("Cancel Basic Attack");
        }

        public override void FinishedSkill()
        {
            OnFinishedSkill.Invoke();
        }
    }
}