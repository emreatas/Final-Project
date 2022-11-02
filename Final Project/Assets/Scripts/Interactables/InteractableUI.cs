using System;
using Items;
using UnityEngine;
using Utils;

namespace Interactables
{
    public class InteractableUI : AbstractSingelton<InteractableUI>
    {
        [SerializeField] private GameObject interactUI;
        [SerializeField] private GameObject interactItemPanel;

        [SerializeField] private Transform itemButtonParent;
        
        [SerializeField] private DroppedItem itemButtonPrefab;
        
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
            interactItemPanel.SetActive(true);
        }

        public void DisableInteractPanel()
        {
            interactItemPanel.SetActive(false);
        }

        public GameObject AddToItemPanel(Item item, Action<Item> onSelectItem)
        {
            var uiItem = Instantiate(itemButtonPrefab, itemButtonParent);
            uiItem.InitializeItemButton(item, onSelectItem);
            
            return uiItem.gameObject;
        }
    }
}


