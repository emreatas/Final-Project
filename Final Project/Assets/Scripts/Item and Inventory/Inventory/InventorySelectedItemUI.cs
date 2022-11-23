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
    public static GameEvent<InventoryItemData> OnUneqquipItem;
    public static GameEvent<InventoryItemData> OnDeleteItem;
    
    private void Start()
    {
        AddListeners();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }
    
    private void HandleOnShowSelectedInventoryItem(InventoryItemData itemData)
    {
        m_SelectedItemData = itemData;
        
        SetUIElements(itemData.Item);
        EnableUIElements();

        ShowInventorySlotButtons();
    }
    
    private void HandleOnShowSelectedEquipmentItem(InventoryItemData itemData)
    {
        m_SelectedItemData = itemData;
        
        SetUIElements(itemData.Item);
        EnableUIElements();

        ShowEquipmentSlotButtons();
    }

    public void HandleOnEquipButtonClick()
    {
        OnEquipItem.Invoke(m_SelectedItemData);
        
        DisableUIElements();
    }
    
    public void HandleOnUnequipButtonClick()
    {
        OnUneqquipItem.Invoke(m_SelectedItemData);
        
        DisableUIElements();
    }
    
    public void HandleOnDeleteButtonClick()
    {
        OnDeleteItem.Invoke(m_SelectedItemData);
        
        DisableUIElements();
    }
    
    private void ShowInventorySlotButtons()
    {
        unequipButton.gameObject.SetActive(false);
        
        equipButton.gameObject.SetActive(true);
        deleteButton.gameObject.SetActive(true);
    }

    private void ShowEquipmentSlotButtons()
    {
        equipButton.gameObject.SetActive(false);
        
        unequipButton.gameObject.SetActive(true);
        deleteButton.gameObject.SetActive(true);
    }

    private void SetUIElements(Item item)
    {
        iconImage.sprite = item.Icon;
        tierImage.sprite = item.ItemTierSprite;
        itemNameText.text = item.ItemName;

        for (int i = 0; i < item.Stats.Count; i++)
        {
            itemStatTextList[i].text = item.Stats[i].GetText();
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
        InventoryUI.OnShowSelectedItem.AddListener(HandleOnShowSelectedInventoryItem);
        EquipmentUI.OnShowSelectedItem.AddListener(HandleOnShowSelectedEquipmentItem);
        
        equipButton.onClick.AddListener(HandleOnEquipButtonClick);
        unequipButton.onClick.AddListener(HandleOnUnequipButtonClick);
        deleteButton.onClick.AddListener(HandleOnDeleteButtonClick);
    }

    private void RemoveListeners()
    {
        InventoryUI.OnShowSelectedItem.RemoveListener(HandleOnShowSelectedInventoryItem);
        EquipmentUI.OnShowSelectedItem.RemoveListener(HandleOnShowSelectedEquipmentItem);
        
        equipButton.onClick.RemoveListener(HandleOnEquipButtonClick);
        unequipButton.onClick.RemoveListener(HandleOnUnequipButtonClick);
        deleteButton.onClick.RemoveListener(HandleOnDeleteButtonClick);
    }
}
