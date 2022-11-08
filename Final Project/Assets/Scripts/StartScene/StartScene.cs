using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{

    public List<GameObject> characters;
    public Transform startCamPos;
    public Transform createCamPos;
    public Camera cam;
    public GameObject startPanel;
    public GameObject createPanel;


    private void Start()
    {
        startPanel.SetActive(true);
        createPanel.SetActive(false);

        cam.transform.position = startCamPos.position;
        cam.transform.rotation = startCamPos.rotation;

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].SetActive(false);
        }
    }

    public void SelectCharacter(int characterIndex)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].SetActive(false);
        }
        characters[characterIndex].SetActive(true);
    }



    public void NewCharacterButton()
    {
        startPanel.SetActive(false);
        createPanel.SetActive(true);

        cam.transform.position = createCamPos.position;
        cam.transform.rotation = createCamPos.rotation;
    }

    public void SelectNewCharacter(int characterIndex)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].SetActive(false);
        }
        characters[characterIndex].SetActive(true);

        if (true)
        {

        }
    }



}


