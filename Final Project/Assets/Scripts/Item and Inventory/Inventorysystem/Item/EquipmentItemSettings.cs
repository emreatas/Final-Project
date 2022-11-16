using Stat;
using UnityEngine;

namespace ItemManager
{
    [CreateAssetMenu(menuName = "ScriptableObjects/NewItem/EquipmentItem")]
    public class EquipmentItemSettings : ItemSettings
    {
        public EquipmentSlot EquipmentSlot;
        public RandomItemStatPicker itemStatPool;

        public override Item CreateNewItem()
        {
            return new EquipmentItem(ID, ItemName, Icon, CanBeStacked, EquipmentSlot, itemStatPool.GetRandomStats());
        }
    }
}