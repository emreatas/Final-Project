using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartSceneData : MonoBehaviour
{


    private List<CharacterData> data = new List<CharacterData>();
    private List<CharacterData> savedData = new List<CharacterData>();

    public List<CharacterButtons> characterButtons = new List<CharacterButtons>();

    public List<Characters> characters = new List<Characters>();

    public GameObject startGameButton;

    private int id;
    private int ctype;
    private Stat.CharacterTypes selectedType;



    private void Start()
    {


        LoadData();
    }

    public void SaveCharacterData()
    {

        JSONSystem.JSONSaveSystem.SaveToJSON(data, true, "Characters");

    }

    public void LoadData()
    {
        savedData = JSONSystem.JSONSaveSystem.ReadFromJson<CharacterData>("Characters");

        if (savedData.Count <= 0)
        {
            for (int i = 0; i < characterButtons.Count; i++)
            {
                characterButtons[i].Icon.SetActive(false);
                characterButtons[i].text.SetActive(false);
                characterButtons[i].charactr.enabled = false;
                characterButtons[i].caharacterButton.SetActive(false);
                characterButtons[i].plusButton.SetActive(true);
                startGameButton.SetActive(false);
            }

            return;
        }

        for (int i = 0; i < savedData.Count; i++)
        {
            characterButtons[i].btn.id = savedData[i].characterID;
            characterButtons[i].btn.characterType = savedData[i].characterType;
            characterButtons[i].charactr.text = ((Stat.CharacterTypes)savedData[i].characterType).ToString();
            characterButtons[i].charactr.enabled = true;
            characterButtons[i].text.SetActive(true);
            characterButtons[i].plusButton.SetActive(false);
            characterButtons[i].caharacterButton.SetActive(true);

            characterButtons[i].Icon.SetActive(true);
            startGameButton.SetActive(true);

        }

        for (int j = savedData.Count; j < characterButtons.Count; j++)
        {
            characterButtons[j].Icon.SetActive(false);
            characterButtons[j].text.SetActive(false);
            characterButtons[j].charactr.enabled = false;
            characterButtons[j].caharacterButton.SetActive(false);

            characterButtons[j].plusButton.SetActive(true);

        }


    }

    public void CreateSelectedCharacter(int type)
    {
        selectedType = (Stat.CharacterTypes)type;
    }

    public void SelectCharacter(StartCharacterBtnData ct)
    {
        int a = ct.characterType;

        PlayerPrefs.SetInt("CharacterID", ct.id);
        PlayerPrefs.SetInt("CharacterType", ct.characterType);

        Debug.Log("qqq" + PlayerPrefs.GetInt("CharacterID", 0));
        Debug.Log("www" + (Stat.CharacterTypes)PlayerPrefs.GetInt("CharacterType", 0));

        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].type == (Stat.CharacterTypes)a)
            {
                for (int j = 0; j < characters.Count; j++)
                {
                    characters[j].character.SetActive(false);
                }
                characters[i].character.SetActive(true);
            }
        }
    }




    public void CreateCharacter()
    {
        data.Clear();
        LoadData();

        for (int i = 0; i < savedData.Count; i++)
        {
            data.Add(savedData[i]);
        }

        PlayerPrefs.SetInt("CharacterID", PlayerPrefs.GetInt("CharacterID", 0) + 1);
        id = PlayerPrefs.GetInt("CharacterID", 0);
        ctype = (int)selectedType;

        CharacterData cd = new CharacterData();

        cd.characterID = id;
        cd.characterType = ctype;

        data.Add(cd);

        SaveCharacterData();

        Start();
    }

}

[System.Serializable]
public class CharacterData
{
    public int characterID;
    public int characterType;
}

[System.Serializable]
public class CharacterButtons
{
    public StartCharacterBtnData btn;
    public GameObject caharacterButton;
    public Stat.CharacterTypes CharacterType;
    public GameObject Icon;
    public GameObject text;
    public TextMeshProUGUI charactr;
    public GameObject plusButton;
}

[System.Serializable]
public class Characters
{
    public Stat.CharacterTypes type;
    public GameObject character;

}