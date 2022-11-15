using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PInventory
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Inventory/Inventory")]
    public class Inventory : ScriptableObject
    {
        [SerializeField] private List<InventoryItem> inventory = new List<InventoryItem>();

        public void AddItem(Item item, int amount = 1)
        {
            if (!item.CanBeStacked)
            {
                inventory.Add(new InventoryItem(item, amount));
            }
            else
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].Item == item)
                    {
                        inventory[i].AddAmount(amount);
                        return;
                    }
                }
                
                inventory.Add(new InventoryItem(item, amount));
            }
        }

        public void RemoveItem(Item item, int amount = 1)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Item == item)
                {
                    inventory[i].RemoveAmount(amount);

                    if (inventory[i].Count <= 0)
                    {
                        inventory.RemoveAt(i);
                    }
                }
            }
        }
    }

    [Serializable]
    public class InventoryItem
    {
        public Item Item;
        public int Count;

        public InventoryItem(Item item, int count = 1)
        {
            Item = item;
            Count = count;
        }

        public void AddAmount(int amount)
        {
            Count += amount;
        }

        public void RemoveAmount(int amount)
        {
            Count -= amount;
        }
    }

}
