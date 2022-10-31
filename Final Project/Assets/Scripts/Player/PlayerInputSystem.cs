using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Player
{
    public class PlayerInputSystem : MonoBehaviour
    {
        public GameEvent<Vector3>
            OnMoveStarted,
            OnMovePerformed, 
            OnMoveCanceled;

        public GameEvent OnBasicAttackStarted;

        public GameEvent<Vector3> 
            OnPrimarySkillStarted,
            OnPrimarySkillPerfomed,
            OnPrimarySkillCanceled;   
        
        public GameEvent<Vector3> 
            OnSecondarySkillStarted,
            OnSecondarySkillPerfomed,
            OnSecondarySkillCanceled;

        private bool m_IsMoving;
        private bool m_BasicAttack;
        private bool m_IsTouchingPrimarySkill, m_IsTouchingSecondarySkill;
        
        private Vector2 m_MovementVector;
        private Vector2 m_PrimarySkillVector, m_SecondarySkillVector;
        
        private void Update()
        {
            ProcessInputs();
        }
        
        private void ProcessInputs()
        {
            if (m_IsMoving)
            {
                Vector3 movementVector = new Vector3(m_MovementVector.x, 0, m_MovementVector.y);
                OnMovePerformed.Invoke(movementVector);
            }

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

            if (m_BasicAttack)
            {
                Debug.Log("Basic Attack Perform");
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            m_MovementVector = context.ReadValue<Vector2>();

            if (context.started)
            {
                Debug.Log("Movement Started");
                OnMoveStarted.Invoke(m_MovementVector);
                m_IsMoving = true;
            }
            else if (context.canceled)
            {
                Debug.Log("Movement Canceled");
                OnMoveCanceled.Invoke(m_MovementVector);
                m_IsMoving = false;
            }
        }
        
        public void OnBasicAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                m_BasicAttack = true;
                Debug.Log("Basic Attack Started");
                OnBasicAttackStarted.Invoke();
            }
            if (context.canceled)
            {
                m_BasicAttack = false;
                Debug.Log("Basic Attack Canceled");
                OnBasicAttackStarted.Invoke();
            }
        }
        
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
    }
}