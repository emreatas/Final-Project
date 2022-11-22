using System.Collections;
using System.Collections.Generic;
using Fusion;
using MEC;
using UnityEngine;

namespace Player
{
    public class PlayerNetworkMovementController : NetworkBehaviour
    {
        //[SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerMovementSettings movementSettings;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float lerpRotationDuration;
  
        public override void FixedUpdateNetwork()
        {
            Vector2 movementVector = Vector2.zero;
            
            Debug.Log("Network Fixed Update");
            
            if (GetInput(out NetworkInputData inputData))
            {
                Debug.Log("On Get Input");
                movementVector = inputData.movementVector;
                
            }
            
            MovePlayer(movementVector);
        }
        
        public void MovePlayer(Vector2 movementVector)
        {
            Vector3 newVector = new Vector3(movementVector.x, 0, movementVector.y);
            Debug.Log("Moving Player " + movementVector);
            rb.MovePosition(
                rb.position + 
                movementSettings.MovementSpeed *
                Time.deltaTime*
                newVector 
            );
        }
        public void RotatePlayer(Vector3 movementVector)
        {
            Vector3 newVector = new Vector3(movementVector.x, 0, movementVector.y);
            
            Quaternion newRot = Quaternion.RotateTowards(
                rb.rotation, 
                Quaternion.LookRotation(newVector,  transform.up), 
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
