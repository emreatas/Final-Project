using System;
using ItemManager;
using Items;
using ObjectPooling;
using PInventory;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils;

namespace InventorySystem
{
    public class InteractItemButton : MonoBehaviour
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private Image tierImage;
        [SerializeField] private TextMeshProUGUI itemName;

        [SerializeField] private Button itemButton;

        private Item m_Item;
        public event Action<Item> OnSelectItem;
        public event Action<InteractItemButton> OnResetItem;

        private GameEvent m_OnResetChest;

        private Chest m_ConnectedChest;

        
        public void InitializeItemButton(Item item, Chest connectedChest)
        {
            m_Item = item;
            SetUIElements(item);

            m_ConnectedChest = connectedChest;
            m_ConnectedChest.OnRemoveChestFromPanel.AddListener(HandleOnResetChest);
        }
        
        private void SetUIElements(Item item)
        {
            itemImage.sprite = item.Icon;
            tierImage.sprite = item.ItemTierSprite;
            //tierImage.color = item.ItemTierColor;
            itemName.text = item.ItemName;
        }
        
        public void _OnSelectItem()
        {
            m_ConnectedChest.OnSelectItem(m_Item);
            HandleOnResetChest();
        }
        
        public void HandleOnResetChest()
        {
            m_ConnectedChest.OnRemoveChestFromPanel.RemoveListener(HandleOnResetChest);
            Destroy(gameObject);
        }
    }
}