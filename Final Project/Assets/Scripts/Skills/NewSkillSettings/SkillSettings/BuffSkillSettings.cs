using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/New/BuffSettings")]
    public class BuffSkillSettings : AbstractNewSkillSettings
    {
        public override void StartSkill(PlayerSkillController skillController) { }

        public override void ExecuteSkill(PlayerSkillController skillController)
        {
            Instantiate(prefab, skillController.transform);
        }
    }
}
