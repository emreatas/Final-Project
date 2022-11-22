using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Player
{
    public class PlayerInputSystem : MonoBehaviour
    {
        private bool m_IsMoving;
        private bool m_BasicAttack;
        private bool m_IsTouchingPrimarySkill, m_IsTouchingSecondarySkill;

        private bool m_MoveStarted, m_MoveCanceled;
        
        private bool m_BasicAttackStarted, m_BasicAttackPerfomed, m_BasicAttackCanceled;
/*
        private Vector2 m_PrimarySkillDirection;
        private bool m_PrimaryAttackStarted, m_PrimaryAttackCanceled;
        
        private Vector2 m_SecondarySkillDirection;
        private bool m_SecondaryAttackStarted, m_SecondaryAttackCanceled;
        */
        private Vector2 m_MovementVector;
        private Vector2 m_PrimarySkillVector, m_SecondarySkillVector;
        
        public NetworkMovementInputData GetPlayerInput()
        {
            NetworkMovementInputData movementInputData = new NetworkMovementInputData();

            movementInputData.MovementInput = m_MovementVector;
            
            movementInputData.MovementStarted = m_MoveStarted;
            m_MoveStarted = false;

            movementInputData.MovementCanceled = m_MoveCanceled;
            m_MoveCanceled = false;

            movementInputData.BasicAttackStarted = m_BasicAttackStarted;
            m_BasicAttackStarted = false;

            movementInputData.BasicPerformedStarted = m_BasicAttackPerfomed;
            m_BasicAttackPerfomed = false;

            movementInputData.BasicCanceledStarted = m_BasicAttackCanceled;
            m_BasicAttackCanceled = false;
            
            return movementInputData;
        }

        
        private void Update()
        {
            ProcessInputs();
        }

        private void FixedUpdate()
        {
            ProcessPhyisicInputs();
        }
        
        private void ProcessPhyisicInputs()
        {
            if (m_IsMoving)
            {
                Vector3 movementVector = new Vector3(m_MovementVector.x, 0, m_MovementVector.y);
            }
        }

        private void ProcessInputs()
        {/*
            if (m_IsTouchingPrimarySkill)
            {
                Vector3 vector = new Vector3(m_PrimarySkillVector.x, 0, m_PrimarySkillVector.y);
                OnPrimarySkillPerfomed.Invoke(vector);
            }
            if (m_IsTouchingSecondarySkill)
            {
                Vector3 vector = new Vector3(m_SecondarySkillVector.x, 0, m_SecondarySkillVector.y);
                OnSecondarySkillPerfomed.Invoke(vector);
            }
*/
            if (m_BasicAttack)
            {
                Debug.Log("Baisıypom abe");
                m_BasicAttackPerfomed = true;
            }
        }
        

        public void OnMove(InputAction.CallbackContext context)
        {
            m_MovementVector = context.ReadValue<Vector2>();

            if (context.started)
            {
                m_MoveStarted = true;
                m_IsMoving = true;
            }
            else if (context.canceled)
            {
                m_MoveCanceled = true;
                m_IsMoving = false;
            }
        }
        
        public void OnBasicAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                m_BasicAttackStarted = true;
                m_BasicAttack = true;
            }
            if (context.canceled)
            {
                m_BasicAttackCanceled = true;
                m_BasicAttack = false;
            }
        }
        /*
        public void OnPrimarySkill(InputAction.CallbackContext context)
        {
            m_PrimarySkillVector = context.ReadValue<Vector2>();
            
            if (context.started)
            {
                
                m_IsTouchingPrimarySkill = true;
                OnPrimarySkillStarted.Invoke(m_PrimarySkillVector);
            }
            else if (context.canceled)
            {
                m_IsTouchingPrimarySkill = false;
                OnPrimarySkillCanceled.Invoke(m_PrimarySkillVector);
            }
        }
        
        public void OnSecondarySkill(InputAction.CallbackContext context)
        {
            m_SecondarySkillVector = context.ReadValue<Vector2>();
            
            if (context.started)
            {
                m_IsTouchingSecondarySkill = true;
                OnSecondarySkillStarted.Invoke(m_SecondarySkillVector);
            }
            else if (context.canceled)
            {
                m_IsTouchingSecondarySkill = false;
                OnSecondarySkillCanceled.Invoke(m_SecondarySkillVector);
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnInteractStarted.Invoke();
            }
        }
        */
    }
}