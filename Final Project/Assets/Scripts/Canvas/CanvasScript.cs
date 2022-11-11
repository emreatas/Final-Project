using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Stat;
using System;
using Player;
using Skills;
using UnityEngine.UI;
using Utils;

namespace CanvasNS
{
    public class CanvasScript : MonoBehaviour
    {
        public GameObject interactButton;
        public GameObject deleteButton;
        public GameObject equipButton;
        public GameObject unEquipButton;

        [Header("Item Stat Texts")]
        public List<TextMeshProUGUI> itemStatTexts;

        [Header("Inventory Stat Texts")]
        public List<StatTexts> statTexts;
        
        [Header("Stat Panel Texts")]
        public List<StatTexts> statPanelTexts;

        [Header("Stat Panel Texts")]
        public TextMeshProUGUI rightPanelTitle;
        public TextMeshProUGUI rightPanelInfo;

        [SerializeField] private GameObject interactItemPanel;


        [Header("Inventory Item Button")]
        public UnityEngine.UI.Image itemIcon;
        public UnityEngine.UI.Image itemTier;
        public TMPro.TextMeshProUGUI itemName;

        [Header("Player Skills")] 
        public Image basicSkill;
        public Image primarySkill;
        public Image secondarySkill;

        private Dictionary<PlayerSkillType, Image> m_SkillImages;

        private Items.Item showedItem;
        private AbstractSkill selectedSkill;

        public static GameEvent<StatType> OnCharacterAttributeIncreased;
        public static GameEvent<AbstractSkill> OnSkillChanged;
        
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

        private void Start()
        {
            m_SkillImages = new Dictionary<PlayerSkillType, Image>()
            {
                { PlayerSkillType.Basic ,basicSkill},
                { PlayerSkillType.Primary ,primarySkill},
                { PlayerSkillType.Secondary ,secondarySkill}
            };
        }

        private void HandleOnInitializeStats(CharacterStat characterStats)
        {
            UpdateInventoryStats(characterStats);
            UpdateStatTexts(characterStats);

        }
        
        private void UpdateInventoryStats(CharacterStat characterStats)
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
        
        private void UpdateStatTexts(CharacterStat characterStats)
        {
            for (int i = 0; i < characterStats.CharacterAttributes.Count; i++)
            {
                for (int j = 0; j < statPanelTexts.Count; j++)
                {
                    if (statPanelTexts[j].statType == characterStats.CharacterAttributes[i].StatType)
                    {
                        statPanelTexts[j].text.text = $"{characterStats.CharacterAttributes[i].CalculateFinalValue()}";
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

        public void IncreaseCharacterAttribute(StatType statType)
        {
            OnCharacterAttributeIncreased.Invoke(statType);
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
                
                ResetItemStatTexts();
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

                ResetItemStatTexts();
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

        public void SelectSkill()
        {
            if (selectedSkill != null)
            {
                OnSkillChanged.Invoke(selectedSkill);
                m_SkillImages[selectedSkill.skillType].sprite = selectedSkill.SkillIcon;
            }
        }
        
        public void UpdateStatText(StatType statType)
        {
            rightPanelTitle.text = statType.name;
            rightPanelInfo.text = statType.description;
        }
        
        public void UpdateSkillText(AbstractSkill skill)
        {
            selectedSkill = skill;
            rightPanelTitle.text = skill.SkillName;
            rightPanelInfo.text = skill.SkillDescription;
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
