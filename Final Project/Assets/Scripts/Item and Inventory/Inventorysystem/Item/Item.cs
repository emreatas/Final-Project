using UnityEngine;

namespace ItemManager
{
    public class Item
    {
        public int ID;
        public string ItemName;
        public Sprite Icon;
        public bool CanBeStacked;
        
        public Item(int id, string itemName, Sprite icon, bool canBeStacked)
        {
            ID = id;
            ItemName = itemName;
            Icon = icon;
            CanBeStacked = canBeStacked;
        }
    }
}