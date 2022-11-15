using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PInventory
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        
        public void AddItemToInventory(Item item)
        {
            inventory.AddItem(item);
        }

        public void RemoveItemFromInventory(Item item)
        {
            inventory.RemoveItem(item);
        }
    }

}
