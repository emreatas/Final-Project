using System.Collections.Generic;
using MEC;
using ObjectPooling;
using Player;
using UnityEngine;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skills/New/MeteorShowerSettings")]
    public class MeteorShowerSkillSettings : AbstractNewSkillSettings
    {
        [Header("Meteor")] 
        [SerializeField] private int meteorCount;

        [SerializeField] private float meteorSpawnDelay;
        [SerializeField] private float spawnHeight;

        public override void StartSkill(PlayerSkillController skillController) { }

        public override void ExecuteSkill(PlayerSkillController skillController)
        {
            Timing.RunCoroutine(InstansiateMeteorsCO(skillController));
        }
        
        private IEnumerator<float> InstansiateMeteorsCO(PlayerSkillController skillController)
        {
            Vector3[] meteorSpawnPositions = GetRandomSpawnPosition(skillController.transform.position);
            
            for (int i = 0; i < meteorSpawnPositions.Length; i++)
            {
                InstansiateMeteor(skillController, meteorSpawnPositions[i]);
                yield return Timing.WaitForSeconds(meteorSpawnDelay);
            }
        }

        private void InstansiateMeteor(PlayerSkillController skillController, Vector3 spawnPosition)
        {
            var pooled = SkillPool.Instance.PoolSkill(prefab);
            pooled.SetPositionAndRotation(spawnPosition, Quaternion.identity);
            pooled.InitSkill(skillController);
        }

        private Vector3[] GetRandomSpawnPosition(Vector3 playerPosition)
        {
            Vector3[] meteorPositions =new Vector3[meteorCount];
            float radius = SkillIndicatorSettings.radius / 2;
            for (int i = 0; i < meteorCount; i++)
            {
                float randomX = Random.Range(-radius, radius);
                float randomZ = Random.Range(-radius, radius);
                meteorPositions[i] = playerPosition + new Vector3(randomX,spawnHeight , randomZ);
            }

            return meteorPositions;
        }
    }
}