using System;
using System.Collections;
using System.Collections.Generic;
using PInventory;
using Player;
using TMPro;
using UnityEngine;
using Utils;

namespace Stat
{
    public class StatUI : MonoBehaviour
    {
        [SerializeField] private StatSlot[] statSlots;
        [SerializeField] private TextMeshProUGUI skillPointsText;

        public static GameEvent<StatType> OnStatIncreased;

        private int m_SkillPoints = 0;

        private void Start()
        {

            AddListeners();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void HandleOnCharacterStatsInitialized(CharacterStat characterStats)
        {
            for (int i = 0; i < statSlots.Length; i++)
            {
                statSlots[i].SetStatText(characterStats.GetValue(statSlots[i].StatType).ToString());
            }

            m_SkillPoints = characterStats.AvailableSkillPoints;
            skillPointsText.text = m_SkillPoints.ToString();
        }
        private void HandleOnSkillPointsUpdated(int availabSkillPoints)
        {
            m_SkillPoints = availabSkillPoints;
            skillPointsText.text = m_SkillPoints.ToString();
        }

        public void _AddStat(StatType statType)
        {
            Debug.Log("Try Add Stat");
            if (m_SkillPoints > 0)
            {
                Debug.Log("Stat added succesfully");
                OnStatIncreased.Invoke(statType);
            }
        }

        private void AddListeners()
        {
            PlayerStats.OnCharacterStatsInitialized.AddListener(HandleOnCharacterStatsInitialized);
            PlayerStats.OnSkillPointsUpdated.AddListener(HandleOnSkillPointsUpdated);
        }

        private void RemoveListeners()
        {
            PlayerStats.OnCharacterStatsInitialized.RemoveListener(HandleOnCharacterStatsInitialized);
            PlayerStats.OnSkillPointsUpdated.RemoveListener(HandleOnSkillPointsUpdated);
        }
    }

}

