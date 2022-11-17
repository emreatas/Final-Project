using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace ItemManager
{
    public class EquipmentItem : Item
    {
        public EquipmentSlot EquipmentSlot;
        
        public List<AttributeModifier> Stats;
        
        public EquipmentItem(int id, string itemName, Sprite icon, bool canBeStacked, Sprite itemTierSprite, EquipmentSlot equipmentSlot , List<AttributeModifier> stats) : base(id, itemName, icon,canBeStacked,itemTierSprite)
        {
            EquipmentSlot = equipmentSlot;
            
            ItemTier = ItemTierManager.GetRandomItemTier();
            ItemTierColor = ItemTierManager.GetTierColor(ItemTier);

            Stats = stats;
        }
    }
}