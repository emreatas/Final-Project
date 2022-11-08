using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stat
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Stats/CharacterAttribute")]
    public class CharacterAttribute : ScriptableObject
    {
        [SerializeField] private StatType statType;
        [SerializeField] private float baseValue;
        
        [SerializeField] private List<AttributeModifier> additiveAttributeModifiers = new List<AttributeModifier>();
        [SerializeField] private List<AttributeModifier> percentageAttributeModifiers = new List<AttributeModifier>();
        [SerializeField] private List<DependantAttribute> dependantCharacterAttributes = new List<DependantAttribute>();

        private float m_FinalValue;

        private bool m_FinalValueChanged;

        public bool FinalValueChanged => m_FinalValueChanged;
        public StatType StatType => statType;

        public CharacterAttribute(StatType statType, float baseValue = 0)
        {
            this.baseValue = baseValue;
            this.statType = statType;
        }

        private void OnValidate()
        {
            m_FinalValueChanged = true;
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
              
                m_FinalValue += dependantCharacterAttributes[i].characterAttribute.CalculateFinalValue() *
                                dependantCharacterAttributes[i].multiplier;
            }
        }

        public void AddDependantCharacterAttribute(DependantAttribute characterAttribute)
        {
            dependantCharacterAttributes.Add(characterAttribute);

            m_FinalValueChanged = true;
        }

        public void RemoveDependantCharacterAttribute(DependantAttribute characterAttribute)
        {
            if (dependantCharacterAttributes.Contains(characterAttribute))
            {
                dependantCharacterAttributes.Remove(characterAttribute);
                
                m_FinalValueChanged = true;
            }
        }
        
        public float CalculateFinalValue()
        {
            CheckDependantAttrValueChanged();
            
            if (m_FinalValueChanged)
            {
                m_FinalValue = baseValue;

                ApplyDependantAttributes();
                ApplyAdditiveModifiers();
                ApplyPercentageModifiers();

                m_FinalValueChanged = false;
            }

            return m_FinalValue;
        }

        private void CheckDependantAttrValueChanged()
        {
            for (int i = 0; i < dependantCharacterAttributes.Count; i++)
            {
                if (dependantCharacterAttributes[i].characterAttribute.FinalValueChanged)
                {
                    m_FinalValueChanged = true;
                }
            }
        }
    }
}