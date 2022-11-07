using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Items;
using Utils;
public class EquipmentSlotScript : MonoBehaviour
{
    public EquipmentSlot slot;

    public Image itemIcon;
    public Image itemTier;

    public EquipmentItem item;

    public void UseItem()
    {

        itemIcon.enabled = true;
        itemIcon.sprite = item.Icon;

        itemTier.enabled = true;
        itemTier.sprite = item.tierSprite;
        itemTier.color = item.GetTierColor();

    }

    public void UnequipItem()
    {


        itemIcon.enabled = false;
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


















