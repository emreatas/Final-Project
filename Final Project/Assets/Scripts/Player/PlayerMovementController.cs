using System.Collections;
using System.Collections.Generic;
using MEC;
using Stat;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerMovementSettings movementSettings;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float lerpRotationDuration;
   
        public void MovePlayer(Vector3 movementVector)
        {
            rb.MovePosition(
                rb.position + 
                playerStats.GetValue(movementSettings.movementStatType) * 
                Time.deltaTime * 
                movementVector 
            );
        }

        public void RotatePlayer(Vector3 movementVector)
        {
            Quaternion newRot = Quaternion.RotateTowards(
                rb.rotation, 
                Quaternion.LookRotation(movementVector,  transform.up), 
                movementSettings.RotationSpeed * Time.deltaTime);
            
            rb.MoveRotation(newRot);
        }

        public void LerpPlayerRotation(Vector3 targetPos)
        {
            if (targetPos != Vector3.zero)
            {
                Timing.RunCoroutine(_LerpRotation(targetPos));
            }
        }

        IEnumerator<float> _LerpRotation(Vector3 targetPos)
        {
            float lerpedTime = 0;
            
            Quaternion startRot = rb.rotation;
            Quaternion targetRot = Quaternion.LookRotation(targetPos - rb.position);
            
            while (lerpRotationDuration > lerpedTime)
            {
                rb.rotation = Quaternion.Slerp(startRot, targetRot, lerpedTime/lerpRotationDuration);        
        
                lerpedTime += Time.deltaTime;
                    
                yield return Timing.WaitForOneFrame;
            }
        }
    }
}