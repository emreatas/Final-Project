using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactables;

namespace Items
{
    public class Chest : Interactable
    {
        //[SerializeField] private ChestLoot chestLoot;
        
        public List<Item> dropableItem;
        public Dictionary<Item, GameObject> instansiatedItems = new Dictionary<Item, GameObject>();
        private bool m_Interacted;
        

        public void InitializeChest(ChestLoot chestLoot)
        {
            //this.chestLoot = chestLoot;
            dropableItem = chestLoot.GetRandomLoot();
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
            Reset();
        }

        private void AddItemsChest()
        {
            for (int i = 0; i < dropableItem.Count; i++)
            {
                var itemGO = InteractableUI.Instance.AddToItemPanel(dropableItem[i], OnSelectItem);
                instansiatedItems[dropableItem[i]] = itemGO;
            }
        }

        private void Reset()
        {
            m_Interacted = false;
            for (int i = 0; i < dropableItem.Count; i++)
            {
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
            instansiatedItems.Remove(item);
            dropableItem.Remove(item);
        }
    }
}