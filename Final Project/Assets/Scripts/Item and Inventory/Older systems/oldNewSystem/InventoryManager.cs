using System.Collections;
using System.Collections.Generic;
using PInventory;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        [Header("----------Panels----------")]
        [SerializeField] Inventory inventory;
        [SerializeField] EquipmentPanel equipmentPanel;

        [Header("----------Showed Item----------")]

        [SerializeField] TextMeshProUGUI itemName;
        [SerializeField] Image itemIcon;
        [SerializeField] Image itemTier;
        [SerializeField] List<TextMeshProUGUI> itemStatTexts;
        Item showedItem;

        [Header("----------Buttons----------")]
        [SerializeField] GameObject equipButton;
        [SerializeField] GameObject unEquipButton;
        [SerializeField] GameObject deleteButton;



        private void Awake()
        {
            inventory.OnItemRightClickedEvet += ShowItem;
            equipmentPanel.OnItemRightClickedEvet += ShowItem;
        }

        private void EquipFromInventory(Item item)
        {
            if (item is EquippableItem)
            {
                Equip((EquippableItem)item);
            }

        }
        private void UnequipFromEquipPanel(Item item)
        {
            if (item is EquippableItem)
            {
                Unequip((EquippableItem)item);
            }
        }

        private void ShowItem(Item obj)
        {
            Debug.Log(obj);
            if (obj != null)
            {
                showedItem = obj;

                itemIcon.enabled = true;
                itemTier.enabled = true;
                itemName.enabled = true;


                itemName.text = obj.ItemName;
                itemIcon.sprite = obj.Icon;
                itemTier.sprite = obj.TierImage;
                itemTier.color = obj.GetTierColor();

                for (int i = 0; i < itemStatTexts.Count; i++)
                {
                    itemStatTexts[i].enabled = false;
                }

                for (int i = 0; i < obj.stats.Count; i++)
                {
                    if (i < itemStatTexts.Count)
                    {
                        itemStatTexts[i].enabled = true;
                        itemStatTexts[i].text = obj.stats[i].GetText();
                    }
                }
            }
            else
            {
                itemIcon.enabled = false;
                itemTier.enabled = false;
                itemName.enabled = false;

                deleteButton.SetActive(false);
                equipButton.SetActive(false);
                unEquipButton.SetActive(false);
                ResetItemStatTexts();

            }
        }


        public void ShowInventoryItem()
        {

            deleteButton.SetActive(true);
            unEquipButton.SetActive(false);
            equipButton.SetActive(true);
        }

        public void ShowEquipedItem()
        {
            deleteButton.SetActive(false);
            unEquipButton.SetActive(true);
            equipButton.SetActive(false);
        }
        public void DeleteItem()
        {
            if (showedItem != null)
            {
                inventory.RemoveItem(showedItem);
                itemIcon.enabled = false;
                itemTier.enabled = false;
                itemName.enabled = false;
                deleteButton.SetActive(false);
                equipButton.SetActive(false);

                ResetItemStatTexts();
            }
        }

        public void Unequip()
        {
            if (showedItem != null)
            {


                itemIcon.enabled = false;
                itemTier.enabled = false;
                itemName.enabled = false;

                deleteButton.SetActive(false);
                unEquipButton.SetActive(false);
                equipButton.SetActive(false);

                UnequipFromEquipPanel(showedItem);
                ResetItemStatTexts();
            }
        }
        public void EquipItem()
        {
            if (showedItem != null)
            {
                itemIcon.enabled = false;
                itemTier.enabled = false;
                itemName.enabled = false;

                deleteButton.SetActive(false);
                unEquipButton.SetActive(false);
                equipButton.SetActive(false);

                EquipFromInventory(showedItem);
                ResetItemStatTexts();
            }
        }

        private void ResetItemStatTexts()
        {
            for (int i = 0; i < itemStatTexts.Count; i++)
            {
                itemStatTexts[i].text = "";
            }
        }
        public void Equip(EquippableItem item)
        {
            if (inventory.RemoveItem(item))
            {
                EquippableItem previousItem;
                if (equipmentPanel.AddItem(item, out previousItem))
                {
                    if (previousItem != null)
                    {
                        inventory.AddItem(previousItem);
                    }
                }
                else
                {
                    inventory.AddItem(item);
                }
            }
        }

        public void Unequip(EquippableItem item)
        {
            if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
            {
                inventory.AddItem(item);
            }
        }
    }
}