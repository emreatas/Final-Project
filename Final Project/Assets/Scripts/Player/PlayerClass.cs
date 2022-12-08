using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine;
using Utils;

namespace Player
{
    [Serializable]
    public class PlayerClass : MonoBehaviour
    {
        [SerializeField] private PlayerSettings playerSettings;

        public PlayerSettings PlayerSettings
        {
            get { return playerSettings; }

            set { playerSettings = value; }
        }

        public static GameEvent<PlayerSettings> OnCharacterInitialized;

        private void Start()
        {
            playerSettings.CharacterID = PlayerPrefs.GetInt("CharacterID", 0);
            playerSettings.characterType = (Stat.CharacterTypes)PlayerPrefs.GetInt("CharacterType", 0);

            Debug.Log("ccc" + PlayerPrefs.GetInt("CharacterID", 0));
            Debug.Log("ddd" + (Stat.CharacterTypes)PlayerPrefs.GetInt("CharacterType", 0));

            Timing.RunCoroutine(StartCO());
        }
        private IEnumerator<float> StartCO()
        {
            yield return Timing.WaitForSeconds(.5f);
            OnCharacterInitialized.Invoke(playerSettings);
        }
    }
}