using Stat;
using UnityEngine;

namespace ItemManager
{
    [CreateAssetMenu(menuName = "ScriptableObjects/NewItem/EquipmentItem")]
    public class EquipmentItemSettings : ItemSettings
    {
        public EquipmentSlotTypes equipmentSlotTypes;
        public RandomItemStatPicker itemStatPool;

        public override Item CreateNewItem()
        {
            return new EquipmentItem(ID, ItemName, Icon, CanBeStacked, ItemTierSprite,equipmentSlotTypes, itemStatPool.GetRandomStats());
        }
    }
}