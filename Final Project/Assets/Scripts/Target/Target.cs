using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Utils;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject targetGO;

    public GameEvent OnDestroyed;
    
    public Vector3 Position
    {
        get => transform.position;
    }
    
    public void EnableTargetIndicator()
    {
        targetGO.SetActive(true);
    }

    public void DisableTargetIndicator()
    {
        targetGO.SetActive(false);
    }

    public void Destroyed()
    {
        OnDestroyed.Invoke();
    }
}