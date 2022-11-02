using System;
using System.Collections;
using UnityEngine;
using Interactables;

namespace Items
{
    public class Chest : Interactable
    {
        [SerializeField] private ChestLoot chestLoot;
        private bool m_Interacted;

        public void InitializeChest(ChestLoot chestLoot)
        {
            this.chestLoot = chestLoot;
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
            for (int i = 0; i < chestLoot.dropableItem.Count; i++)
            {
                var itemGO = InteractableUI.Instance.AddToItemPanel(chestLoot.dropableItem[i], OnSelectItem);
                chestLoot.instansiatedItems[chestLoot.dropableItem[i]] = itemGO;
            }
        }

        private void Reset()
        {
            m_Interacted = false;
            for (int i = 0; i < chestLoot.dropableItem.Count; i++)
            {
                Destroy(chestLoot.instansiatedItems[chestLoot.dropableItem[i]]);
            }

            chestLoot.instansiatedItems.Clear();
        }

        private void OnSelectItem(Item item)
        {
            chestLoot.SelectItemFromChest(item);
        }
    }
}