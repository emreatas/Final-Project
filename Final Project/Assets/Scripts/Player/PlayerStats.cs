using System;
using System.Collections;
using System.Collections.Generic;
//using CanvasNS;
using Items;
using PInventory;
using Stat;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private CharacterStat characterStats;
        [SerializeField] private StatType targetStat;

        public CharacterStat CharacterStats => characterStats;
        
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
        
        private void HandleOnCharacterAttributeIncreased(StatType statType)
        {
            characterStats.IncreaseBaseValue(statType, 1);
        }
        
       
        private void HandleOnItemEquipped(InventoryItemData itemData)
        {
            for (int i = 0; i < itemData.Item.Stats.Count; i++)
            {
                characterStats.AddModifier(itemData.Item.Stats[i]);
            }
            
        }
        private void HandleOnItemUnequipped(InventoryItemData itemData)
        {
            for (int i = 0; i < itemData.Item.Stats.Count; i++)
            {
                characterStats.RemoveModifier(itemData.Item.Stats[i]);
            }
        }
        
        public float GetValue(StatType statType)
        {
            return characterStats.GetValue(statType);
        }
        
        private void AddListeners()
        {
            for (int i = 0; i < characterStats.CharacterAttributes.Count; i++)
            {
                characterStats.CharacterAttributes[i].OnCharacterAttributeUpdated.AddListener(OnStatUpdated);
            }
            
            PlayerEquipment.OnItemEquipped.AddListener(HandleOnItemEquipped);
            PlayerEquipment.OnItemUnequipped.AddListener(HandleOnItemUnequipped);

            //CanvasScript.OnCharacterAttributeIncreased.AddListener(HandleOnCharacterAttributeIncreased);
        }
        
        private void RemoveListeners()
        {
            for (int i = 0; i < characterStats.CharacterAttributes.Count; i++)
            {
                characterStats.CharacterAttributes[i].OnCharacterAttributeUpdated.RemoveListener(OnStatUpdated);
            }
            
            PlayerEquipment.OnItemEquipped.RemoveListener(HandleOnItemEquipped);
            PlayerEquipment.OnItemUnequipped.RemoveListener(HandleOnItemUnequipped);
            
            //CanvasScript.OnCharacterAttributeIncreased.RemoveListener(HandleOnCharacterAttributeIncreased);
        }

    }
}