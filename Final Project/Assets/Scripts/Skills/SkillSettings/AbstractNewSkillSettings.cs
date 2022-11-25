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

        public float manaCost;
        
        [Header("Animations Name")]
        public string AnimationName;
        
        [Header("Projectile Prefab")]
        [SerializeField] protected AbstractNewSkill prefab;

        [SerializeField] private Vector3 skillSpawnOffset;
        
        [Header("Skill Indicator")]
        public SkillIndicatorSettings SkillIndicatorSettings;

        protected Vector3 GetSpawnPosition(Transform playerTransform)
        {
            return playerTransform.position + GetLocalSpawnOffset(playerTransform);
        }
        
        private Vector3 GetLocalSpawnOffset(Transform playerTransform)
        {
            return playerTransform.right * skillSpawnOffset.x + 
                   playerTransform.up * skillSpawnOffset.y +
                   playerTransform.forward * skillSpawnOffset.z;
        } 
        
        public abstract void StartSkill(PlayerSkillController skillController);
        public abstract void ExecuteSkill(PlayerSkillController skillController);
    }
}
