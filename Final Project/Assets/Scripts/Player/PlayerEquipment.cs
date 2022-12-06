using System;
using System.Collections;
using System.Collections.Generic;
using ItemManager;
using Player;
using UnityEngine;
using Utils;

namespace PInventory
{
    public class PlayerEquipment : MonoBehaviour
    {
        [SerializeField] private PlayerInventory playerInventory;
        [SerializeField] private Equipment equipment;

        public static GameEvent<Dictionary<EquipmentSlotTypes, InventoryItemData>> OnInitalizeEquipment;

        public static GameEvent<InventoryItemData> OnItemEquipped;
        public static GameEvent<InventoryItemData> OnItemUnequipped;

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
            equipment = playerSettings.Equipment;
            OnInitalizeEquipment.Invoke(equipment.GetEquipment);
        }

        public void HandleOnEquipItem(InventoryItemData itemData)
        {
            var oldEquippedItem = equipment.EquipItem(itemData);
            playerInventory.RemoveItemFromInventory(itemData);

            if (oldEquippedItem != null)
            {
                playerInventory.AddItemToInventory(oldEquippedItem);
                OnItemUnequipped.Invoke(oldEquippedItem);

            }
            OnItemEquipped.Invoke(itemData);
        }

        public void HandleOnUnequipItem(InventoryItemData itemData)
        {
            var uneqquipedItem = equipment.UnequipItem(itemData);

            if (uneqquipedItem != null)
            {
                playerInventory.AddItemToInventory(uneqquipedItem);
                OnItemUnequipped.Invoke(uneqquipedItem);

            }



        }

        private void HandleOnDeleteItem(InventoryItemData itemData)
        {
            var uneqquipedItem = equipment.DeleteItem(itemData);

            if (uneqquipedItem != null)
            {
                OnItemUnequipped.Invoke(uneqquipedItem);
            }


        }

        private void AddListeners()
        {
            PlayerClass.OnCharacterInitialized.AddListener(HandleOnCharacterInitialized);

            InventorySelectedItemUI.OnEquipItem.AddListener(HandleOnEquipItem);
            InventorySelectedItemUI.OnUneqquipItem.AddListener(HandleOnUnequipItem);
            InventorySelectedItemUI.OnDeleteItem.AddListener(HandleOnDeleteItem);
        }

        private void RemoveListeners()
        {
            PlayerClass.OnCharacterInitialized.AddListener(HandleOnCharacterInitialized);

            InventorySelectedItemUI.OnEquipItem.RemoveListener(HandleOnEquipItem);
            InventorySelectedItemUI.OnUneqquipItem.RemoveListener(HandleOnUnequipItem);
            InventorySelectedItemUI.OnDeleteItem.RemoveListener(HandleOnDeleteItem);
        }



    }


}
