using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Skills;
using Stat;
using UnityEngine;

public class PlayerSkillSelector : MonoBehaviour
{
    [SerializeField] private PlayerSkillController playerSkillController;
    [SerializeField] private SkillSettingsContainer mageSkillContainer;
    [SerializeField] private SkillSettingsContainer archerSkillContainer;
    [SerializeField] private SkillSettingsContainer warriorSkillContainer;
    
    private void OnEnable()
    {
        AddListeners();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }
    
    private void HandleOnCharacterInitialized(PlayerSettings playerSettings)
    {
        SelectCorrectSkills(playerSettings);
    }

    private void SelectCorrectSkills(PlayerSettings playerSettings)
    {
        switch (playerSettings.characterType)
        {
            case CharacterTypes.Mage:
                SetSkills(mageSkillContainer);
                break;
            case CharacterTypes.Warrior:
                SetSkills(warriorSkillContainer);
                break;
            case CharacterTypes.Archer:
                SetSkills(archerSkillContainer);
                break;
        }
    }

    private void SetSkills(SkillSettingsContainer skillContainer)
    {
        playerSkillController.BasicSkillSettings = skillContainer.Basic1;
        playerSkillController.PrimarySkillSettings = skillContainer.Primary1;
        playerSkillController.SecondarySkillSettings = skillContainer.Secondary1;
    }
    
    private void AddListeners()
    {
        PlayerClass.OnCharacterInitialized.AddListener(HandleOnCharacterInitialized);
    }

    private void RemoveListeners()
    {
        PlayerClass.OnCharacterInitialized.RemoveListener(HandleOnCharacterInitialized);
    }
}
