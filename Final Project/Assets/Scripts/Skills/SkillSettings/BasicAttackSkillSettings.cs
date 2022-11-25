using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using Player;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/New/WarriorAttack")]
    public class BasicAttackSkillSettings : AbstractNewSkillSettings
    {
        [SerializeField] private AbstractNewSkill firstComboSkill;
        [SerializeField] private AbstractNewSkill secondComboSkill;
        [SerializeField] private AbstractNewSkill thirdComboSkill;
        
        private int m_ComboCount;
        
        public override void StartSkill(PlayerSkillController skillController)
        {
            skillController.RotatePlayer();
            m_ComboCount = skillController.PlayerAnimationController.GetComboCount;
        }

        public override void ExecuteSkill(PlayerSkillController skillController)
        {
            if (m_ComboCount == 1)
            {
                PoolSkill(skillController, ref firstComboSkill);
            }
            else if (m_ComboCount == 2)
            {
                PoolSkill(skillController, ref secondComboSkill);
            }
            else 
            {
                PoolSkill(skillController, ref thirdComboSkill);
            }
        }

        private void PoolSkill(PlayerSkillController skillController, ref AbstractNewSkill skill)
        {
            var pooled = SkillPool.Instance.PoolSkill(skill);
            pooled.SetLocalPosition(skillController.transform.position, Quaternion.LookRotation(skillController.transform.forward));
            pooled.InitSkill(skillController);
        }
    }

}
