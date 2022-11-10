using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Stat;
using System;
using Player;

namespace CanvasNS
{
    public class CanvasScript : MonoBehaviour
    {
        public GameObject interactButton;
        public GameObject deleteButton;
        public GameObject equipButton;
        public GameObject unEquipButton;


        [Header("Stat Texts")]
        public List<StatTexts> statTexts;




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
            CanvasManager.ShowInventoryItem += CanvasManager_ShowInventoryItem;
            CanvasManager.ShowEquipItem += CanvasManager_ShowEquipItem;

            PlayerStats.OnCharacterStatsInitialized.AddListener(HandleOnInitializeStats);
            PlayerStats.OnCharacterAttributeUpdated.AddListener(HandleOnCharacterAttributeUpdated);


        }

        private void HandleOnInitializeStats(CharacterStat characterStats)
        {
            for (int i = 0; i < characterStats.CharacterAttributes.Count; i++)
            {
                for (int j = 0; j < statTexts.Count; j++)
                {
                    if (statTexts[j].statType == characterStats.CharacterAttributes[i].StatType)
                    {
                        statTexts[j].text.text = $" : {characterStats.CharacterAttributes[i].CalculateFinalValue()}";
                        break;
                    }
                }
            }

           
        }

        private void HandleOnCharacterAttributeUpdated(CharacterAttribute characterAttribute)
        {
            for (int i = 0; i < statTexts.Count; i++)
            {
                if (statTexts[i].statType == characterAttribute.StatType)
                {
                    statTexts[i].text.text = $" : {characterAttribute.CalculateFinalValue()}";
                    break;
                }
            }
        }

        private void CanvasManager_ShowEquipItem()
        {

            deleteButton.SetActive(false);
            unEquipButton.SetActive(true);
            equipButton.SetActive(false);



        }

        private void CanvasManager_ShowInventoryItem()
        {

            deleteButton.SetActive(true);
            unEquipButton.SetActive(false);
            equipButton.SetActive(true);


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

        public void Unequip()
        {
            if (showedItem != null)
            {
                showedItem.Unequip();
                itemIcon.enabled = false;
                itemTier.enabled = false;
                itemName.enabled = false;

                deleteButton.SetActive(false);
                unEquipButton.SetActive(false);
                equipButton.SetActive(false);


            }
        }
        public void UseItem()
        {
            if (showedItem != null)
            {
                showedItem.Use();
                itemIcon.enabled = false;
                itemTier.enabled = false;
                itemName.enabled = false;

                deleteButton.SetActive(false);
                unEquipButton.SetActive(false);
                equipButton.SetActive(false);

            }
        }

        private void CanvasManager_ShowItem(Items.Item obj)
        {
            showedItem = obj;

            itemIcon.enabled = true;
            itemTier.enabled = true;
            itemName.enabled = true;


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
            CanvasManager.ShowInventoryItem -= CanvasManager_ShowInventoryItem;
            CanvasManager.ShowEquipItem -= CanvasManager_ShowEquipItem;

            PlayerStats.OnCharacterStatsInitialized.RemoveListener(HandleOnInitializeStats);
            PlayerStats.OnCharacterAttributeUpdated.RemoveListener(HandleOnCharacterAttributeUpdated);
        }

        private void UpdateText()
        {

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

[Serializable]
public class StatTexts
{
    public TextMeshProUGUI text;
    public StatType statType;
}