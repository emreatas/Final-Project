using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerManaUI : MonoBehaviour
    {
        [SerializeField] private Image manaSlider;

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }
        
        private void HandleOnUseMana(float currentMana)
        {
            manaSlider.fillAmount = currentMana;
        }
        
        private void AddListeners()
        {
            PlayerMana.OnUseMana.AddListener(HandleOnUseMana);
        }

        private void RemoveListeners()
        {
            PlayerMana.OnUseMana.RemoveListener(HandleOnUseMana);
        }
    }
}
