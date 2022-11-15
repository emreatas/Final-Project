using System;
using System.Collections.Generic;
using MEC;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/Mage/Primary/MeteorShower")]
    public class SkillSettingsMeteorShower : AbstractSkillSettings
    {
        [Header("Meteor")] 
        [SerializeField] private int meteorCount;

        [SerializeField] private float meteorSpawnDelay;
        [SerializeField] private float spawnHeight;

        public override void CastSkill()
        {
            Vector3[] meteorSpawnPositions = GetRandomSpawnPosition();

            Timing.RunCoroutine(_InstansiateMeteors(meteorSpawnPositions));
        }

        public override void ShowSkillIndicator(DecalSkillIndicator skillIndicator, Vector3 shootDirection)
        {
            skillIndicator.InitIndicatorSettings(SkillIndicatorSettings);
            skillIndicator.UpdateIndicatorDirection(shootDirection);
        }

        public override void OnFinishedSkillAnimation()
        {
            OnFinishedSkill.Invoke();
        }
        
        private IEnumerator<float> _InstansiateMeteors(Vector3[] meteorSpawnPositions)
        {
            for (int i = 0; i < meteorCount; i++)
            {
                InstansiateMeteor(meteorSpawnPositions[i]);
                yield return Timing.WaitForSeconds(meteorSpawnDelay);
            }
        }

        private void InstansiateMeteor(Vector3 spawnPosition)
        {
            var instansiated = Instantiate(prefab, spawnPosition, Quaternion.identity);
            instansiated.InitializeStats(m_CharacterStat);
            instansiated.FireProjectile();
        }

        private Vector3[] GetRandomSpawnPosition()
        {
            Vector3[] meteorPositions =new Vector3[meteorCount];
            float radius = SkillIndicatorSettings.radius / 2;
            for (int i = 0; i < meteorCount; i++)
            {
                float randomX = Random.Range(-radius, radius);
                float randomZ = Random.Range(-radius, radius);
                meteorPositions[i] = m_Player.position + new Vector3(randomX,spawnHeight , randomZ);
            }

            return meteorPositions;
        }
    }
}