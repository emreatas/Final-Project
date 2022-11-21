using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/Warrior/Basic")]
    public class SkillSettings_Warrior_Basic : AbstractAttackSettings
    {
        [SerializeField] private int Combo;

        [SerializeField] private ParticleSystem firstSlashParticle;
        [SerializeField] private ParticleSystem secondSlashParticle;
        [SerializeField] private ParticleSystem thirdSlashParticle;

        private ParticleSystem firstSplash;
        private ParticleSystem secondSplash;
        private ParticleSystem thirdSplash;
        
        public override void StartSkill()
        {
            Combo = m_ComboCount;
        }

        public override void CastSkill()
        {
            PlaySlashParticle();
        }

        private void PlaySlashParticle()
        {
            if (m_ComboCount == 1)
            {
                if (firstSplash == null)
                {
                    firstSplash = Instantiate(firstSlashParticle,m_Player);
                }
                else
                {
                    firstSplash.gameObject.SetActive(true);
                }
            }
            else if (m_ComboCount == 2)
            {
                if (secondSplash == null)
                {
                    secondSplash = Instantiate(secondSlashParticle,m_Player);
                }
                else
                {
                    secondSplash.gameObject.SetActive(true);
                }
            }
            else
            {
                if (thirdSplash == null)
                {
                    thirdSplash = Instantiate(thirdSlashParticle,m_Player);
                }
                else
                {
                    thirdSplash.gameObject.SetActive(true);
                }
            }
        }
    }
}

