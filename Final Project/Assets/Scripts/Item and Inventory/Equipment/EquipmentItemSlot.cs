using System;
using System.Collections;
using System.Collections.Generic;
using ItemManager;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace PInventory
{
    public class EquipmentItemSlot : MonoBehaviour
    {
        [SerializeField] private EquipmentSlotTypes slotType;
        [SerializeField] private EquipmentUI equipmentUI;
        [SerializeField] private Button equipmentSlotButton;
        
        [SerializeField] private Image iconImage;
        [SerializeField] private Image tierImage; 
        
        private InventoryItemData m_InventoryItemData;

        public EquipmentSlotTypes SlotType => slotType;

        private void OnEnable()
        {
            AddListeners();
        }
        
        private void OnDisable()
        {
            RemoveListeners();
        }

        public void InitializeSlot(InventoryItemData itemData)
        {
            m_InventoryItemData = itemData;
            SetUIElements(itemData);
        }
        
        public void EquipItem(InventoryItemData itemData)
        {
            m_InventoryItemData = itemData;
            SetUIElements(itemData);
        }
        
        public void UnequipItem(InventoryItemData itemData)
        {
            if (itemData.Item.equipmentSlotTypes == slotType)
            {
                m_InventoryItemData = null;
                ResetUIElements();
            }
        }

        private void HandleOnEquipmentSlotButtonClick()
        {
            if (m_InventoryItemData != null)
            {
                Debug.Log(m_InventoryItemData.Item.Icon);
                equipmentUI.ShowItem(m_InventoryItemData);
            }
        }

        private void SetUIElements(InventoryItemData itemData)
        {
            iconImage.sprite = itemData.Item.Icon;
            tierImage.sprite = itemData.Item.ItemTierSprite;

            tierImage.enabled = true;
            iconImage.enabled = true;
        }

        private void ResetUIElements()
        {
            iconImage.sprite = null;
            tierImage.sprite = null;
            
            tierImage.enabled = false;
            iconImage.enabled = false;
        }
        
        private void AddListeners()
        {
            equipmentSlotButton.onClick.AddListener(HandleOnEquipmentSlotButtonClick);
        }
        
        private void RemoveListeners()
        {
            equipmentSlotButton.onClick.RemoveListener(HandleOnEquipmentSlotButtonClick);
        }
    }
}