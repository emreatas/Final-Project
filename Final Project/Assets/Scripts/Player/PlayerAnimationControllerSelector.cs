using System;
using Stat;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationControllerSelector : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        
        [SerializeField] private RuntimeAnimatorController mageAnimController;
        [SerializeField] private RuntimeAnimatorController archerAnimController;
        [SerializeField] private RuntimeAnimatorController warriorAnimController;

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
            SelectCorrectAnimatonController(playerSettings);
        }

        private void SelectCorrectAnimatonController(PlayerSettings playerSettings)
        {
            switch (playerSettings.characterType)
            {
                case CharacterTypes.Mage:
                    playerAnimator.runtimeAnimatorController = mageAnimController;
                    break;
                case CharacterTypes.Warrior:
                    playerAnimator.runtimeAnimatorController = warriorAnimController;
                    break;
                case CharacterTypes.Archer:
                    playerAnimator.runtimeAnimatorController = archerAnimController;
                    break;
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