using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactables;
using Utils;
using InventorySystem;

namespace Items
{
    public class Chest : Interactable
    {
        public List<InventorySystem.Item> dropableItem;
        public Dictionary<Item, GameObject> instansiatedItems = new Dictionary<Item, GameObject>();
        private bool m_Interacted;
        private bool CanDestroy => dropableItem.Count <= 0;

        private GameEvent OnReset;



        public void InitializeChest(ChestLoot chestLoot)
        {
            dropableItem = chestLoot.GetRandomLoot();
            if (dropableItem.Count == 0)
            {
                Destroy(gameObject);
            }
        }

        public override void Interact()
        {
            InteractableUI.Instance.EnableInteractPanel();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (m_Interacted)
            {
                return;
            }

            m_Interacted = true;

            AddItemsChest();
        }

        private void OnTriggerExit(Collider other)
        {
            ResetItem();
        }

        private void AddItemsChest()
        {
            for (int i = 0; i < dropableItem.Count; i++)
            {
                var itemGO = InteractableUI.Instance.AddToItemPanel(dropableItem[i], OnSelectItem);
                instansiatedItems[dropableItem[i]] = itemGO;
            }
        }

        private void ResetItem()
        {
            m_Interacted = false;
            for (int i = 0; i < dropableItem.Count; i++)
            {
                InteractableUI.Instance.RemoveItemFromPanel();
                Destroy(instansiatedItems[dropableItem[i]]);
            }

            instansiatedItems.Clear();
        }

        private void OnSelectItem(Item item)
        {
            SelectItemFromChest(item);
        }

        private void SelectItemFromChest(Item item)
        {
            InteractableUI.Instance.RemoveItemFromPanel();

            //Inventory.Instance.Add(item);
   

            instansiatedItems.Remove(item);
            dropableItem.Remove(item);

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