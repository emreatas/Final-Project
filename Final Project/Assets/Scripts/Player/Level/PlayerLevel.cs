using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerLevel : MonoBehaviour
    {
        [SerializeField] private PlayerLevelSettings levelSettings;

        public static GameEvent OnPlayerLeveldUp;
        public static GameEvent OnPlayerExperienceIncreased;
        
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
            if (Input.GetKeyDown(KeyCode.T))
            {
                AddExperience(50);
            }
        }

        public void AddExperience(float experienceAmount)
        {
            levelSettings.AddExperience(experienceAmount);
            OnPlayerExperienceIncreased.Invoke();
        }
        
        private void HandleOnPlayerLevelUp()
        {
            OnPlayerLeveldUp.Invoke();
        }
        
        private void AddListeners()
        {
            levelSettings.OnPlayerLeveldUp.AddListener(HandleOnPlayerLevelUp);
        }

        
        private void RemoveListeners()
        {
            levelSettings.OnPlayerLeveldUp.AddListener(HandleOnPlayerLevelUp);
        }
    }
}