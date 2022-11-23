using System;
using Stat;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float health;
        [SerializeField] private StatType healthType;

        public float Health { get => health; }

        public static GameEvent<float> OnTakeDamage;

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                TakeDamage(10, null);
                Debug.Log("DamageTaken");
            }
        }
        
        private void HandleOnHealthUpdated(CharacterStat characterStats)
        {
            health = characterStats.GetValue(healthType);
        }
        
        public void TakeDamage(float damage, GameObject damageGiver)
        {
            health -= damage;
            OnTakeDamage.Invoke(health);
            
            if (health <= 0)
            {
                // On playerDeath
            }
        }
        
        private void AddListeners()
        {
            PlayerStats.OnCharacterStatsInitialized.AddListener(HandleOnHealthUpdated);
        }
        

        private void RemoveListeners()
        {
            PlayerStats.OnCharacterStatsInitialized.RemoveListener(HandleOnHealthUpdated);
        }
    }
}