using System;
using System.Collections;
using System.Collections.Generic;
using ItemManager;
using PInventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class InventorySelectedItemUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Image tierImage;
    
    [SerializeField] private Button equipButton;
    [SerializeField] private Button unequipButton;
    [SerializeField] private Button deleteButton;

    
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private List<TextMeshProUGUI> itemStatTextList = new List<TextMeshProUGUI>();

    private InventoryItemData m_SelectedItemData;

    public static GameEvent<InventoryItemData> OnEquipItem;
    
    private void Start()
    {
        AddListeners();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }

    private void HandleOnShowSelectedItem(InventoryItemData itemData)
    {
        m_SelectedItemData = itemData;
        
        SetUIElements(itemData.Item);
        EnableUIElements();

        ShowInventorySlotButtons();
    }

    public void _OnEquipButtonClick()
    {
        OnEquipItem.Invoke(m_SelectedItemData);
    }
    
    public void _OnUnequipButtonClick()
    {
        
    }
    
    public void _OnDeleteButtonClick()
    {
        
    }
    
    private void ShowInventorySlotButtons()
    {
        equipButton.gameObject.SetActive(true);
        deleteButton.gameObject.SetActive(true);
    }

    private void ShowEquipmentSlotButtons()
    {
        unequipButton.gameObject.SetActive(true);
        deleteButton.gameObject.SetActive(true);
    }

    private void SetUIElements(Item item)
    {
        iconImage.sprite = item.Icon;
        tierImage.sprite = item.ItemTierSprite;
        itemNameText.text = item.ItemName;

        var equipmentItem = item as EquipmentItem;
        
        for (int i = 0; i < equipmentItem.Stats.Count; i++)
        {
            itemStatTextList[i].text = equipmentItem.Stats[i].GetText();
        }
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
        
        equipButton.gameObject.SetActive(false);
        unequipButton.gameObject.SetActive(false);
        deleteButton.gameObject.SetActive(false);
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
