using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

namespace PInventory
{
    public class EquipmentSlots : ItemSlots
    {
        public EquipmentType EquipmentType;

        protected override void OnValidate()
        {
            base.OnValidate();
            gameObject.name = EquipmentType.ToString() + " Slot";
        }
    }

}