using System;
using UnityEngine;
using InventorySystem;
using PInventory;

namespace Items
{
    [Serializable]
    public class ChestItem
    {
        [SerializeField] private Item item;
        [SerializeField] private float dropChance;

        public Item Item => item;
        public float DropChance => dropChance;
    }
}