using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Items;
public class InventorySlot : MonoBehaviour
{
    public Image itemIcon;
    public Image itemTier;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        itemIcon.sprite = item.Icon;
        itemTier.sprite = item.tierSprite;
        itemIcon.enabled = true;
        itemTier.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        itemIcon.sprite = null;
        itemTier = null;
        itemIcon.enabled = false;
        itemTier.enabled = false;



    }
}
