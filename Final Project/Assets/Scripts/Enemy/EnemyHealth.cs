using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public EnemyScriptable enemyStats;
        public Slider healthBar;
        public EnemyStateManager enemyStateManager;

        public float Health => enemyStats.health;
        
        public void TakeDamage(float damage)
        {
            enemyStats.health -= damage;
            healthBar.value = Health;
            enemyStateManager.SwitchState(enemyStateManager.HitReactionState);
            if (Health <= 0)
            {
                RandomLoot.Instance.CreateLoot(transform.position);
                Destroy(gameObject);
            }
        }
    }
}

