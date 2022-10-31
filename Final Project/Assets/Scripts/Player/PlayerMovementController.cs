using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private PlayerMovementSettings movementSettings;
        [SerializeField] private PlayerInputSystem inputSystem;
        [SerializeField] private CharacterController characterController;
        
        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void HandleOnMovePerformed(Vector3 movementVector)
        {
            characterController.Move(movementSettings.MovementSpeed * Time.deltaTime * movementVector );
        }

        private void AddListeners()
        {
            inputSystem.OnMovePerformed.AddListener(HandleOnMovePerformed);
        }

        private void RemoveListeners()
        {
            inputSystem.OnMovePerformed.RemoveListener(HandleOnMovePerformed);
        }
    }
}