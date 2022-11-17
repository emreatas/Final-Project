using UnityEngine;

namespace ItemManager
{
    public class Item
    {
        public int ID;
        public string ItemName;
        public Sprite Icon;
        public bool CanBeStacked;
        public ItemTier ItemTier = ItemTier.NoTier;
        public Color ItemTierColor;

        public Sprite ItemTierSprite;
        
        public Item(int id, string itemName, Sprite icon, bool canBeStacked, Sprite itemTierSprite)
        {
            ID = id;
            ItemName = itemName;
            Icon = icon;
            CanBeStacked = canBeStacked;
            ItemTierSprite = itemTierSprite;

            ItemTierColor = ItemTierManager.GetTierColor(ItemTier);
        }
    }
}