using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactables;
using Utils;
using InventorySystem;
using ItemManager;
using PInventory;
using Player;

namespace Items
{
    public class Chest : Interactable
    {
        private List<Item> chestLootList;
        private Dictionary<Item, GameObject> instansiatedItems = new Dictionary<Item, GameObject>();
        
        private PlayerInventory m_Inventory;
        
        private bool m_Interacted;

        private GameEvent OnReset;
        
        private bool CanDestroy => chestLootList.Count <= 0;
        
        private void OnTriggerEnter(Collider other)
        {
            if (m_Interacted) { return; }
            m_Interacted = true;

            AddChestLootToPanel();
        }

        private void OnTriggerExit(Collider other)
        {
            ResetItem();
        }
        
        public void InitializeChest(ChestLoot chestLoot)
        {
            chestLootList = chestLoot.GetRandomLoot();
            
            if (CanDestroy)
            {
                Destroy(gameObject);
            }
        }

        public override void Interact(PlayerInteractionController interactionController)
        {
            m_Inventory = interactionController.PlayerInventory;
            InteractableUI.Instance.EnableInteractPanel();
        }
        
        private void AddChestLootToPanel()
        {
            for (int i = 0; i < chestLootList.Count; i++)
            {
                var itemGO = InteractableUI.Instance.AddToItemPanel(chestLootList[i], OnSelectItem);
                instansiatedItems[chestLootList[i]] = itemGO;
            }
        }

        private void ResetItem()
        {
            m_Interacted = false;
            
            for (int i = 0; i < chestLootList.Count; i++)
            {
                InteractableUI.Instance.RemoveItemFromPanel();
                Destroy(instansiatedItems[chestLootList[i]]);
            }

            instansiatedItems.Clear();
        }

        private void OnSelectItem(Item item)
        {
            InteractableUI.Instance.RemoveItemFromPanel();
            
            m_Inventory.AddItemToInventory(item);
            
            instansiatedItems.Remove(item);
            chestLootList.Remove(item);

            if (CanDestroy)
            {
                DestroyChest();
            }
        }
        
        private void DestroyChest()
        {
            Destroy(gameObject);
        }
    }
}