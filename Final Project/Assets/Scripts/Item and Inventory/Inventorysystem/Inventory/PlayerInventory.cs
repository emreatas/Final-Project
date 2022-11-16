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
        
        public static GameEvent<List<InventoryItemData>> OnInventoryInitialize;
        
        public static GameEvent<InventoryUIData> OnItemAddedToInventory;
        public static GameEvent<InventoryItemData> OnItemRemovedFromInventory;
        
        private void OnEnable()
        {
            InventoryUI.OnRemoveItem.AddListener(RemoveItemFromInventory);
        }
        

        private void OnDisable()
        {
            InventoryUI.OnRemoveItem.RemoveListener(RemoveItemFromInventory);
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
    }

}
