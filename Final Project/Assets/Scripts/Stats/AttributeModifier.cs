using System;
using UnityEngine;

namespace Stat
{
    //[CreateAssetMenu(menuName = "ScriptableObjects/Stats/StatModifier")]
    [Serializable]
    public class AttributeModifier 
    {
        [SerializeField] private float m_BaseValue;
        [SerializeField] private AttributeType m_BaseAttributeType;
        [SerializeField] private StatType m_TargetStat;
        
        public float BaseValue
        {
            get => m_BaseValue;
            private set => m_BaseValue = value;
        }

        public AttributeType BaseAttributeType
        {
            get => m_BaseAttributeType;
            private set => m_BaseAttributeType = value;
        }

        public StatType TargetStat
        {
            get => m_TargetStat;
            private set => m_TargetStat = value;
        }

        public AttributeModifier(float baseValue, StatType targetStat, AttributeType attributeType = AttributeType.Additive)
        {
            BaseValue = baseValue;
            BaseAttributeType = attributeType;
            TargetStat = targetStat;
        }
    }
}