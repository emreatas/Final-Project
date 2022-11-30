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

        public string GetText()
        {
            string attrTpye = "";
            float showtext = m_BaseValue;

            switch (m_BaseAttributeType)
            {
                case AttributeType.Additive:
                    attrTpye = "+";
                    break;
                case AttributeType.Percantage:
                    showtext *= 10;
                    attrTpye = "%";
                    break;
            }

            return $"{m_TargetStat.name} {attrTpye} {(int)showtext}";
        }

        public float BaseValue
        {
            get => m_BaseValue;
            set => m_BaseValue = value;
        }

        public AttributeType BaseAttributeType
        {
            get => m_BaseAttributeType;
            set => m_BaseAttributeType = value;
        }

        public StatType TargetStat
        {
            get => m_TargetStat;
            set => m_TargetStat = value;
        }

        public AttributeModifier(float baseValue, StatType targetStat, AttributeType attributeType = AttributeType.Additive)
        {
            BaseValue = baseValue;
            BaseAttributeType = attributeType;
            TargetStat = targetStat;
        }
    }
}