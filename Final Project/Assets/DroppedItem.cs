using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DroppedItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Image tierImage;
    [SerializeField] private TextMeshProUGUI itemName;

    public void InitializeItemButton(Item item)
    {
        itemImage.sprite = item.Icon;
        tierImage.color = item.GetTierColor();
        itemName.text = item.ItemName;
    }
    
}
