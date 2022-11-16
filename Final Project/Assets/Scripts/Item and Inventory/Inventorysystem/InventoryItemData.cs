using System;

namespace PInventory
{
    [Serializable]
    public class InventoryItemData
    {
        public Item Item;
        public int Count;

        public InventoryItemData(Item item, int count = 1)
        {
            Item = item;
            Count = count;
        }

        public void AddAmount(int amount)
        {
            Count += amount;
        }

        public void RemoveAmount(int amount)
        {
            Count -= amount;
        }
    }
}