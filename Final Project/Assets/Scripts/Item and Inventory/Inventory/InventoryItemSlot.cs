using System.Collections;
using System.Collections.Generic;
using PInventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class InventoryItemSlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image tier;
    [SerializeField] private TextMeshProUGUI countText;
    
    private InventoryItemData m_ItemData;

    private InventoryUI m_InventoryUI;
    
    public InventoryItemData ItemData => m_ItemData;
    
    public void InitSlot(InventoryItemData itemData, InventoryUI inventoryUI)
    {
        m_ItemData = itemData;
        m_InventoryUI = inventoryUI;
        
        SetUIElements(itemData);
    }

    private void SetUIElements(InventoryItemData itemData)
    {
        icon.sprite = itemData.Item.Icon;
        tier.sprite = itemData.Item.ItemTierSprite;
        SetUIItemCount(itemData);
    }

    private void SetUIItemCount(InventoryItemData itemData)
    {
        if (itemData.Item.CanBeStacked)
        {
            countText.text = itemData.Count.ToString();
        }
        else
        {
            countText.text = "";
        }
    }
    
    public void SetItemCount(int count)
    {
        m_ItemData.Count = count;
        countText.text = m_ItemData.Count.ToString();
    }

    public void DestroySlot()
    {
        Destroy(gameObject);
    }
    
    public void _OnItemSelect()
    {
        m_InventoryUI.ShowItem(m_ItemData);
    }
}
