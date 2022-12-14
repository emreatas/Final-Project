using System.Collections;
using Items;
using UnityEngine;

namespace ItemManager
{
    [CreateAssetMenu(menuName = "ScriptableObjects/NewItem/Item")]
    public class ItemSettings : ScriptableObject
    {
        public int ID;
        public string ItemName;
        public Sprite Icon;
        public Sprite ItemTierSprite;

        public bool CanBeStacked;

        public int defaultCoinValue;
        public int sellValue;
        public int buyValue;


        public virtual Item CreateNewItem()
        {
            return new Item(ID, ItemName, Icon, CanBeStacked, ItemTierSprite);
        }
    }
}
