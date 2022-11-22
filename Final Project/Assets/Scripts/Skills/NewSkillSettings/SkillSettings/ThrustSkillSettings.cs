using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/New/ThrustShowerSettings")]
    public class ThrustSkillSettings : AbstractNewSkillSettings
    {
        public override void StartSkill(PlayerSkillController skillController)
        {
            skillController.RotatePlayer();
        }

        public override void ExecuteSkill(PlayerSkillController skillController)
        {
            var instansiated = Instantiate(prefab, skillController.transform);
            instansiated.InitSkill(skillController);
        }
    }
}
