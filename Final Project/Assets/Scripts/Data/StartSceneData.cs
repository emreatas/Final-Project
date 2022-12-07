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
                characterButtons[i].plusButton.SetActive(true);
            }

            return;
        }

        for (int i = 0; i < savedData.Count; i++)
        {
            characterButtons[i].btn.id = savedData[i].characterID;
            characterButtons[i].charactr.text = ((Stat.CharacterTypes)savedData[i].characterType).ToString();
            characterButtons[i].text.SetActive(true);
            characterButtons[i].plusButton.SetActive(false);
            characterButtons[i].Icon.SetActive(true);

        }

        for (int j = savedData.Count; j < characterButtons.Count; j++)
        {
            characterButtons[j].Icon.SetActive(false);
            characterButtons[j].text.SetActive(false);
            characterButtons[j].charactr.enabled = false;
            characterButtons[j].plusButton.SetActive(true);
        }


    }

    public void SelectCharacter(int ct)
    {
        selectedType = (Stat.CharacterTypes)ct;
    }

    public void CreateCharacter()
    {
        id = PlayerPrefs.GetInt("CharacterID", 0) + 1;
        ctype = (int)selectedType;

        CharacterData cd = new CharacterData();

        cd.characterID = id;
        cd.characterType = ctype;

        data.Add(cd);

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
    public GameObject Icon;
    public GameObject text;
    public TextMeshProUGUI charactr;
    public GameObject plusButton;
}