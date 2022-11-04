using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EquipmentManager : AbstractSingelton<EquipmentManager>
{

    EquipmentItem[] equipmentItems;

    Inventory inventory;
    private void Start()
    {
        inventory = Inventory.Instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;

        equipmentItems = new EquipmentItem[numSlots];

    }


    public void Equip(EquipmentItem newItem)
    {
        int slotIndex = (int)newItem.slot;

        EquipmentItem olditem = null;

        if (equipmentItems[slotIndex] != null)
        {
            olditem = equipmentItems[slotIndex];
            inventory.Add(olditem);
        }

        equipmentItems[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex)
    {
        if (equipmentItems[slotIndex] != null)
        {
            EquipmentItem oldItem = equipmentItems[slotIndex];
            inventory.Add(oldItem);

            equipmentItems[slotIndex] = null;
        }


    }


}
