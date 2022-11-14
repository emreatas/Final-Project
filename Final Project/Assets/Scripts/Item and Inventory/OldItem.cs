using System;
using System.Collections.Generic;
using Stat;
using UnityEngine;
using Utils;

namespace Items
{
    [CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Inventory/Item")]
    public class OldItem : ScriptableObject
    {

        public string itemName = "New Item";
        public ItemClass itemClass;
        public Sprite Icon = null;
        public ItemTier tier;
        public Sprite tierSprite;
        public bool isDefaultItem = false;
        public List<AttributeModifier> stats = new List<AttributeModifier>();

        //public List<ItemStat> compulsoryItemStats = new List<ItemStat>();
        //public List<ItemStat> randomItemStats = new List<ItemStat>();

        public RandomItemStatPicker itemStatPool;

        public Color GetTierColor()
        {
            switch (tier)
            {
                case ItemTier.NoTier:
                    return new Color(0, 0, 0, 1);
                case ItemTier.Standart:
                    return Color.green;
                case ItemTier.Rare:
                    return Color.blue;
                case ItemTier.Epic:
                    return Color.magenta;
                case ItemTier.Legendary:
                    return Color.yellow;
                default:
                    return new Color(0, 0, 0, 1);
            }
        }

        public void GetRandomStats()
        {
            stats = itemStatPool.GetRandomStats();

        }

        public virtual void Use()
        {

        }

        public virtual void Unequip()
        {

        }

        public void RemoveFromInventory()
        {
            // Inventory.Instance.Remove(this);
        }





    }
    public enum ItemClass
    {
        All,
        Mage,
        Knight
    }
    public enum ItemTier
    {
        NoTier,
        Standart,
        Rare,
        Epic,
        Legendary
    }
}