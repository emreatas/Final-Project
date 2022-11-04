using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stat
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Stats/CharacterStats")]
    public class CharacterStat : ScriptableObject
    {
        [Header("Base Stats")] [SerializeField]
        private List<CharacterAttribute> _characterAttribute;
        
        
        public void AddModifier(AttributeModifier modifier)
        {
            CharacterAttribute modifiedAttribute = FindAttribute(modifier);

            if (modifiedAttribute != null)
            {
                modifiedAttribute.AddModifier(modifier);
            }
        }

        public void RemoveModifier(AttributeModifier modifier)
        {
            CharacterAttribute modifiedAttribute = FindAttribute(modifier);

            if (modifiedAttribute != null)
            {
                modifiedAttribute.RemoveModifiers(modifier);
            }
        }

        private CharacterAttribute FindAttribute(AttributeModifier modifier)
        {
            for (int i = 0; i < _characterAttribute.Count; i++)
            {
                if (_characterAttribute[i].StatType == modifier.TargetStat)
                {
                    return _characterAttribute[i];
                }
            }

            return null;
        }
    }
}
