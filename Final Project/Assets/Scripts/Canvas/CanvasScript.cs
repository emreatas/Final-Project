using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CanvasNS
{
    public class CanvasScript : MonoBehaviour
    {
        public GameObject interactButton;
        public GameObject deleteButton;
        public GameObject equipButton;
        [SerializeField] private GameObject interactItemPanel;


        [Header("Inventory Item Button")]
        public UnityEngine.UI.Image itemIcon;
        public UnityEngine.UI.Image itemTier;
        public TMPro.TextMeshProUGUI itemName;

        private Items.Item showedItem;

        private void OnEnable()
        {
            CanvasManager.InteractableStart += CanvasManager_InteractableStart1;
            CanvasManager.ItemDropPanelStart += CanvasManagerOnItemDropPanelStart;
            CanvasManager.ShowItem += CanvasManager_ShowItem;

        }

        public void DeleteItem()
        {
            if (showedItem != null)
            {
                Inventory.Instance.Remove(showedItem);
                itemIcon.enabled = false;
                itemTier.enabled = false;
                itemName.enabled = false;
                deleteButton.SetActive(false);
                equipButton.SetActive(false);
            }
        }

        public void UseItem()
        {
            if (showedItem != null)
            {
                showedItem.Use();
            }
        }

        private void CanvasManager_ShowItem(Items.Item obj)
        {
            showedItem = obj;


            itemIcon.enabled = true;
            itemTier.enabled = true;
            itemName.enabled = true;
            deleteButton.SetActive(true);
            equipButton.SetActive(true);

            itemIcon.sprite = obj.Icon;
            itemTier.sprite = obj.tierSprite;
            itemTier.color = obj.GetTierColor();
            itemName.text = obj.itemName;

        }

        private void CanvasManagerOnItemDropPanelStart(bool obj)
        {
            interactItemPanel.SetActive(obj);
        }

        private void CanvasManager_InteractableStart1(bool obj)
        {
            interactButton.SetActive(obj);

        }


        private void OnDisable()
        {
            CanvasManager.InteractableStart -= CanvasManager_InteractableStart1;
            CanvasManager.ItemDropPanelStart -= CanvasManagerOnItemDropPanelStart;
            CanvasManager.ShowItem -= CanvasManager_ShowItem;


        }

        public void InventoryUI(GameObject inventoryPanel)
        {
            inventoryPanel.SetActive(true);
        }

        public void CloseButton(GameObject panel)
        {
            panel.SetActive(false);
        }
    }
}