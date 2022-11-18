using System;
using System.Collections;
using System.Collections.Generic;
using ItemManager;
using Stat;
using UnityEngine;
using Utils;

namespace PInventory
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private Equipment equipment;
        
        public static GameEvent<List<InventoryItemData>> OnInventoryInitialize;
        
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

        private void Start()
        {
            OnInventoryInitialize.Invoke(inventory.GetInventory);
        }

        public void AddItemToInventory(Item item)
        {
            var inventoryItemData = inventory.AddItem(item);
            OnItemAddedToInventory.Invoke(inventoryItemData);
        }

        public void RemoveItemFromInventory(Item item)
        {
            var invetoryItemData = inventory.RemoveItem(item);
            
            if (invetoryItemData != null)
            {
                OnItemRemovedFromInventory.Invoke(invetoryItemData);
            }
        }

        private void AddListeners()
        {
            InventoryUI.OnRemoveItem.AddListener(RemoveItemFromInventory);
        }

        private void RemoveListeners()
        {
            InventoryUI.OnRemoveItem.RemoveListener(RemoveItemFromInventory);
        }
    }

}
