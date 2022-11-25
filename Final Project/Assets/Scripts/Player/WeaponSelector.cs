using System;
using Stat;
using UnityEngine;

namespace Player
{
    public class WeaponSelector : MonoBehaviour
    {
        [SerializeField] private GameObject mageWeapon;
        [SerializeField] private GameObject archerWeapon;
        [SerializeField] private GameObject warriorWeapon;
        
        [SerializeField] private Weapon[] weaponsParent;


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
            EnableSelectedCharacterWeapon(playerSettings);
        }

        public Transform GetActiveWeaponTransform()
        {
            for (int i = 0; i < weaponsParent.Length; i++)
            {
                if (weaponsParent[i].gameObject.activeSelf)
                {
                    return weaponsParent[i].GetWeaponSkillTransform();
                }
            }

            return null;
        }

        private void EnableSelectedCharacterWeapon(PlayerSettings playerSettings)
        {
            switch (playerSettings.characterType)
            {
                case CharacterTypes.Mage:
                    mageWeapon.SetActive(true);
                    break;
                case CharacterTypes.Warrior:
                    warriorWeapon.SetActive(true);
                    break;
                case CharacterTypes.Archer:
                    archerWeapon.SetActive(true);
                    break;
            }
        }

        private void AddListeners()
        {
            PlayerClass.OnCharacterInitialized.AddListener(HandleOnCharacterInitialized);
        }

        private void RemoveListeners()
        {
            PlayerClass.OnCharacterInitialized.AddListener(HandleOnCharacterInitialized);
        }
    }
}