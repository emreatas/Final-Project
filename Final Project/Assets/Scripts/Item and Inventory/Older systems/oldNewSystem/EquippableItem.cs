using System.Collections;
using System.Collections.Generic;
using PInventory;
using UnityEngine;


namespace PInventory
{
    public enum EquipmentType
    {
        Helmet,
        Armor,
        Boots,
        Weapon,
        Accessory,
        Wings
    }
    [CreateAssetMenu(menuName = "Inventory/equipment item")]
    public class EquippableItem : Item
    {

        public EquipmentType equipmentType;
        
    }
    
   
}