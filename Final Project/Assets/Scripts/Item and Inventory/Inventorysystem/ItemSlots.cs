using System.Collections;
using System.Collections.Generic;
using PInventory;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace InventorySystem
{

    public class ItemSlots : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
    {
        [SerializeField] Image ItemImage;
        [SerializeField] Image ItemTier;

        public event System.Action<Item> OnRightClickEvet;

        private Item _item;
        public Item Item
        {
            get { return _item; }
            set
            {
                _item = value;

                if (_item == null)
                {
                    ItemImage.enabled = false;
                    ItemTier.enabled = false;
                }
                else
                {
                    ItemImage.sprite = _item.Icon;
                    ItemTier.sprite = _item.TierImage;
                    ItemTier.color = _item.GetTierColor();
                    ItemImage.enabled = true;
                    ItemTier.enabled = true;
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData != null)
            {
                if (OnRightClickEvet != null)
                {

                    OnRightClickEvet(_item);
                    Debug.Log("click click bum be " + _item);

                }

            }
        }

        protected virtual void OnValidate()
        {

        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }
    }



}