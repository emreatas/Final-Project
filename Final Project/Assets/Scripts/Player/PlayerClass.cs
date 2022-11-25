using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerClass : MonoBehaviour
    {
        [SerializeField] private PlayerSettings playerSettings;

        public static GameEvent<PlayerSettings> OnCharacterInitialized;

        private void Start()
        {
            Timing.RunCoroutine(StartCO());
        }
        private IEnumerator<float> StartCO()
        {
            yield return Timing.WaitForSeconds(.5f);
            OnCharacterInitialized.Invoke(playerSettings);
        }
    }
}