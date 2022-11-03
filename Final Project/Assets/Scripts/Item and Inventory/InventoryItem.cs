using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CanvasNS;
using Items;
public class InventoryItem : MonoBehaviour
{
    public void ShowItem()
    {
        CanvasManager.instance.OnShowItem(gameObject.GetComponent<Item>());
    }
}
