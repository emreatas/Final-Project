using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Items;

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

    }
}