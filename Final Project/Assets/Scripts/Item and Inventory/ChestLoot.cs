using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Items
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Chest")]
    public class ChestLoot : ScriptableObject
    {
        public List<Item> dropableItem;

        public Dictionary<Item, GameObject> instansiatedItems = new Dictionary<Item, GameObject>();

        public void SelectItemFromChest(Item item)
        {
            instansiatedItems.Remove(item);
            dropableItem.Remove(item);
        }
    }
}