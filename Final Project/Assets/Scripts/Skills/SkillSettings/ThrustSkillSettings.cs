using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
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
            var pooled = SkillPool.Instance.PoolSkill(prefab);
            pooled.SetPositionAndRotation(
                GetSpawnPosition(skillController.transform), 
                Quaternion.LookRotation(skillController.ShootDirection)
                );
            pooled.InitSkill(skillController);
        }
    }
}
