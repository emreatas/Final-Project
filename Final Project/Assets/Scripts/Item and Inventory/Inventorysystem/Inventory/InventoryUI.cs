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
            Debug.Log("Holaa");
            for (int i = 0; i < inventoryItemDataList.Count; i++)
            {
                Debug.Log("Holaa");
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
                    m_InventoryItemList[i].SetItemCount(itemData.Count);
                    return;
                }
            }
        }

        private void InstansiateItemSlot(InventoryItemData itemData)
        {
            var instansiated = Instantiate(inventoryItemSlotPrefab,inventorySlotParent);
            instansiated.InitSlot(itemData, this);
            
            m_InventoryItemList.Add(instansiated);
        }
        
        public void RemoveItem(Item item)
        {
            OnRemoveItem.Invoke(item);
        }

        public void ShowItem(Item item)
        {
            OnShowSelectedItem.Invoke(item);
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
