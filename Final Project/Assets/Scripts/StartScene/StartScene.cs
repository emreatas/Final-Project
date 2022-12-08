using System.Collections;
using System.Collections.Generic;
using Player;
using SceneSystem;
using Stat;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{

    [SerializeField] private SceneHandler sceneHandler;
    [SerializeField] private PlayerSettings playerSettings;

    public List<StartScreenCharacter> characters;
    public Transform startCamPos;
    public Transform createCamPos;
    public Camera cam;
    public GameObject startPanel;
    public GameObject createPanel;

    public List<GameObject> charactersss = new List<GameObject>();


    private Dictionary<CharacterTypes, GameObject> m_Characters = new Dictionary<CharacterTypes, GameObject>();

    private StartScreenCharacter m_SelectedCharacter;

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

    public void OpenCharacter(int a)
    {
        for (int i = 0; i < charactersss.Count; i++)
        {
            charactersss[i].gameObject.SetActive(false);
        }
        charactersss[a].SetActive(true);
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

    public void SelectCharacter(int index)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].gameObject.SetActive(false);
        }
        characters[index].gameObject.SetActive(true);
        m_SelectedCharacter = characters[index];

        // m_Characters[selectedCharacterType].gameObject.SetActive(true);
    }

    public void StartGame()
    {

        sceneHandler.LoadGameScene();

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


