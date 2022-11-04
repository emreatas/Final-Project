using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Inventory/Equipment")]
public class EquipmentItem : Item
{

    public EquipmentSlot slot;

    public override void Use()
    {
        base.Use();
        EquipmentManager.Instance.Equip(this);
    }


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