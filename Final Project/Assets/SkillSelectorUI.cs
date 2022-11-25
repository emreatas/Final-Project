using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Stat;
using UnityEngine;

namespace Skills
{
    public class SkillSelectorUI : MonoBehaviour
    {
        [SerializeField] private SkillUI[] primarySkillUIArray;
        [SerializeField] private SkillUI[] secondarySkillUIArray;
        
        
        [SerializeField] private SkillSettingsContainer mageSkillContainer;
        [SerializeField] private SkillSettingsContainer warriorSkillContainer;
        [SerializeField] private SkillSettingsContainer archerSkillContainer;

        private void OnEnable()
        {
           AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }
        
        private void HandleOnCharacterInitialized(PlayerSettings playerSettings)
        {
            switch (playerSettings.characterType)
            {
                case CharacterTypes.Mage:
                    SetPrimarySkills(mageSkillContainer);
                    SetSecondarySkills(mageSkillContainer);
                    break;
                case CharacterTypes.Warrior:
                    SetPrimarySkills(warriorSkillContainer);
                    SetSecondarySkills(warriorSkillContainer);
                    break;
                case CharacterTypes.Archer:
                    SetPrimarySkills(archerSkillContainer);
                    SetSecondarySkills(archerSkillContainer);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetPrimarySkills(SkillSettingsContainer skillContaioner)
        {
            if (skillContaioner.Primary1 != null)
            {
                primarySkillUIArray[0].SkillSettings = skillContaioner.Primary1;
                primarySkillUIArray[0].SetSkillIcon(skillContaioner.Primary1.SkillIcon);
                primarySkillUIArray[0].gameObject.SetActive(true);
            }
            if (skillContaioner.Primary2 != null)
            {
                primarySkillUIArray[1].SkillSettings = skillContaioner.Primary2;
                primarySkillUIArray[1].SetSkillIcon(skillContaioner.Primary2.SkillIcon);
                primarySkillUIArray[1].gameObject.SetActive(true);
            }/*
            if (skillContaioner.Primary3 != null)
            {
                primarySkillUIArray[2].SkillSettings = skillContaioner.Primary3;
                primarySkillUIArray[2].SetSkillIcon(skillContaioner.Primary3.SkillIcon);
                primarySkillUIArray[2].gameObject.SetActive(true);
            }*/
        }
        
        private void SetSecondarySkills(SkillSettingsContainer skillContaioner)
        {
            if (skillContaioner.Secondary1 != null)
            {
                secondarySkillUIArray[0].SkillSettings = skillContaioner.Secondary1;
                secondarySkillUIArray[0].SetSkillIcon(skillContaioner.Secondary1.SkillIcon);
                secondarySkillUIArray[0].gameObject.SetActive(true);
            }
            if (skillContaioner.Secondary2 != null)
            {
                secondarySkillUIArray[1].SkillSettings = skillContaioner.Secondary2;
                secondarySkillUIArray[1].SetSkillIcon(skillContaioner.Secondary2.SkillIcon);
                secondarySkillUIArray[1].gameObject.SetActive(true);
            }
        }

        private void AddListeners()
        {
            PlayerClass.OnCharacterInitialized.AddListener(HandleOnCharacterInitialized);
        }
            
        private void RemoveListeners()
        {
            PlayerClass.OnCharacterInitialized.RemoveListener(HandleOnCharacterInitialized);
        }

    }
}

