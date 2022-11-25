using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/SkillContainer")]
    public class SkillSettingsContainer : ScriptableObject
    {
        [Header("Basic Attack")]
        public AbstractNewSkillSettings Combo1;
        public AbstractNewSkillSettings Combo2;
        public AbstractNewSkillSettings Combo3;
        
        [Header("Primary Skills")]
        public AbstractNewSkillSettings Primary1;
        public AbstractNewSkillSettings Primary2;
        public AbstractNewSkillSettings Primary3;
        
        [Header("Secondary Skills")]
        public AbstractNewSkillSettings Secondary1;
        public AbstractNewSkillSettings Secondary2;
        public AbstractNewSkillSettings Secondary3;
    }
}