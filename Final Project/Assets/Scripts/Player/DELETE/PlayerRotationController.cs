using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerRotationController : MonoBehaviour
    {
        [SerializeField] private PlayerInputSystem inputSystem;
        [SerializeField] private PlayerRotationSettings rotationSettings;

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
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, 
                Quaternion.LookRotation(movementVector, transform.up), 
                rotationSettings.RotationSpeed * Time.deltaTime);
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