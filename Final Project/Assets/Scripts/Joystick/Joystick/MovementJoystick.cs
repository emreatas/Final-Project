using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace JoystickManager
{
    public class MovementJoystick : AbstractJoystick
    {  
        [SerializeField] private RectTransform m_RectTransform;
    
        private Vector3 m_StartBackgroundPos;
      
        protected override void Start()
        {
            base.Start();
            m_StartBackgroundPos = backgroundRectTransform.anchoredPosition;

            backgroundRectTransform.pivot = new Vector2(0.5f, 0.5f);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException(nameof(eventData));

            backgroundRectTransform.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);

            ScreenPointToLocalPointInRectangle(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            backgroundRectTransform.anchoredPosition = m_StartBackgroundPos;
            base.OnPointerUp(eventData);
        }

        private Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
        {
            Vector2 localPoint = Vector2.zero;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(m_RectTransform, screenPosition, null, out localPoint))
            {
                Vector2 pivotOffset = m_RectTransform.pivot * m_RectTransform.sizeDelta;
                return localPoint - (backgroundRectTransform.anchorMax * m_RectTransform.sizeDelta) + pivotOffset;
            }
            return Vector2.zero;
        }
        
    }

}
