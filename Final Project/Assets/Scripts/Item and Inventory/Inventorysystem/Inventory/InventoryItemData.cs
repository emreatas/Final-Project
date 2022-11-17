﻿using System;
using ItemManager;

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

        public void IncreaseItemAmount(int amount)
        {
            Count += amount;
        }

        public void DecreaseItemAmount(int amount)
        {
            Count -= amount;
        }
    }
}