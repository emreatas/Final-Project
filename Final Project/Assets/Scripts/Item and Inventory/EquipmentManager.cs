using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Items;
public class EquipmentManager : AbstractSingelton<EquipmentManager>
{
    public Dictionary<EquipmentSlot, EquipmentSlotScript> equipmentItems;

    public static GameEvent<EquipmentItem> OnEquipItem;
    public static GameEvent<EquipmentItem> OnUnequipItem;

    Inventory inventory;
    private void Start()
    {
        inventory = Inventory.Instance;

        InitSlots();
    }

    private void InitSlots()
    {
        equipmentItems = new Dictionary<EquipmentSlot, EquipmentSlotScript>();

        for (int i = 0; i < transform.childCount; i++)
        {
            EquipmentSlotScript es = transform.GetChild(i).GetComponent<EquipmentSlotScript>();
            if (es != null)
            {

                equipmentItems[es.slot] = es;
            }
        }
    }

    public void Equip(EquipmentItem newItem)
    {
        if (equipmentItems.ContainsKey(newItem.slot))
        {
            EquipmentItem oldItem = equipmentItems[newItem.slot].item;

            if (oldItem != null)
            {
                OnUnequipItem.Invoke(oldItem);
                inventory.Add(oldItem);
            }
        }
        OnEquipItem.Invoke(newItem);
        equipmentItems[newItem.slot].item = newItem;
        equipmentItems[newItem.slot].UseItem();
    }
    public void Unequip(EquipmentItem newItem)
    {
        if (equipmentItems.ContainsKey(newItem.slot))
        {
            OnUnequipItem.Invoke(newItem);
            inventory.Add(newItem);
            equipmentItems[newItem.slot].item = null;
            equipmentItems[newItem.slot].UnequipItem();
        }
    }
}
