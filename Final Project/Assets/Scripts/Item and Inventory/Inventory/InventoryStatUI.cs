using System;
using Player;
using Stat;
using UnityEngine;

namespace PInventory
{
    public class InventoryStatUI : MonoBehaviour
    {
        [SerializeField] private StatSlot[] statSlots;

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
        }
        
        private void AddListeners()
        {
            PlayerStats.OnCharacterStatsInitialized.AddListener(HandleOnCharacterStatsInitialized);
        }

        private void RemoveListeners()
        {
            PlayerStats.OnCharacterStatsInitialized.RemoveListener(HandleOnCharacterStatsInitialized);
        }
    }
}
