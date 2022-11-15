using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PInventory
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Inventory")]
    public class Inventory : ScriptableObject
    {
        private List<Item> inventory = new List<Item>();

        public void AddItem(Item item)
        {
            
        }

        public void RemoveItem(Item item)
        {
            
        }
    }

    public class InventoryItem
    {
        private Item item;
        private int count;
    }

}
