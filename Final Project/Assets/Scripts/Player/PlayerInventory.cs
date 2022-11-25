using System;
using System.Collections;
using System.Collections.Generic;
using ItemManager;
using Player;
using Stat;
using UnityEngine;
using Utils;

namespace PInventory
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        
        public static GameEvent<List<InventoryItemData>> OnInitializeInventory;
        
        public static GameEvent<InventoryItemData> OnItemAddedToInventory;
        public static GameEvent<InventoryItemData> OnItemRemovedFromInventory;
        
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
            inventory = playerSettings.Inventory;
            OnInitializeInventory.Invoke(inventory.GetInventory);
        }

        public void AddItemToInventory(Item item, int amount = 1)
        {
            AddItemToInventory(new InventoryItemData(item, amount));
        }
        
        public void AddItemToInventory(InventoryItemData itemData)
        {
            var inventoryItemData = inventory.AddItem(itemData);
            OnItemAddedToInventory.Invoke(inventoryItemData);
        }
        
        public void RemoveItemFromInventory(InventoryItemData item)
        {
            var invetoryItemData = inventory.RemoveItem(item);
            if (invetoryItemData != null)
            {
                OnItemRemovedFromInventory.Invoke(invetoryItemData);
            }
        }
        
        private void HandleOnDeleteItem(InventoryItemData itemData)
        {
            var invetoryItemData = inventory.RemoveItem(itemData, itemData.Count);
            if (invetoryItemData != null)
            {
                OnItemRemovedFromInventory.Invoke(invetoryItemData);
            }
        }
        
        private void AddListeners()
        {
            PlayerClass.OnCharacterInitialized.AddListener(HandleOnCharacterInitialized);
            
            InventorySelectedItemUI.OnDeleteItem.AddListener(HandleOnDeleteItem);
        }

        private void RemoveListeners()
        {
            PlayerClass.OnCharacterInitialized.RemoveListener(HandleOnCharacterInitialized);
            
            InventorySelectedItemUI.OnDeleteItem.RemoveListener(HandleOnDeleteItem);
        }
    }
}
