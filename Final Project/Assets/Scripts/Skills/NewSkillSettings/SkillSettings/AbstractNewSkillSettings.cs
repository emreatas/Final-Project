using System.Collections;
using Player;
using Skills;
using UnityEngine;

namespace Skills
{
    public abstract class AbstractNewSkillSettings : ScriptableObject, ISkillBehaviour
    {
        [Header("Skill")] 
        public string SkillName;
        public PlayerSkillType skillType;
        public Sprite SkillIcon;
        [TextArea(10,100)] 
        public string SkillDescription;
        
        [Header("Animations Name")]
        public string AnimationName;
        
        [Header("Projectile Prefab")]
        [SerializeField] protected AbstractNewSkill prefab;
        
        [Header("Skill Indicator")]
        public SkillIndicatorSettings SkillIndicatorSettings;

        public abstract void StartSkill(PlayerSkillController skillController);
        public abstract void ExecuteSkill(PlayerSkillController skillController);
    }
}
