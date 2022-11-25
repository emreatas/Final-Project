using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] private GameObject AddButtonChild;
    [SerializeField] private GameObject CreateButtonChild;
    
    [SerializeField] private StartScene startScene;
    [SerializeField] private Button button;

    private PlayerSettings m_PlayerSettings;
    
    public void EnableCreateButton(PlayerSettings playerSettings)
    {
        m_PlayerSettings = playerSettings;
        
        //button.onClick.AddListener(startScene.SelectCharacter(m_PlayerSettings.characterType));
        
        
        CreateButtonChild.SetActive(true);
    }

    public void EnableAddButton()
    {
        
        AddButtonChild.SetActive(true);
    }
}
