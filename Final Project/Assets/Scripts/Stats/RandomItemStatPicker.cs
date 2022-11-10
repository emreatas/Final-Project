using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stat
{
    [Serializable]
    public class RandomItemStatPicker
    {
        public List<ItemStat> compulsoryItemStats = new List<ItemStat>();
        public List<ItemStat> randomItemStats = new List<ItemStat>();

        [SerializeField] private int randomStatCount;

        public List<AttributeModifier> GetRandomStats()
        {
            List<ItemStat> itemPool = new List<ItemStat>(randomItemStats);
            List<AttributeModifier> stats = new List<AttributeModifier>();

            for (int i = 0; i < compulsoryItemStats.Count; i++)
            {
                compulsoryItemStats[i].SetItemValue();
                AttributeModifier modifier = new AttributeModifier(compulsoryItemStats[i].statValue,
                    compulsoryItemStats[i].statType, compulsoryItemStats[i].attributeType);
                
                stats.Add( modifier);
            }
            
            for (int i = 0; i < randomStatCount; i++)
            {
                if (itemPool.Count <= 0)
                {
                    break;
                }
                
                int randomStatIndex = UnityEngine.Random.Range(0, itemPool.Count);

                var item = itemPool[randomStatIndex];
                item.SetItemValue();
                
                AttributeModifier modifier = new AttributeModifier(item.statValue,
                    item.statType, item.attributeType);
                
                stats.Add(modifier);
                itemPool.RemoveAt(randomStatIndex);
            }

            return stats;
        }
    }
}