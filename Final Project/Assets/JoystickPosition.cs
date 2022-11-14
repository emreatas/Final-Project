using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;

public class JoystickPosition : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private OnScreenStick joystickTransform;
    [SerializeField] private Transform stickParent;
    
    private Vector3 joystickStartPos;
    
    private void Start()
    {
        //joystickStartPos = joystickTransform.anchoredPosition;
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("pointer clicked");
        
        joystickTransform.OnPointerDown(eventData);
        stickParent.position = eventData.position;
    }
}
