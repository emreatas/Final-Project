using System;
using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace ItemManager
{
    [Serializable]
    public class Item
    {
        public int ID;
        public string ItemName;
        public Sprite Icon;
        public bool CanBeStacked;
        public ItemTier ItemTier = ItemTier.NoTier;
        public Color ItemTierColor;


        public EquipmentSlotTypes equipmentSlotTypes;

        public List<AttributeModifier> Stats;

        public Sprite ItemTierSprite;

        public Item(int id, string itemName, Sprite icon, bool canBeStacked, Sprite itemTierSprite)
        {
            ID = id;
            ItemName = itemName;
            Icon = icon;
            CanBeStacked = canBeStacked;
            ItemTierSprite = itemTierSprite;
            Stats = new List<AttributeModifier>();
            ItemTierColor = ItemTierManager.GetTierColor(ItemTier);
        }
    }
}