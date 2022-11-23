using System.Collections.Generic;
using ItemManager;
using UnityEngine;

namespace PInventory
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Inventory/Equipment")]
    public class Equipment : ScriptableObject
    {
        Dictionary<EquipmentSlotTypes,InventoryItemData> equipment = new Dictionary<EquipmentSlotTypes,InventoryItemData>();

        public Dictionary<EquipmentSlotTypes, InventoryItemData> GetEquipment => equipment;
        public InventoryItemData EquipItem(InventoryItemData equippedItemData)
        {
            var item = equippedItemData.Item;
            
            InventoryItemData oldItem = null;
            if (EquipmentSlotIsFull(item))
            {
                oldItem = equipment[item.equipmentSlotTypes];
            }
            
            equipment[item.equipmentSlotTypes] = equippedItemData;

            return oldItem;
        }

        public InventoryItemData UnequipItem(InventoryItemData equippedItemData)
        {
            InventoryItemData unequipedItem = null;
            if (EquipmentSlotIsFull(equippedItemData.Item))
            {
                unequipedItem = equipment[equippedItemData.Item.equipmentSlotTypes];
                equipment[equippedItemData.Item.equipmentSlotTypes] = null;
            }

            return unequipedItem;
        }
        
        public InventoryItemData DeleteItem(InventoryItemData equippedItemData)
        {
            InventoryItemData unequipedItem = null;
            if (IsItemToDelete(equippedItemData))
            {
                unequipedItem = equipment[equippedItemData.Item.equipmentSlotTypes];
                equipment[equippedItemData.Item.equipmentSlotTypes] = null;
            }

            return unequipedItem;
        }

        private bool EquipmentSlotIsFull(Item item)
        {
            return equipment.ContainsKey(item.equipmentSlotTypes) && equipment[item.equipmentSlotTypes] != null;
        }
        
        private bool ItemsAreEqual(Item firstItem, Item secondItem)
        {
            return firstItem == secondItem;
        }
        
        private bool IsItemToDelete(InventoryItemData equippedItemData)
        {
            return EquipmentSlotIsFull(equippedItemData.Item) &&
                   ItemsAreEqual(equipment[equippedItemData.Item.equipmentSlotTypes].Item, equippedItemData.Item);
        }
    }

}
