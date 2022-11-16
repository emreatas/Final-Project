using System;
using UnityEngine;
using InventorySystem;
using ItemManager;
using PInventory;

namespace Items
{
    [Serializable]
    public class ChestItem
    {
        [SerializeField] private ItemSettings item;
        [SerializeField] private float dropChance;

        public ItemSettings Item => item;
        public float DropChance => dropChance;
    }
}