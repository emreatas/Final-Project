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
            //OnCharacterAttributeUpdated.Invoke(characterAttribute);
            OnCharacterStatsInitialized.Invoke(characterStats);
        }
        
        private void AddListeners()
        {
            for (int i = 0; i < characterStats.CharacterAttributes.Count; i++)
            {
                characterStats.CharacterAttributes[i].OnCharacterAttributeUpdated.AddListener(OnStatUpdated);
            }
            EquipmentManager.OnEquipItem.AddListener(HandleOnEquipItem);
            EquipmentManager.OnUnequipItem.AddListener(HandleOnUnequipItem);
        }

        private void RemoveListeners()
        {
            for (int i = 0; i < characterStats.CharacterAttributes.Count; i++)
            {
                characterStats.CharacterAttributes[i].OnCharacterAttributeUpdated.RemoveListener(OnStatUpdated);
            }
            EquipmentManager.OnEquipItem.RemoveListener(HandleOnEquipItem);
            EquipmentManager.OnUnequipItem.RemoveListener(HandleOnUnequipItem);
        }
        
        private void HandleOnEquipItem(EquipmentItem equipedItem)
        {
            for (int i = 0; i < equipedItem.stats.Count; i++)
            {
                characterStats.AddModifier(equipedItem.stats[i]);
            }
            
        }
        private void HandleOnUnequipItem(EquipmentItem unequipedItem)
        {
            for (int i = 0; i < unequipedItem.stats.Count; i++)
            {
                characterStats.RemoveModifier(unequipedItem.stats[i]);
            }
        }
        
        public float GetValue(StatType statType)
        {
            return characterStats.GetValue(statType);
        }
    }
}