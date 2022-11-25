using System;
using System.Collections;
using System.Collections.Generic;
using Stat;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerMana : MonoBehaviour
    {
        [SerializeField] private float mana;
        [SerializeField] private StatType manaType;

        public float Mana { get => mana; }

        private float m_MaxMana;
        private bool m_IsInitialized;
        
        public static GameEvent<float> OnUseMana;

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }
        
        private void HandleOnCharacterInitialized(PlayerSettings playerSettings)
        {
            m_MaxMana = playerSettings.CharacterStat.GetValue(manaType);
            
            if (!m_IsInitialized)
            {
                m_IsInitialized = true;
                mana = m_MaxMana;
            }
        }

        public void UseMana(float skillMana)
        {
            mana -= skillMana;
            OnUseMana.Invoke(GetManaInPercentage());
        }

        public float GetManaInPercentage()
        {
            return mana / m_MaxMana;
        }
        
        public bool HasEnoughMana(float skillMana)
        {
            return mana >= skillMana;
        }

        private void AddListeners()
        {
            PlayerClass.OnCharacterInitialized.AddListener(HandleOnCharacterInitialized);
        }

        private void RemoveListeners()
        {
            PlayerClass.OnCharacterInitialized.RemoveListener(HandleOnCharacterInitialized);
        }
    }
}
