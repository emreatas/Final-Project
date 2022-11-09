using System;
using System.Collections.Generic;
using MEC;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/Mage/Primary/MeteorShower")]
    public class Skill_MeteorShower : AbstractSkill
    {
        [Header("Meteor")] 
        [SerializeField] private int meteorCount;

        [SerializeField] private float meteorSpawnDelay;
        [SerializeField] private float spawnHeight;
        public override void RotatePlayer(Action<Vector3> LerpPlayer)
        {
        }

        public override void CastSkill()
        {
           InstansiateMeteors();
        }

        public override void ShowSkillIndicator(SkillIndicator skillIndicator, Vector3 shootDirection)
        {
            skillIndicator.InitIndicatorSettings(SkillIndicatorSettings);
            skillIndicator.UpdateIndicatorDirection(shootDirection);
        }

        public override void OnFinishedSkillAnimation()
        {
            base.OnFinishedSkillAnimation();
            OnFinishedSkill.Invoke();
        }

        private void InstansiateMeteors()
        {
            Vector3[] meteorSpawnPositions = GetRandomSpawnPosition();

            Timing.RunCoroutine(_InstansiateMeteors(meteorSpawnPositions));
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
            instansiated.InitializeParams(m_Damage, m_AttackSpeed);
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