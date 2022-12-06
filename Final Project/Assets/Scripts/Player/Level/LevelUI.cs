using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private Image experienceSlider;
        [SerializeField] private TextMeshProUGUI levelText;

        private PlayerLevelSettings m_PlayerLevelSettings;

        private void Start()
        {
            AddListeners();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void HandleOnCharacterInitialized(PlayerSettings playerSettings)
        {
            m_PlayerLevelSettings = playerSettings.LevelSettings;
            Data.instance.CharacterLevelLoad();
            SetSkillUI();
        }

        private void HandleOnPlayerXPIncreased()
        {
            SetSkillUI();
        }

        private void SetSkillUI()
        {
            levelText.text = $"LEVEL : {m_PlayerLevelSettings.level}";
            experienceSlider.fillAmount = m_PlayerLevelSettings.GetExperienceInPercent();
        }

        private void AddListeners()
        {
            PlayerClass.OnCharacterInitialized.AddListener(HandleOnCharacterInitialized);
            PlayerLevel.OnPlayerExperienceIncreased.AddListener(HandleOnPlayerXPIncreased);
        }

        private void RemoveListeners()
        {
            PlayerClass.OnCharacterInitialized.RemoveListener(HandleOnCharacterInitialized);
            PlayerLevel.OnPlayerExperienceIncreased.RemoveListener(HandleOnPlayerXPIncreased);
        }
    }
}

