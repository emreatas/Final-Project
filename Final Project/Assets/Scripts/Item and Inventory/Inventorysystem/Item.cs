using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PInventory
{
    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        public ItemClass ItemClass;
        public string ItemName;
        public Sprite Icon;
        public Sprite TierImage;
        public ItemTier tier;

        public bool CanBeStacked;

        public List<Stat.AttributeModifier> stats = new List<Stat.AttributeModifier>();

        public Stat.RandomItemStatPicker itemStatPool;
        
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
