using System;
using System.Collections;
using System.Collections.Generic;
using ItemManager;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace  PInventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventoryItemSlot inventoryItemSlotPrefab;
        [SerializeField] private Transform inventorySlotParent;

        [SerializeField] private Transform inventoryPanel;
        [SerializeField] private Button inventoryOpenButton;
        [SerializeField] private Button inventoryCloseButton;

        private List<InventoryItemSlot> m_InventoryItemList = new List<InventoryItemSlot>();

        public static GameEvent<InventoryItemData> OnShowSelectedItem;
        
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
                InstansiateItemSlot(inventoryItemDataList[i]);
            }
        }

        private void HandleOnItemAddedToInventory(InventoryItemData inventoryUIData)
        {
            if (inventoryUIData.Item.CanBeStacked)
            {
                for (int i = 0; i < m_InventoryItemList.Count; i++)
                {
                    if (IDsAreEqual(m_InventoryItemList[i].ItemData, inventoryUIData))
                    {
                        m_InventoryItemList[i].SetItemCount(inventoryUIData.Count);
                        return;
                    }
                }
            }
            
            InstansiateItemSlot(inventoryUIData);
        }
        
        private void HandleOnItemRemovedFromInventory(InventoryItemData itemData)
        {
            for (int i = 0; i < m_InventoryItemList.Count; i++)
            {
                if (ItemsAreEqual(m_InventoryItemList[i].ItemData, itemData))
                {
                    if (itemData.Count <= 0)
                    {
                        m_InventoryItemList[i].DestroySlot();
                        m_InventoryItemList.RemoveAt(i);
                        return;
                    }
                    else
                    {
                        m_InventoryItemList[i].SetItemCount(itemData.Count);
                        return;
                    }
                }
            }
        }

        private void InstansiateItemSlot(InventoryItemData itemData)
        {
            var instansiated = Instantiate(inventoryItemSlotPrefab,inventorySlotParent);
            instansiated.InitSlot(itemData, this);
            
            m_InventoryItemList.Add(instansiated);
        }
        
        public void ShowItem(InventoryItemData itemData)
        {
            OnShowSelectedItem.Invoke(itemData);
        }

        public void HandleOnOpenInventoryPanel()
        {
            inventoryPanel.gameObject.SetActive(true);
        }
        
        private void HandleOnCloseInventoryPanel()
        {
            inventoryPanel.gameObject.SetActive(false);
        }

        private bool IDsAreEqual(InventoryItemData firstItemData,InventoryItemData secondItemData)
        {
            return firstItemData.Item.ID == secondItemData.Item.ID;
        }

        private bool ItemsAreEqual(InventoryItemData firstItemData, InventoryItemData secondItemData)
        {
            return firstItemData == secondItemData;
        }
        
        private void AddListeners()
        {
            PlayerInventory.OnItemAddedToInventory.AddListener(HandleOnItemAddedToInventory);
            PlayerInventory.OnInitializeInventory.AddListener(HandleOnInventoryInitialized);
            PlayerInventory.OnItemRemovedFromInventory.AddListener(HandleOnItemRemovedFromInventory);
            
            inventoryOpenButton.onClick.AddListener(HandleOnOpenInventoryPanel);
            inventoryCloseButton.onClick.AddListener(HandleOnCloseInventoryPanel);
        }
        
        private void RemoveListeners()
        {
            PlayerInventory.OnItemAddedToInventory.RemoveListener(HandleOnItemAddedToInventory);
            PlayerInventory.OnInitializeInventory.RemoveListener(HandleOnInventoryInitialized);
            PlayerInventory.OnItemRemovedFromInventory.RemoveListener(HandleOnItemRemovedFromInventory);
            
            inventoryOpenButton.onClick.RemoveListener(HandleOnOpenInventoryPanel);
            inventoryCloseButton.onClick.RemoveListener(HandleOnCloseInventoryPanel);
            
        }
    }

}
