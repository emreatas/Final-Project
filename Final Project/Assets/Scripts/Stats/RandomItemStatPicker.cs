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

        public List<ItemStat> GetRandomStats()
        {
            List<ItemStat> itemPool = new List<ItemStat>(randomItemStats);
            List<ItemStat> stats = new List<ItemStat>();
            
            stats.AddRange(compulsoryItemStats);

            for (int i = 0; i < randomStatCount; i++)
            {
                if (itemPool.Count <= 0)
                {
                    break;
                }
                
                int randomStatIndex = UnityEngine.Random.Range(0, itemPool.Count);
                stats.Add(itemPool[randomStatIndex]);
                itemPool.RemoveAt(randomStatIndex);
            }

            return stats;
        }
    }
}