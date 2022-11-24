using System;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public EnemyScriptable enemyStats;
        public Slider healthBar;
        public EnemyStateManager enemyStateManager;

        private float health;

        private void Start()
        {
            health = enemyStats.health;
            healthBar.maxValue = health;
            healthBar.value = health;
        }


        public float Health { get; }

        public void TakeDamage(float damage, GameObject damageGiver)
        {
            health -= damage;
            healthBar.value = health;
            enemyStateManager.SwitchState(enemyStateManager.HitReactionState);
            if (health <= 0)
            {
                if (damageGiver.TryGetComponent(out PlayerLevel playerLevel))
                {
                    playerLevel.AddExperience(enemyStats.exp);
                }
            
                RandomLoot.Instance.CreateLoot(transform.position);
                Destroy(gameObject);
            }
        }
    }
}