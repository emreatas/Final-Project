using System;
using Items;
using ObjectPooling;
using Unity.VisualScripting;
using UnityEngine;
using Utils;
using InventorySystem;
using ItemManager;
using PInventory;

namespace Interactables
{
    public class InteractableUI : AbstractSingelton<InteractableUI>
    {
        [SerializeField] private GameObject interactUI;
        [SerializeField] private GameObject interactItemPanel;

        [SerializeField] private Transform itemButtonParent;

        [SerializeField] private InteractItemButton itemButtonButtonPrefab;
        
        private int m_ActiveItemCount = 0;

        public void EnableInteractButton()
        {
            interactUI.SetActive(true);
        }

        public void DisableInteractButton()
        {
            interactUI.SetActive(false);
        }

        public void EnableInteractPanel()
        {
            if (m_ActiveItemCount > 0)
            {
                interactItemPanel.SetActive(true);
            }
        }

        public void DisableInteractPanel()
        {
            interactItemPanel.SetActive(false);
        }

        public void AddToItemPanel(Item item, Chest connectedChest)
        {
            m_ActiveItemCount++;

            InstansiateItemButton(item, connectedChest);
        }
        
        private void InstansiateItemButton(Item item, Chest connectedChest)
        {
            var uiItem = Instantiate(itemButtonButtonPrefab, itemButtonParent);
            uiItem.InitializeItemButton(item, connectedChest);
        }
        
        public void DecreaseUIActiveCount(int amount = 1)
        {
            m_ActiveItemCount -= amount;

            if (m_ActiveItemCount <= 0)
            {
                DisableInteractPanel();
            }
        }
    }
}


