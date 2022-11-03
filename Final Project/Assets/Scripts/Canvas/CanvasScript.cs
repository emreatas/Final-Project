using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CanvasNS
{
    public class CanvasScript : MonoBehaviour
    {
        public GameObject interactButton;
        [SerializeField] private GameObject interactItemPanel;


        [Header("Inventory Item Button")]
        public UnityEngine.UI.Image itemIcon;
        public UnityEngine.UI.Image itemTier;
        public TMPro.TextMeshProUGUI itemName;


        private void OnEnable()
        {
            CanvasManager.InteractableStart += CanvasManager_InteractableStart1;
            CanvasManager.ItemDropPanelStart += CanvasManagerOnItemDropPanelStart;
            CanvasManager.ShowItem += CanvasManager_ShowItem;

        }

        private void CanvasManager_ShowItem(Items.Item obj)
        {

            itemIcon.sprite = obj.Icon;
            itemTier.sprite = obj.tierSprite;
            itemTier.color = obj.GetTierColor();
            itemName.text = obj.name;

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

        public void Inventory(GameObject inventoryPanel)
        {
            inventoryPanel.SetActive(true);
        }

        public void CloseButton(GameObject panel)
        {
            panel.SetActive(false);
        }
    }
}