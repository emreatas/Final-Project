using System;
using ItemManager;
using ObjectPooling;
using PInventory;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils;

namespace InventorySystem
{
    public class DroppedItem : MonoBehaviour
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private Image tierImage;
        [SerializeField] private TextMeshProUGUI itemName;

        [SerializeField] private Button itemButton;


        private Item m_Item;

        public event Action<Item> OnSelectItem;

        public void InitializeItemButton(Item item, Action<Item> onSelectItem)
        {
            m_Item = item;
            
            itemImage.sprite = item.Icon;
            //tierImage.sprite = item.TierImage;
            //tierImage.color = item.GetTierColor();
            itemName.text = item.ItemName;
            
            OnSelectItem = onSelectItem;

            itemButton.onClick.AddListener(InvokeSelectItem);
        }

        private void InvokeSelectItem()
        {
            OnSelectItem?.Invoke(m_Item);
            OnSelectItem = null;

            Destroy(gameObject);
        }
    }
}