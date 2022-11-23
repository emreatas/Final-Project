using System;
using Stat;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;

namespace Player
{
    public class PlayerHeatlhUI : MonoBehaviour
    {
        [SerializeField] private Image healthSlider;
  
        [SerializeField] private StatType healthType;

        private float maxHealth = 0;

        private bool IsInitialized = false;
        
        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }
        
        private void HandleOnUpdateHealth(float currentHealth)
        {
            Debug.Log("On Update Heatlh");
            healthSlider.fillAmount = currentHealth / maxHealth;
        }
        
        private void HandleOnHealthUpdated(CharacterStat characterStat)
        {
            maxHealth = characterStat.GetValue(healthType);
            Debug.Log("Hola " + maxHealth);

            if (!IsInitialized)
            {
                IsInitialized = true;
                HandleOnUpdateHealth(maxHealth);
            }
        }
        
        private void AddListeners()
        {
            PlayerHealth.OnTakeDamage.AddListener(HandleOnUpdateHealth);
            PlayerStats.OnCharacterStatsInitialized.AddListener(HandleOnHealthUpdated);
        }

        private void RemoveListeners()
        {
            PlayerHealth.OnTakeDamage.RemoveListener(HandleOnUpdateHealth);
            PlayerStats.OnCharacterStatsInitialized.RemoveListener(HandleOnHealthUpdated);
        }
    }
}