using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using Stat;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private CharacterStat characterStats;
        [SerializeField] private StatType targetStat;

        public static GameEvent<CharacterStat> OnCharacterStatsInitialized;
        public static GameEvent<CharacterAttribute> OnCharacterAttributeUpdated;

        private void OnEnable()
        {
            AddListeners();
        }
        private void OnDisable()
        {
            RemoveListeners();
        }

        private void Start()
        {
            OnCharacterStatsInitialized.Invoke(characterStats);
        }

        private void OnStatUpdated(CharacterAttribute characterAttribute)
        {
            OnCharacterAttributeUpdated.Invoke(characterAttribute);
        }
        
        private void AddListeners()
        {
            for (int i = 0; i < characterStats.CharacterAttributes.Count; i++)
            {
                characterStats.CharacterAttributes[i].OnCharacterAttributeUpdated.AddListener(OnStatUpdated);
            }
        }

        private void RemoveListeners()
        {
            for (int i = 0; i < characterStats.CharacterAttributes.Count; i++)
            {
                characterStats.CharacterAttributes[i].OnCharacterAttributeUpdated.RemoveListener(OnStatUpdated);
            }
        }

        public float GetValue(StatType statType)
        {
            return characterStats.GetValue(statType);
        }
    }
}