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
        [SerializeField] private bool spawnEffectInPlayer;
        public override void StartSkill(PlayerSkillController skillController) { }

        public override void ExecuteSkill(PlayerSkillController skillController)
        {
            Transform parent = FindParent(skillController);
           
            var pooled = SkillPool.Instance.PoolSkill(prefab, parent);
            pooled.SetWorldPositionAndRotation(skillController.transform.position, Quaternion.identity);
            pooled.InitSkill(skillController);
        }

        private Transform FindParent(PlayerSkillController skillController)
        {
            if (spawnEffectInPlayer)
            {
                return skillController.transform;
            }

            return null;
        }
    }
}
