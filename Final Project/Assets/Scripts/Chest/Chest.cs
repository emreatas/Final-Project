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
    public class Chest : MonoBehaviour, IInteractable
    {
        private PlayerInventory m_Inventory;

        private List<Item> chestLootList;

        private bool m_Interacted;

        public GameEvent OnRemoveChestFromPanel;

        private bool CanDestroy => chestLootList.Count <= 0;

        private void OnTriggerEnter(Collider other)
        {
            if (m_Interacted) { return; }

            m_Interacted = true;

            AddChestLootToPanel();
        }

        private void OnTriggerExit(Collider other)
        {
            RemoveChestLootFromPanel();
            m_Interacted = false;
        }

        public void InitializeChest(ChestLoot chestLoot)
        {
            chestLootList = chestLoot.GetRandomLoot();

            if (CanDestroy)
            {
                Destroy(gameObject);
            }
        }

        public void Interact(PlayerInteractionController interactionController)
        {
            m_Inventory = interactionController.PlayerInventory;
            InteractableUI.Instance.EnableInteractPanel();
        }

        private void AddChestLootToPanel()
        {
            for (int i = 0; i < chestLootList.Count; i++)
            {
                InteractableUI.Instance.AddToItemPanel(chestLootList[i], this);
            }
        }

        private void RemoveChestLootFromPanel()
        {
            m_Interacted = false;

            InteractableUI.Instance.DecreaseUIActiveCount(chestLootList.Count);

            OnRemoveChestFromPanel.Invoke();
        }

        public void OnSelectItem(Item item)
        {
            InteractableUI.Instance.DecreaseUIActiveCount();

            if (item.ID == 9999)
            {
                Data.instance.OnSetCurrency(UnityEngine.Random.Range(100, 1000));
            }
            else
            {
                m_Inventory.AddItemToInventory(item);
            }

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