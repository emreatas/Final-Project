using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using Player;
using Skills;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/New/SkillSettings")]
    public class SkillSettings : AbstractNewSkillSettings
    {
        [SerializeField] private AbstractNewSkill playerParticle;

        public override void StartSkill(PlayerSkillController skillController)
        {
            var pooled = SkillPool.Instance.PoolSkill(playerParticle, skillController.WeaponSelector.GetActiveWeaponTransform());
            pooled.SetPositionAndRotation(skillController.transform.position, Quaternion.identity);
            pooled.InitSkill(skillController);
        }

        public override void ExecuteSkill(PlayerSkillController skillController)
        {
            Vector3 skillExecutePos = skillController.transform.position + 
                                      SkillIndicatorSettings.radius/2 * skillController.ShootDirection;
            
            var pooled = SkillPool.Instance.PoolSkill(prefab);
            pooled.SetPositionAndRotation(skillExecutePos, Quaternion.identity);
            pooled.InitSkill(skillController);
            
        }
    }
}
