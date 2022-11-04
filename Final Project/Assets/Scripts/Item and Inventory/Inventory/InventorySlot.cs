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

        itemIcon.enabled = true;
        itemIcon.sprite = item.Icon;

        itemTier.enabled = true;
        itemTier.sprite = item.tierSprite;
        itemTier.color = item.GetTierColor();
    }

    public void ClearSlot()
    {
        item = null;

        //itemIcon.sprite = null;
        itemIcon.enabled = false;

        //itemTier = null;
        itemTier.enabled = false;

    }

    public void ShowItem()
    {

        if (item != null)
        {
            CanvasNS.CanvasManager.instance.OnShowItem(item);
        }

    }


}
