using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.Serialization;

namespace JoystickManager
{
    public abstract class AbstractJoystick : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] protected RectTransform handleRectTransform;
        [SerializeField] protected RectTransform backgroundRectTransform;
        
        [FormerlySerializedAs("movementRange")]
        [SerializeField] private float m_MovementRange = 50;
        
        [InputControl(layout = "Vector2")]
        [SerializeField] private string m_ControlPath;
        
        [SerializeField] private float m_threshold =.2f;
        
        private Vector3 m_StartHandlePos;
        private Vector2 m_PointerDownPos;
        
        protected override string controlPathInternal
        {
            get => m_ControlPath;
            set => m_ControlPath = value;
        }
        public float movementRange
        {
            get => m_MovementRange;
            set => m_MovementRange = value;
        }
        
        protected virtual void Start()
        {
            m_StartHandlePos = handleRectTransform.anchoredPosition;
        }
        
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException(nameof(eventData));

            m_PointerDownPos = ScreenPointToLocalPointInRectangle(eventData);
        
            SendValueToControl(new Vector2(0.1f,0.1f));
        }  
        
        public virtual void OnDrag(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException(nameof(eventData));

            Vector2 position = ScreenPointToLocalPointInRectangle(eventData);

            Vector2 newPos = FindHandlePosition(position);
            
            if (IsBelowThreshold(newPos))
            {
                return;
            }
        
            SendValueToControl(newPos);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            handleRectTransform.anchoredPosition = m_StartHandlePos;
            SendValueToControl(Vector2.zero);
        }

        protected Vector2 ScreenPointToLocalPointInRectangle(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                backgroundRectTransform, 
                eventData.position, eventData.pressEventCamera, 
                out Vector2 pressPosition
            );
            
            return pressPosition;
        }

        private Vector2 FindHandlePosition(Vector2 currentPos)
        {
            var delta = currentPos - m_PointerDownPos;

            delta = Vector2.ClampMagnitude(delta, movementRange);
            
            handleRectTransform.anchoredPosition = m_StartHandlePos + (Vector3)delta;

            var newPos = new Vector2(delta.x / movementRange, delta.y / movementRange);
            return newPos;
        }

        private bool IsBelowThreshold(Vector2 position)
        {
            return Vector2.Distance(position, Vector2.zero) < m_threshold;
        }
    }

}
