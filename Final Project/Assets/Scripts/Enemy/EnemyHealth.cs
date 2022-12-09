using System;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public Target target;
        public EnemyScriptable enemyStats;
        public Slider healthBar;
        public EnemyStateManager enemyStateManager;
        private EnemyPooler objectPooler;

        private float health;

        private void Start()
        {
            health = enemyStats.health;
            healthBar.maxValue = health;
            healthBar.value = health;
            objectPooler = EnemyPooler.Instance;
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
                target.Destroyed();
                this.gameObject.SetActive(false);
                objectPooler.IsEnemyDisabled(this.tag);
            }
        }
    }
}