using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Items
{
    public class DroppedItem : MonoBehaviour
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private Image tierImage;
        [SerializeField] private TextMeshProUGUI itemName;

        [SerializeField] private Button itemButton;

        private Item m_Item;

        private event Action<Item> OnSelectItem;
        
        public void InitializeItemButton(Item item, Action<Item> onSelectItem)
        {
            itemImage.sprite = item.Icon;
            tierImage.sprite = item.tierSprite;
            tierImage.color = item.GetTierColor();
            itemName.text = item.ItemName;

            m_Item = item;
            
            OnSelectItem = onSelectItem;
            
            itemButton.onClick.AddListener(SelectItem);
        }

        private void SelectItem()
        {
            OnSelectItem?.Invoke(m_Item);
            OnSelectItem = null;
            
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            OnSelectItem = null;
        }
    }
}