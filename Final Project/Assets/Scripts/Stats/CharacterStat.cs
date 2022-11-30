using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Stat
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Stats/CharacterStats")]
    [System.Serializable]
    public class CharacterStat : ScriptableObject
    {
        [Header("Base Stats")]
        [SerializeField] private List<CharacterAttribute> _characterAttribute;
        public List<CharacterAttribute> CharacterAttributes => _characterAttribute;

        [SerializeField] private int totalSkillPoints;
        [SerializeField] private int availableSkillPoints;

        public int AvailableSkillPoints => availableSkillPoints;

        public void IncreaseSkillPoints()
        {
            totalSkillPoints++;
            availableSkillPoints++;
        }

        public void DecreaseSkillPoints()
        {
            availableSkillPoints--;
        }

        public void AddModifier(AttributeModifier modifier)
        {
            CharacterAttribute modifiedAttribute = FindAttribute(modifier.TargetStat);

            if (modifiedAttribute != null)
            {
                modifiedAttribute.AddModifier(modifier);
            }
        }

        public void RemoveModifier(AttributeModifier modifier)
        {
            CharacterAttribute modifiedAttribute = FindAttribute(modifier.TargetStat);

            if (modifiedAttribute != null)
            {
                modifiedAttribute.RemoveModifiers(modifier);
            }
        }

        public void IncreaseBaseValue(StatType statType, float amount)
        {
            CharacterAttribute attribute = FindAttribute(statType);
            if (attribute != null)
            {
                attribute.IncreaseBaseValue(amount);
            }
        }

        public float GetValue(StatType type)
        {
            return FindAttribute(type).CalculateFinalValue();
        }

        private CharacterAttribute FindAttribute(StatType statType)
        {
            for (int i = 0; i < _characterAttribute.Count; i++)
            {
                if (_characterAttribute[i].StatType == statType)
                {
                    return _characterAttribute[i];
                }
            }

            return null;
        }


    }
}
