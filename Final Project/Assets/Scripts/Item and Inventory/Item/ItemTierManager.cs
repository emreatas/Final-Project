using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemManager
{
    public static class ItemTierManager
    {
        public static ItemTier GetRandomItemTier()
        {
            int randomTierIndex = Random.Range(0, Enum.GetNames(typeof(ItemTier)).Length);

            ItemTier tier = (ItemTier)randomTierIndex;

            return tier;
        }

        public static Color GetTierColor(ItemTier tier)
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