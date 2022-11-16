using System.Collections;
using System.Collections.Generic;
using PInventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image tier;
    [SerializeField] private TextMeshProUGUI countText;
    
    private InventoryItemData m_ItemData;

    public InventoryItemData ItemData => m_ItemData;

    private PInventory.InventoryUI m_InventoryUI;

    private bool ItemDestroyed => m_ItemData.Count <= 0;
    
    public void InitSlot(InventoryItemData itemData, PInventory.InventoryUI inventoryUI)
    {
        m_ItemData = itemData;
        icon.sprite = itemData.Item.Icon;
        //tier.sprite = itemData.Item.;

        m_InventoryUI = inventoryUI;
        
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

        if (ItemDestroyed)
        {
            Destroy(gameObject);
        }
    }

    public void RemoveItem()
    {
        m_InventoryUI.RemoveItem(m_ItemData.Item);
    }

    public void _OnItemSelect()
    {
        m_InventoryUI.ShowItem(m_ItemData.Item);
    }
}
