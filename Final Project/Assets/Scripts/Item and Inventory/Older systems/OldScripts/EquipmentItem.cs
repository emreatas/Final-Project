using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using InventorySystem;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Inventory/Equipment")]
public class EquipmentItem : Item
{

    public EquipmentSlot slot;


}


public enum EquipmentSlot
{
    Head,
    Chest,
    Shoes,
    Wapon,
    Accessory,
    Wings
}