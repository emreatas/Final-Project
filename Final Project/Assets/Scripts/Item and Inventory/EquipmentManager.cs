using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EquipmentManager : AbstractSingelton<EquipmentManager>
{

    EquipmentItem[] equipmentItems;


    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;

        equipmentItems = new EquipmentItem[numSlots];

    }


    public void Equip(EquipmentItem newItem)
    {
        int slotIndex = (int)newItem.slot;


        equipmentItems[slotIndex] = newItem;
    }




}
