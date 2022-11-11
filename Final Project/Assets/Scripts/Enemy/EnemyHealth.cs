using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float health;

        public float Health => health;
        
        public void TakeDamage(float damage)
        {
            health -= damage;

            if (Health <= 0)
            {
                RandomLoot.Instance.CreateLoot(transform.position);
                Destroy(gameObject);
            }
        }
    }
 
}

