using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Stat;
using UnityEngine;

public class PlayerModelSelector : MonoBehaviour
{
    [SerializeField] private GameObject mageGO;
    [SerializeField] private GameObject archerGO;
    [SerializeField] private GameObject warriorGO;
    
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
        EnableSelectedCharacter(playerSettings);
    }

    private void EnableSelectedCharacter(PlayerSettings playerSettings)
    {
        switch (playerSettings.characterType)
        {
            case CharacterTypes.Mage:
                mageGO.SetActive(true);
                break;
            case CharacterTypes.Warrior:
                warriorGO.SetActive(true);
                break;
            case CharacterTypes.Archer:
                archerGO.SetActive(true);
                break;
        }
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
