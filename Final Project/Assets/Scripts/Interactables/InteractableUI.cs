using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Utils;

namespace MyNamespace
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

        public void AddToItemPanel(Item item)
        {
            var uiItem = Instantiate(itemButtonPrefab, itemButtonParent);
            uiItem.InitializeItemButton(item);
        }
        
    }
}


