using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Player
{
    public class PlayerInputSystem : MonoBehaviour
    {
        public GameEvent<Vector3> OnMovePerformed;

        public GameEvent OnBasicAttackStarted;

        public GameEvent 
            OnPrimarySkillStarted,
            OnSecondarySkillStarted;
        
        private bool m_IsMoving;
        private Vector2 m_MovementVector;
        
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
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            m_MovementVector = context.ReadValue<Vector2>();

            if (context.started)
            {
                Debug.Log("Movement Started");
                m_IsMoving = true;
            }
            else if (context.canceled)
            {
                Debug.Log("Movement Canceled");
                m_IsMoving = false;
            }
        }
        
        public void OnBasicAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Debug.Log("Basic Attack Started");
                OnBasicAttackStarted.Invoke();
            }
        }
        
        public void OnPrimarySkill(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Debug.Log("Primary Skill Started");
                OnPrimarySkillStarted.Invoke();
            }
        }
        
        public void OnSecondarySkill(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Debug.Log("Secondary Skill Started");
                OnSecondarySkillStarted.Invoke();
            }
        }
    }
}