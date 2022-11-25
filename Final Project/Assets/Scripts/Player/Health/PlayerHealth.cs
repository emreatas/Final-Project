using System;
using System.Collections.Generic;
using MEC;
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

        private float m_MaxHealth;
        private bool m_IsInitialized = false;

        public static GameEvent<float> OnHealthChanged;

        private CoroutineHandle m_RegenerateHealthCO;
        private CoroutineHandle m_StartHealthRegenTimer;

        private float m_HealthRegenDelay;
        private float m_LastDamageTakenTime;
        
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
            }

            if (health < m_MaxHealth)
            {
                
            }
        }
        
        private void HandleOnHealthUpdated(CharacterStat characterStats)
        {
            m_MaxHealth = characterStats.GetValue(healthType);

            if (!m_IsInitialized)
            {
                m_IsInitialized = true;
                health = m_MaxHealth;
            }
            
            OnHealthChanged.Invoke(GetHealthInPercent());
        }
        
        public void TakeDamage(float damage, GameObject damageGiver)
        {
            if (damageGiver != null) { return; }
            
            health -= damage;

            OnHealthChanged.Invoke(GetHealthInPercent());
            
            if (health <= 0)
            {
                // On playerDeath
            }
        }

        private float GetHealthInPercent()
        {
            return health / m_MaxHealth; 
        }

        IEnumerator<float> UpdateCO()
        {
            if (health < m_MaxHealth)
            {
                if (m_LastDamageTakenTime <= 0)
                {
                                        
                }
                else
                {
                }
            }
            else
            {
                yield return Timing.WaitForSeconds(0.5f);
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