using System.Collections.Generic;
using ItemManager;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Chest")]
    public class ChestLoot : ScriptableObject
    {
        [SerializeField] private List<ItemSettings> constantDropItems = new List<ItemSettings>();
        [SerializeField] private List<ChestItem> randomDropItems = new List<ChestItem>();
        
        [SerializeField] private int minRandomItemDrop;
        [SerializeField] private int maxRandomItemDrop;

        private List<Item> m_ChestItems;

        public List<Item> GetRandomLoot()
        {
            m_ChestItems = new List<Item>();
            
            AddConstantItemsToDrop();
            AddRandomItemsToDrop();
            
            return m_ChestItems;
        }

        private void AddConstantItemsToDrop()
        {
            for (int i = 0; i < constantDropItems.Count; i++)
            {
                var newItem = constantDropItems[i].CreateNewItem();
                m_ChestItems.Add(newItem);
            }
        }
        
        private void AddRandomItemsToDrop()
        {
            int randomItemDropCount = GetRandomItemDropCount();
            
            for (int i = 0; i < randomItemDropCount; i++)
            {
               GetRandomItemFromChest();
            }
        }
        
        private void GetRandomItemFromChest()
        {
            float randomDropChance = Random.Range(0, CalculateTotalItemDropChance());

            for (int j = 0; j < randomDropItems.Count; j++)
            {
                randomDropChance -= randomDropItems[j].DropChance;
                
                if (randomDropChance <= 0)
                {
                    var newItem = randomDropItems[j].Item.CreateNewItem();
                    m_ChestItems.Add(newItem);
                    break;
                }
            }
        }
        
        private float CalculateTotalItemDropChance()
        {
            float totalChance = 0; 
            for (int i = 0; i < randomDropItems.Count; i++)
            {
                totalChance += randomDropItems[i].DropChance;
            }

            return totalChance;
        }

        public int GetRandomItemDropCount()
        {
            return Random.Range(minRandomItemDrop, maxRandomItemDrop + 1);
        }
    }
}