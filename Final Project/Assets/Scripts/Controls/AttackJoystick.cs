using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.Serialization;

public class AttackJoystick : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [FormerlySerializedAs("movementRange")]
    [SerializeField]
    private float m_MovementRange = 50;

    [InputControl(layout = "Vector2")]
    [SerializeField]
    private string m_ControlPath;

    private Vector3 m_StartPos;
    private Vector2 m_PointerDownPos;

    private float m_threshold =.2f;

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

    private RectTransform m_ParentRectTransform;
    
    private void Start()
    {
        m_StartPos = ((RectTransform)transform).anchoredPosition;
        m_ParentRectTransform = transform.parent.GetComponentInParent<RectTransform>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            m_ParentRectTransform, 
            eventData.position, eventData.pressEventCamera, 
            out m_PointerDownPos
            );
        
        SendValueToControl(Vector2.one);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            m_ParentRectTransform, 
            eventData.position, eventData.pressEventCamera, 
            out var position
            );
        
        var delta = position - m_PointerDownPos;

        delta = Vector2.ClampMagnitude(delta, movementRange);
        ((RectTransform)transform).anchoredPosition = m_StartPos + (Vector3)delta;

        var newPos = new Vector2(delta.x / movementRange, delta.y / movementRange);
        
        if (Vector2.Distance(newPos, Vector2.zero) < m_threshold )
        {
            return;
        }
        
        SendValueToControl(newPos);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ((RectTransform)transform).anchoredPosition = m_StartPos;
        SendValueToControl(Vector2.zero);
        
    }
}
