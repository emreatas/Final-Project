using System;
using System.Collections;
using System.Collections.Generic;
using ItemManager;
using UnityEngine;
using UnityEngine.UI;

namespace PInventory
{
    public class EquipmentItemSlot : MonoBehaviour
    {
        [SerializeField] private EquipmentSlotTypes slotType;

        [SerializeField] private Image iconImage;
        [SerializeField] private Image tierImage; 
        
        private InventoryItemData m_InventoryItemData;
        
        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }
        
        private void HandleOnEquipItem(InventoryItemData itemData)
        {
            if (itemData.Item.equipmentSlotTypes == slotType)
            {
                m_InventoryItemData = itemData;
                
            }
        }
        private void AddListeners()
        {
            InventorySelectedItemUI.OnEquipItem.AddListener(HandleOnEquipItem);
        }

        private void RemoveListeners()
        {
            InventorySelectedItemUI.OnEquipItem.RemoveListener(HandleOnEquipItem);
        }
    }

}

