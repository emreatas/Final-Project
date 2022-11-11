using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Skills
{
    public class SkillIndicator : MonoBehaviour
    {
        [SerializeField] private Transform radiusTransform;
        [SerializeField] private Image radiusImage;
        
        [SerializeField] private Transform directionTransform;
        [SerializeField] private Image directionImage;

        [SerializeField] private Transform impactTransform;
        [SerializeField] private Image impactImage;

        
        private bool initalizedIndicator;

        private SkillIndicatorSettings m_SkillIndicatorSettings;
        
        public void EnableSkillIndicator()
        {
            gameObject.SetActive(true);
        }

        public void DisableSkillIndicator()
        {
            gameObject.SetActive(false);
            initalizedIndicator = false;
            m_SkillIndicatorSettings = null;
        }

        public void InitIndicatorSettings(SkillIndicatorSettings skillIndicatorSettings)
        {
            if (initalizedIndicator) { return; }
            
            m_SkillIndicatorSettings = Instantiate(skillIndicatorSettings);

            skillIndicatorSettings.InitializeIndicator(radiusTransform, radiusImage, directionTransform, directionImage, impactTransform, impactImage);
            
            EnableSkillIndicator();
        }
        
        public void UpdateIndicatorDirection(Vector3 direction)
        {
            m_SkillIndicatorSettings.UpdateIndicator(transform , directionTransform, impactTransform, direction);
        }
    }

}
