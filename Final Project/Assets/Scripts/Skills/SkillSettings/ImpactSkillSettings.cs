using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using Player;
using Skills;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/New/SkillSettings")]
    public class ImpactSkillSettings : AbstractNewSkillSettings
    {
        [SerializeField] private AbstractNewSkill playerParticle;
        
        [SerializeField] private bool spawnStartEffectInWeapon;
        
        [SerializeField] private bool setRotationToShootDirection;

        public override void StartSkill(PlayerSkillController skillController)
        {
            skillController.RotatePlayer();
            Transform parent = FindParent(skillController);

            var pooled = SkillPool.Instance.PoolSkill(playerParticle,parent);
            pooled.SetLocalPosition(Vector3.zero, Quaternion.identity);
            pooled.InitSkill(skillController);
        }

        public override void ExecuteSkill(PlayerSkillController skillController)
        {
            Vector3 skillExecutePos = skillController.transform.position + 
                                      SkillIndicatorSettings.radius/2 * skillController.ShootDirection;
            
            var pooled = SkillPool.Instance.PoolSkill(prefab);
            pooled.SetWorldPositionAndRotation(skillExecutePos, FindShootDirection(skillController));
            pooled.InitSkill(skillController);
            
        }

        private Transform FindParent(PlayerSkillController skillController)
        {
            if (spawnStartEffectInWeapon)
            {
                return skillController.WeaponSelector.GetActiveWeaponTransform();
            }
            else
            {
                return skillController.transform;
            }
        }

        private Quaternion FindShootDirection(PlayerSkillController skillController)
        {
            if (setRotationToShootDirection)
            {
                return Quaternion.LookRotation(skillController.ShootDirection);
            }
            else
            {
                return Quaternion.identity;
            }
        }
    }
}
