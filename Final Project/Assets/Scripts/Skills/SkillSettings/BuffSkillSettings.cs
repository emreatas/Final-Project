using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
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
            var pooled = SkillPool.Instance.PoolSkill(prefab, skillController.transform);
            pooled.InitSkill(skillController);
            pooled.SetPositionAndRotation(skillController.transform.position, Quaternion.identity);
        }
    }
}
