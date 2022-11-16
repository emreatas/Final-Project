using System;
using System.Collections;
using System.Collections.Generic;
using ItemManager;
using UnityEngine;
using Utils;

namespace  PInventory
{
    public class InventoryUI : MonoBehaviour
    {
        
        [SerializeField] private InventoryItemSlot inventoryItemSlotPrefab;
        [SerializeField] private Transform inventorySlotParent;

        private List<InventoryItemSlot> m_InventoryItemList = new List<InventoryItemSlot>();

        public static GameEvent<Item> OnShowSelectedItem;
        public static GameEvent<Item> OnRemoveItem;
        
        private void Start()
        {
            AddListeners();
        } 
        
        private void OnDestroy()
        {
            RemoveListeners();
        }
        
        private void HandleOnInventoryInitialized(List<InventoryItemData> inventoryItemDataList)
        {
            for (int i = 0; i < inventoryItemDataList.Count; i++)
            {
                var itemSlot = Instantiate(inventoryItemSlotPrefab, inventorySlotParent);
                itemSlot.InitSlot(inventoryItemDataList[i], this);
                
                m_InventoryItemList.Add(itemSlot);
            }
        }

        private void HandleOnItemAddedToInventory(InventoryUIData inventoryUIData)
        {
            if (inventoryUIData.IsStacked)
            {
                for (int i = 0; i < m_InventoryItemList.Count; i++)
                {
                    if (m_InventoryItemList[i].ItemData.Item.ID == inventoryUIData.itemData.Item.ID)
                    {
                        m_InventoryItemList[i].SetItemCount(inventoryUIData.itemData.Count);
                        return;
                    }
                }
            }
         
            var instansiated = Instantiate(inventoryItemSlotPrefab,inventorySlotParent);
            instansiated.InitSlot(inventoryUIData.itemData, this);
            
            m_InventoryItemList.Add(instansiated);
        }
        
        private void HandleOnItemRemovedFromInventory(InventoryItemData itemData)
        {
            for (int i = 0; i < m_InventoryItemList.Count; i++)
            {
                if (m_InventoryItemList[i].ItemData == itemData)
                {
                    m_InventoryItemList[i].SetItemCount(itemData.Count);
                    return;
                }
            }
        }
        
        public void RemoveItem(Item item)
        {
            OnRemoveItem.Invoke(item);
        }

        public void ShowItem(Item item)
        {
            OnShowSelectedItem.Invoke(item);
        }
        
        private void AddListeners()
        {
            PlayerInventory.OnItemAddedToInventory.AddListener(HandleOnItemAddedToInventory);
            PlayerInventory.OnInventoryInitialize.AddListener(HandleOnInventoryInitialized);
            PlayerInventory.OnItemRemovedFromInventory.AddListener(HandleOnItemRemovedFromInventory);
        }
        
        private void RemoveListeners()
        {
            PlayerInventory.OnItemAddedToInventory.RemoveListener(HandleOnItemAddedToInventory);
            PlayerInventory.OnInventoryInitialize.RemoveListener(HandleOnInventoryInitialized);
            PlayerInventory.OnItemRemovedFromInventory.RemoveListener(HandleOnItemRemovedFromInventory);
        }
    }

}
