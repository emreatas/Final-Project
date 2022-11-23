using Stat;
using TMPro;
using UnityEngine;

namespace PInventory
{
    public class InventoryStatSlot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI statText;
        [SerializeField] private StatType statType;

        public StatType StatType => statType;
        
        public void SetStatText(string text)
        {
            statText.text = text;
        }
    }
}