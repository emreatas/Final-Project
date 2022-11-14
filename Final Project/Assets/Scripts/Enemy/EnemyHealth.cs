using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        private EnemyScriptable enemyStats;
        public Slider healthBar;

        public float Health => enemyStats.health;
        
        public void TakeDamage(float damage)
        {
            enemyStats.health -= damage;
            healthBar.value = Health;
            if (Health <= 0)
            {
                RandomLoot.Instance.CreateLoot(transform.position);
                Destroy(gameObject);
            }
        }
    }
 
}

