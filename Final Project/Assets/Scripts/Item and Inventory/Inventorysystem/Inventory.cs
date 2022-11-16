using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PInventory
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Inventory/Inventory")]
    public class Inventory : ScriptableObject
    {
        [SerializeField] private List<InventoryItemData> inventory = new List<InventoryItemData>();

        public List<InventoryItemData> GetInventory => inventory;

        public InventoryUIData AddItem(Item item, int amount = 1)
        {
            if (!item.CanBeStacked)
            {
                var inventoryItem = SaveItemToObject(item, amount);
                return new InventoryUIData(inventoryItem, false);
            }
            else
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].Item.ID == item.ID)
                    {
                        inventory[i].AddAmount(amount);
                        return new InventoryUIData(inventory[i], true) ;
                    }
                }
                
                var inventoryItem = SaveItemToObject(item, amount);
                return new InventoryUIData(inventoryItem, false);
            }
        }

        public InventoryItemData RemoveItem(Item item, int amount = 1)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Item == item)
                {
                    inventory[i].RemoveAmount(amount);
                    
                    InventoryItemData data = inventory[i];
                    
                    if (inventory[i].Count <= 0)
                    {
                        DeleteItemFromObject(inventory[i]);
                    }
                    
                    return data;
                }
            }

            return null;
        }

        private InventoryItemData SaveItemToObject(Item item, int amount)
        {
            var newItem = new InventoryItemData(item, amount);
            inventory.Add(newItem);
            
            var path = AssetDatabase.GetAssetPath(this.GetInstanceID());
            AssetDatabase.AddObjectToAsset(item, path);
            
            return newItem;
        }

        private void DeleteItemFromObject(InventoryItemData item)
        {
            AssetDatabase.RemoveObjectFromAsset(item.Item);
            inventory.Remove(item);
        }
    }
}
