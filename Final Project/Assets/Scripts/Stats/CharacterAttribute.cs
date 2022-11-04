using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stat
{
    //[Serializable]
    [CreateAssetMenu(menuName = "ScriptableObjects/Stats/CharacterAttribute")]
    public class CharacterAttribute : ScriptableObject
    {
        [SerializeField] private StatType statType;
        [SerializeField] private float baseValue;
        [SerializeField] private float dependantValue;
        
        [SerializeField] private List<AttributeModifier> additiveAttributeModifiers = new List<AttributeModifier>();
        [SerializeField] private List<AttributeModifier> percentageAttributeModifiers = new List<AttributeModifier>();
        [SerializeField] private List<CharacterAttribute> dependantCharacterAttributes = new List<CharacterAttribute>();


        private float m_FinalValue;

        private bool m_FinalValueChanged;

        public StatType StatType => statType;

        public CharacterAttribute(StatType statType, float baseValue = 0)
        {
            this.baseValue = baseValue;
            this.statType = statType;
        }

        public void AddModifier(AttributeModifier modifier)
        {
            if (statType == modifier.TargetStat)
            {
                if (modifier.BaseAttributeType == AttributeType.Additive)
                {
                    additiveAttributeModifiers.Add(modifier);
                }
                else
                {
                    percentageAttributeModifiers.Add(modifier);
                }
                
                m_FinalValueChanged = true;
            }
        }

        public void RemoveModifiers(AttributeModifier modifier)
        {
            if (statType == modifier.TargetStat)
            {
                if (modifier.BaseAttributeType == AttributeType.Additive && additiveAttributeModifiers.Contains(modifier))
                {
                    additiveAttributeModifiers.Remove(modifier);
                }
                else if (modifier.BaseAttributeType == AttributeType.Percantage &&
                         percentageAttributeModifiers.Contains(modifier))
                {
                    percentageAttributeModifiers.Remove(modifier);
                }

                m_FinalValueChanged = true;
            }
        }

        private void ApplyAdditiveModifiers()
        {
            for (int i = 0; i < additiveAttributeModifiers.Count; i++)
            {
                m_FinalValue += additiveAttributeModifiers[i].BaseValue;
            }
        }

        private void ApplyPercentageModifiers()
        {
            for (int i = 0; i < percentageAttributeModifiers.Count; i++)
            {
                m_FinalValue *= (1 + percentageAttributeModifiers[i].BaseValue);
            }
        }
        
        private void ApplyDependantAttributes()
        {
            for (int i = 0; i < dependantCharacterAttributes.Count; i++)
            {
                m_FinalValue = dependantCharacterAttributes[i].CalculateFinalValue() /
                               dependantCharacterAttributes[i].dependantValue;
            }
        }

        public void AddDependantCharacterAttribute(CharacterAttribute characterAttribute)
        {
            dependantCharacterAttributes.Add(characterAttribute);
        }

        public void RemoveDependantCharacterAttribute(CharacterAttribute characterAttribute)
        {
            if (dependantCharacterAttributes.Contains(characterAttribute))
            {
                dependantCharacterAttributes.Remove(characterAttribute);
            }
        }
        
        public float CalculateFinalValue()
        {
            if (!m_FinalValueChanged)
            {
                m_FinalValue = baseValue;

                ApplyDependantAttributes();
                ApplyAdditiveModifiers();
                ApplyPercentageModifiers();

                m_FinalValueChanged = false;
            }

            return m_FinalValue;
        }
    }
}