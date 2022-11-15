using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Items;
using InventorySystem;
using PInventory;

namespace CanvasNS
{
    public class CanvasManager : MonoBehaviour
    {

        public static CanvasManager instance;

        private void Awake()
        {
            instance = this;
        }

        public static event Action<bool> ItemDropPanelStart;
        public static event Action<bool> InteractableStart;
        public static event Action<Item> ShowItem;
        public static event Action ShowInventoryItem;
        public static event Action ShowEquipItem;

        public void OnInteractableStart(bool interact)
        {

            if (InteractableStart != null)
            {
                InteractableStart(interact);
            }
        }

        public void OnItemDropPanelStart(bool interact)
        {

            if (ItemDropPanelStart != null)
            {
                ItemDropPanelStart(interact);
            }
        }

        public void OnShowItem(Item item)
        {
            if (ShowItem != null)
            {
                ShowItem(item);
            }
        }

        public void OnShowInventoryItem()
        {
            if (ShowInventoryItem != null)
            {
                ShowInventoryItem();
            }
        }

        public void OnShowEquipItem()
        {
            if (ShowEquipItem != null)
            {
                ShowEquipItem();
            }
        }

    }
}