using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace ItemManager
{
    public class EquipmentItem : Item
    {
        public EquipmentSlot EquipmentSlot;
        public ItemTier ItemTier;
        public Color ItemTierColor;
        
        public List<AttributeModifier> Stats;
        
        public EquipmentItem(int id, string itemName, Sprite icon, bool canBeStacked, EquipmentSlot equipmentSlot , List<AttributeModifier> stats) : base(id, itemName, icon,canBeStacked)
        {
            EquipmentSlot = equipmentSlot;
            
            ItemTier = ItemTierManager.GetRandomItemTier();
            ItemTierColor = ItemTierManager.GetTierColor(ItemTier);

            Stats = stats;
        }
    }
    
    public enum EquipmentSlot
    {
        Head,
        Chest,
        Shoes,
        Weapon,
        Accessory,
        Wings
    }
}