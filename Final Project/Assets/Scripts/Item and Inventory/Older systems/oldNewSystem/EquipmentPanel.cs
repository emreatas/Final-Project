using System.Collections;
using System.Collections.Generic;
using PInventory;
using UnityEngine;

namespace InventorySystem
{
    public class EquipmentPanel : MonoBehaviour
    {
        [SerializeField] Transform equipmentSlotsParent;
        [SerializeField] EquipmentSlots[] equipmentSlots;


        public event System.Action<Item> OnItemRightClickedEvet;

        private void Start()
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                equipmentSlots[i].OnRightClickEvet += OnItemRightClickedEvet;
            }
        }

        private void OnValidate()
        {
            equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlots>();

        }

        public bool AddItem(EquippableItem item, out EquippableItem previousItem)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].EquipmentType == item.equipmentType)
                {
                    previousItem = (EquippableItem)equipmentSlots[i].Item;
                    equipmentSlots[i].Item = item;
                    return true;
                }
            }
            previousItem = null;
            return false;
        }
        public bool RemoveItem(EquippableItem item)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].Item == item)
                {
                    equipmentSlots[i].Item = null;
                    return true;
                }
            }
            return false;
        }
    }

}