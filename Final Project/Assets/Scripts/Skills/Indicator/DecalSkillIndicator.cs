using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Skills
{
    public class DecalSkillIndicator : MonoBehaviour
    {
        [SerializeField] private DecalProjector radiusDecal;
        [SerializeField] private DecalProjector directionDecal;
        [SerializeField] private DecalProjector impactDecal;

        [SerializeField] private Transform directionParent;
        
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
            
            m_SkillIndicatorSettings = skillIndicatorSettings;

            m_SkillIndicatorSettings.InitializeIndicator(radiusDecal, directionDecal, impactDecal,directionParent);
            
            EnableSkillIndicator();
        }
        
        public void UpdateIndicatorDirection(Vector3 direction)
        {
            m_SkillIndicatorSettings.UpdateIndicator(transform , directionParent, impactDecal.transform, direction);
        }
    }
}
