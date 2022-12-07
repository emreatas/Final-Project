using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCharacterBtnData : MonoBehaviour
{
    public int id;

    public void setID()
    {
        PlayerPrefs.SetInt("CharacterID", id);

        Debug.Log(PlayerPrefs.GetInt("CharacterID", 0));

    }
}
