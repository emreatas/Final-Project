using System;
using System.Collections;
using System.Collections.Generic;
using ItemManager;
using PInventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySelectedItemUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Image tierImage;
    
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private List<TextMeshProUGUI> itemStatTextList = new List<TextMeshProUGUI>();

    private Item m_SelectedItem;
    
    private void Start()
    {
        AddListeners();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }

    private void HandleOnShowSelectedItem(Item item)
    {
        m_SelectedItem = item;
        
        SetUIElements(item);
        EnableUIElements();
    }

    private void ShowUIButtons()
    {
        
    }

    private void SetUIElements(Item item)
    {
        iconImage.sprite = item.Icon;
        tierImage.sprite = item.ItemTierSprite;
        itemNameText.text = item.ItemName;
/*
        for (int i = 0; i < item.stats.Count; i++)
        {
            itemStatTextList[i].text = item.stats[i].GetText();
        }
  */    
    }

    private void EnableUIElements()
    {
        iconImage.enabled = true;
        tierImage.enabled = true;
    }

    private void DisableUIElements()
    {
        ResetUIElements();
        
        iconImage.enabled = false;
        tierImage.enabled = false;
    }

    private void ResetUIElements()
    {
        iconImage.sprite = null;
        tierImage.sprite = null;

        itemNameText.text = "";

        for (int i = 0; i < itemStatTextList.Count; i++)
        {
            itemStatTextList[i].text = "";
        }
    }
    
    private void AddListeners()
    {
        InventoryUI.OnShowSelectedItem.AddListener(HandleOnShowSelectedItem);
    }

    private void RemoveListeners()
    {
        InventoryUI.OnShowSelectedItem.RemoveListener(HandleOnShowSelectedItem);
    }
}
