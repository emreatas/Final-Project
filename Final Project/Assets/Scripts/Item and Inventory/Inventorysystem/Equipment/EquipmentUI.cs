using System;
using System.Collections;
using System.Collections.Generic;
using ItemManager;
using UnityEngine;
using Utils;

namespace PInventory
{
    public class EquipmentUI : MonoBehaviour
    {
        [SerializeField] private EquipmentItemSlot[] equipmentSlots;
        
        public static GameEvent<InventoryItemData> OnShowSelectedItem;

        private void Awake()
        {
            AddListeners();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }
        
        private void HandleOnEquipItem(InventoryItemData itemData)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].SlotType == itemData.Item.equipmentSlotTypes)
                {
                    equipmentSlots[i].EquipItem(itemData);
                }
            }
        }

        private void HandleOnUnequippedItem(InventoryItemData itemData)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].SlotType == itemData.Item.equipmentSlotTypes)
                {
                    equipmentSlots[i].UnequipItem(itemData);
                }
            }
        }

        private void HandleOnInitializeEquipment(Dictionary<EquipmentSlotTypes, InventoryItemData> equipment)
        {
           for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipment.ContainsKey(equipmentSlots[i].SlotType) && equipment[equipmentSlots[i].SlotType] != null)
                {
                    equipmentSlots[i].InitializeSlot(equipment[equipmentSlots[i].SlotType]);
                }
            }
        }
        
        public void ShowItem(InventoryItemData itemData)
        {
            OnShowSelectedItem.Invoke(itemData);
        }

        private void AddListeners()
        {
            PlayerEquipment.OnItemEquipped.AddListener(HandleOnEquipItem);
            PlayerEquipment.OnItemUnequipped.AddListener(HandleOnUnequippedItem);
            
            PlayerEquipment.OnInitalizeEquipment.AddListener(HandleOnInitializeEquipment);
        }

        private void RemoveListeners()
        {
            PlayerEquipment.OnItemEquipped.RemoveListener(HandleOnEquipItem);
            PlayerEquipment.OnItemUnequipped.RemoveListener(HandleOnUnequippedItem);
            
            PlayerEquipment.OnInitalizeEquipment.RemoveListener(HandleOnInitializeEquipment);
        }
    }
}
