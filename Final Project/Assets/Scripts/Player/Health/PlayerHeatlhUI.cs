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
            healthSlider.fillAmount = currentHealth;
        }
        
        private void AddListeners()
        {
            PlayerHealth.OnHealthChanged.AddListener(HandleOnUpdateHealth);
        }

        private void RemoveListeners()
        {
            PlayerHealth.OnHealthChanged.RemoveListener(HandleOnUpdateHealth);
        }
    }
}