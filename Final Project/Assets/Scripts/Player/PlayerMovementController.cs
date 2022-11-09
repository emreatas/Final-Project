using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private PlayerMovementSettings movementSettings;
        [SerializeField] private Rigidbody rb;
        
        public void MovePlayer(Vector3 movementVector)
        {
            rb.MovePosition(
                rb.position + 
                movementSettings.MovementSpeed * 
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
    }
}