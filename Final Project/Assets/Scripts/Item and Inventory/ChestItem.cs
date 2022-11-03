using System;
using UnityEngine;

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