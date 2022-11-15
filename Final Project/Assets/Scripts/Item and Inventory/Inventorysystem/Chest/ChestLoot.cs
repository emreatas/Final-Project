using System.Collections.Generic;
using PInventory;
using UnityEngine;
using Utils;
using Random = System.Random;

namespace Items
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Chest")]
    public class ChestLoot : ScriptableObject
    {
        [SerializeField] private List<Item> constantDropItems = new List<Item>();
        [SerializeField] private List<ChestItem> randomDropItems = new List<ChestItem>();
        [SerializeField] private int minRandomItemDrop;
        [SerializeField] private int maxRandomItemDrop;
        public List<Item> GetRandomLoot()
        {
            List<Item> dropItemList = new List<Item>();
            //dropItemList.AddRange(constantDropItems);

            for (int i = 0; i < constantDropItems.Count; i++)
            {
                dropItemList.Add(Instantiate(constantDropItems[i]));
            }

            float totalChance = 0;
            for (int i = 0; i < randomDropItems.Count; i++)
            {
                totalChance += randomDropItems[i].DropChance;
            }

            int randomItemDropCount = UnityEngine.Random.Range(minRandomItemDrop, maxRandomItemDrop + 1);
            for (int i = 0; i < randomItemDropCount; i++)
            {
                float randomNumber = UnityEngine.Random.Range(0, totalChance);

                for (int j = 0; j < randomDropItems.Count; j++)
                {
                    randomNumber -= randomDropItems[j].DropChance;
                    if (randomNumber <= 0)
                    {
                        dropItemList.Add(Instantiate(randomDropItems[j].Item));
                        break;
                    }
                }
            }

            for (int i = 0; i < dropItemList.Count; i++)
            {
                dropItemList[i].GetRandomStats();
            }

            return dropItemList;
        }
    }
}