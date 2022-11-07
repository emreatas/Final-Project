using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("----Inventory----")]
    public Transform itemsParent;
    public InventorySlot[] slots;
    Inventory inventory;

    [Header("----Equipment----")]
    public EquipmentSlotScript[] equipmentSlots;
    public Transform equipmentParent;




    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();


        //  equipmentSlots = equipmentParent.GetComponentsInChildren<EquipmentSlotScript>();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);

            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }







}
