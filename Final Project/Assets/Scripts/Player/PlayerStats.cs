using System;
using System.Collections;
using System.Collections.Generic;
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

        public CharacterStat CharacterStats => characterStats;

        public static GameEvent<int> OnSkillPointsUpdated;
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

        private void HandleOnCharacterInitialized(PlayerSettings playerSettings)
        {
            characterStats = playerSettings.CharacterStat;

            AddStatListeners();
            Data.instance.CharacterAttributeLoad();
            OnCharacterStatsInitialized.Invoke(characterStats);
        }

        private void OnStatUpdated(CharacterAttribute characterAttribute)
        {
            //OnCharacterAttributeUpdated.Invoke(characterAttribute);
            OnCharacterStatsInitialized.Invoke(characterStats);
        }

        private void HandleOnPlayerLeveldUp()
        {
            characterStats.IncreaseSkillPoints();
            OnSkillPointsUpdated.Invoke(characterStats.AvailableSkillPoints);
        }

        private void HandleOnCharacterAttributeIncreased(StatType statType)
        {
            characterStats.IncreaseBaseValue(statType, 1);
            characterStats.DecreaseSkillPoints();
            OnSkillPointsUpdated.Invoke(characterStats.AvailableSkillPoints);
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

            PlayerClass.OnCharacterInitialized.AddListener(HandleOnCharacterInitialized);

            PlayerLevel.OnPlayerLeveldUp.AddListener(HandleOnPlayerLeveldUp);

            PlayerEquipment.OnItemEquipped.AddListener(HandleOnItemEquipped);
            PlayerEquipment.OnItemUnequipped.AddListener(HandleOnItemUnequipped);

            StatUI.OnStatIncreased.AddListener(HandleOnCharacterAttributeIncreased);
        }

        private void RemoveListeners()
        {
            RemoveStatListeners();

            PlayerClass.OnCharacterInitialized.RemoveListener(HandleOnCharacterInitialized);

            PlayerLevel.OnPlayerLeveldUp.RemoveListener(HandleOnPlayerLeveldUp);

            PlayerEquipment.OnItemEquipped.RemoveListener(HandleOnItemEquipped);
            PlayerEquipment.OnItemUnequipped.RemoveListener(HandleOnItemUnequipped);

            StatUI.OnStatIncreased.RemoveListener(HandleOnCharacterAttributeIncreased);
        }


        private void AddStatListeners()
        {
            for (int i = 0; i < characterStats.CharacterAttributes.Count; i++)
            {
                characterStats.CharacterAttributes[i].OnCharacterAttributeUpdated.AddListener(OnStatUpdated);
            }
        }

        private void RemoveStatListeners()
        {
            for (int i = 0; i < characterStats.CharacterAttributes.Count; i++)
            {
                characterStats.CharacterAttributes[i].OnCharacterAttributeUpdated.RemoveListener(OnStatUpdated);
            }
        }
    }
}