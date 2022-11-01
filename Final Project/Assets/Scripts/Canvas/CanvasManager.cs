using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanvasManager : MonoBehaviour
{

    public static CanvasManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static event Action<bool> InteractableStart;

    public void OnInteractableStart(bool interact)
    {

        if (InteractableStart != null)
        {
            InteractableStart(interact);
        }
    }

}
