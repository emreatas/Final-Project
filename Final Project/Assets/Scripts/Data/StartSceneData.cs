using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneData : MonoBehaviour
{
    public GameObject CharacterButton;
    public GameObject addButton;

    public List<CharacterData> data = new List<CharacterData>();
    public List<CharacterData> savedData = new List<CharacterData>();

    public int id;
    public int ctype;

    public Stat.CharacterTypes selectedType;

    public void SaveCharacterData()
    {
        JSONSystem.JSONSaveSystem.SaveToJSON(data, true, "Characters");
    }

    public void LoadData()
    {
        savedData = JSONSystem.JSONSaveSystem.ReadFromJson<CharacterData>("Characters");
    }

    public void SelectCharacter(Stat.CharacterTypes ct)
    {
        selectedType = ct;
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
