using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stat;

namespace NewInventory
{
    [CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
    public class EquipmentObject : ItemObject
    {
        public List<AttributeModifier> attributeModifiers;

        private void Awake()
        {
            type = ItemType.Equipment;
        }
    }
}