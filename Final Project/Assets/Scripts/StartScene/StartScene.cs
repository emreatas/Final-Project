using System.Collections;
using System.Collections.Generic;
using Stat;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{

    public List<StartScreenCharacter> characters;
    public Transform startCamPos;
    public Transform createCamPos;
    public Camera cam;
    public GameObject startPanel;
    public GameObject createPanel;


    private Dictionary<CharacterTypes, GameObject> m_Characters = new Dictionary<CharacterTypes, GameObject>();

    private void Start()
    {
        InitCharacters();
        
        startPanel.SetActive(true);
        createPanel.SetActive(false);

        cam.transform.position = startCamPos.position;
        cam.transform.rotation = startCamPos.rotation;

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].gameObject.SetActive(false);
        }
    }

    private void InitCharacters()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            m_Characters.Add(characters[i].CharacterType, characters[i].gameObject);
        }
       
    }


    public void NewCharacterButton()
    {
        startPanel.SetActive(false);
        createPanel.SetActive(true);

        cam.transform.position = createCamPos.position;
        cam.transform.rotation = createCamPos.rotation;

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].gameObject.SetActive(false);
        }
    }

    public void SelectCharacter(CharacterTypes selectedCharacterType)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].gameObject.SetActive(false);
        }
        
        m_Characters[selectedCharacterType].gameObject.SetActive(true);
    }

    
    public void BackButton()
    {
        startPanel.SetActive(true);
        createPanel.SetActive(false);

        cam.transform.position = startCamPos.position;
        cam.transform.rotation = startCamPos.rotation;

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].gameObject.SetActive(false);
        }
    }
}


