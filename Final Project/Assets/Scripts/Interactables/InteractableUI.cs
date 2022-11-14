using System;
using Items;
using ObjectPooling;
using Unity.VisualScripting;
using UnityEngine;
using Utils;
using InventorySystem;

namespace Interactables
{
    public class InteractableUI : AbstractSingelton<InteractableUI>
    {
        [SerializeField] private GameObject interactUI;
        [SerializeField] private GameObject interactItemPanel;

        [SerializeField] private Transform itemButtonParent;

        [SerializeField] private DroppedItem itemButtonPrefab;

        public static Action<Item> OnItemAddedToInventory;

        private int activeItemCount = 0;

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
            if (activeItemCount > 0)
            {
                interactItemPanel.SetActive(true);
            }
        }

        public void DisableInteractPanel()
        {
            interactItemPanel.SetActive(false);
        }

        public GameObject AddToItemPanel(Item item, Action<Item> onSelectItem)
        {
            activeItemCount++;

            var uiItem = Instantiate(itemButtonPrefab, itemButtonParent);
            uiItem.InitializeItemButton(item, onSelectItem);
            OnItemAddedToInventory?.Invoke(item);

            return uiItem.gameObject;
        }

        public void RemoveItemFromPanel()
        {
            activeItemCount--;

            if (activeItemCount <= 0)
            {
                DisableInteractPanel();
            }
        }
    }
}


