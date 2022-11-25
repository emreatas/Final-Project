using System;
using System.Collections;
using System.Collections.Generic;
using JSONSystem;
using UnityEditor;
using UnityEngine;
using PlayerSettings = Player.PlayerSettings;


public class CharacterCreator : MonoBehaviour
{
    [SerializeField] private CharacterButton[] characterButtons;
    [SerializeField] private Transform buttonParentTransform;
    
    [SerializeField] private PlayerSettings playerClass;
    
    
    private List<PlayerSettings> characters = new List<PlayerSettings>();

    private void Start()
    {
        /*
        JSONSaveSystem.SaveToJSON(playerClass, true);
        characters = JSONSaveSystem.ReadFromJson<PlayerSettings>();
        Debug.Log(characters.Count);
        CreateButtons();
        */
    }

    private void CreateButtons()
    {
        int i;
        
        for (i = 0; i < characters.Count; i++)
        {
            characterButtons[i].EnableCreateButton(characters[i]);
        }
        
        for (i = i; i < characterButtons.Length; i++)
        {
          characterButtons[i].EnableAddButton();
        }
    }
}
