using System.Collections;
using System.Collections.Generic;
using ItemManager;
using UnityEditor;
using UnityEngine;

namespace PInventory
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Inventory/Inventory")]
    public class Inventory : ScriptableObject
    {
        [SerializeField] private List<InventoryItemData> inventory = new List<InventoryItemData>();

        public List<InventoryItemData> GetInventory => inventory;
        
        public InventoryItemData AddItem(Item item, int amount = 1)
        {
            if (item.CanBeStacked)
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (IDsAreEqual(inventory[i].Item.ID, item.ID))
                    {
                        inventory[i].IncreaseItemAmount(amount);
                        return inventory[i];
                    }
                }
            }
            
            return AddItemToInventory(item, amount);
        }

        public InventoryItemData RemoveItem(Item item, int amount = 1)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (ItemsAreEqual(inventory[i].Item, item))
                {
                    inventory[i].DecreaseItemAmount(amount);
                    
                    InventoryItemData data = inventory[i];
                    
                    if (RemovedItemCompletely(inventory[i].Count))
                    {
                        RemoveItemFromInventory(inventory[i]);
                    }
                    
                    return data;
                }
            }

            return null;
        }

        private InventoryItemData AddItemToInventory(Item item, int amount)
        {
            var newItem = new InventoryItemData(item, amount);
            inventory.Add(newItem);
            
            return newItem;
        }

        private void RemoveItemFromInventory(InventoryItemData item)
        {
            inventory.Remove(item);
        }
        
        private bool IDsAreEqual(int firstID, int SecondID)
        {
            return firstID == SecondID;
        }

        private bool ItemsAreEqual(Item firstItem, Item secondItem)
        {
            return firstItem == secondItem;
        }

        private bool RemovedItemCompletely(int count)
        {
            return count <= 0;
        }

    }
}
