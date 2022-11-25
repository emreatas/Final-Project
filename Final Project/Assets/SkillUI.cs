using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Skills
{
    public class SkillUI : MonoBehaviour
    {
        [SerializeField] private Image skillImage;

        private AbstractNewSkillSettings skillSettings;

        public static GameEvent<AbstractNewSkillSettings> OnSelectSkill;
        
        public AbstractNewSkillSettings SkillSettings
        {
            get => skillSettings;
            set => skillSettings = value;
        }

        public void SetSkillIcon(Sprite icon)
        {
            skillImage.sprite = icon;
        }

        public void _SelectSkill()
        {
            OnSelectSkill.Invoke(skillSettings);
        }
    }
}