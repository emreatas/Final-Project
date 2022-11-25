using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using Stat;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private CharacterStat playerStats;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private StatType movementStatType;
        [SerializeField] private float rotationSpeed;
        
        [SerializeField] private float lerpRotationDuration;

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
            playerStats = playerSettings.CharacterStat;
        }

        public void MovePlayer(Vector3 movementVector)
        {
            rb.MovePosition(
                rb.position + 
                playerStats.GetValue(movementStatType) * 
                Time.deltaTime * 
                movementVector 
            );
        }

        public void RotatePlayer(Vector3 movementVector)
        {
            Quaternion newRot = Quaternion.RotateTowards(
                rb.rotation, 
                Quaternion.LookRotation(movementVector,  transform.up), 
                rotationSpeed * Time.deltaTime);
            
            rb.MoveRotation(newRot);
        }

        public void LerpPlayerRotation(Vector3 skillDirection)
        {
            /*
            if (skillDirection != Vector3.zero)
            {
                Timing.RunCoroutine(_LerpRotation(skillDirection));
            }
            */
            
            rb.rotation = Quaternion.LookRotation(skillDirection, transform.up);
        }

        IEnumerator<float> _LerpRotation(Vector3 skillDirection)
        {
            float lerpedTime = 0;
            
            Quaternion startRot = rb.rotation;
            Quaternion targetRot = Quaternion.LookRotation(skillDirection);
            
            while (lerpRotationDuration > lerpedTime)
            {
                rb.rotation = Quaternion.Slerp(startRot, targetRot, lerpedTime/lerpRotationDuration);        
        
                lerpedTime += Time.deltaTime;
                    
                yield return Timing.WaitForOneFrame;
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