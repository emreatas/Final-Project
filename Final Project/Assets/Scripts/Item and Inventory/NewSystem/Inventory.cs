using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Interactables;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] List<Item> items;
        [SerializeField] Transform itemParent;
        [SerializeField] ItemSlots[] itemSlots;

        public event Action<Item> OnItemRightClickedEvet;
        public static event Action<Item> OnPickUpItem;


        private void Start()
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                itemSlots[i].OnRightClickEvet += OnItemRightClickedEvet;
            }
        }

        private void OnEnable()
        {
            InteractableUI.OnItemAddedToInventory += DroppedItem_OnSelectItem;

        }

        private void DroppedItem_OnSelectItem(Item obj)
        {
            Debug.Log("Item added to inventory");
            AddItem(obj);
        }

        private void OnDisable()
        {
            InteractableUI.OnItemAddedToInventory -= DroppedItem_OnSelectItem;
        }

        private void OnValidate()
        {
            if (itemParent != null)
            {
                itemSlots = itemParent.GetComponentsInChildren<ItemSlots>();

            }
            RefreshUI();
        }

        private void RefreshUI()
        {
            int i = 0;
            for (; i < items.Count && i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = items[i];
            }
            for (; i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = null;
            }
        }

        public bool AddItem(Item item)
        {
            if (IsFull())
            {
                return false;

            }
            items.Add(item);
            RefreshUI();
            return true;
        }
        public bool RemoveItem(Item item)
        {
            if (items.Remove(item))
            {
                RefreshUI();
                return true;

            }
            return false;
        }

        public bool IsFull()
        {
            return items.Count >= itemSlots.Length;
        }
    }
}

