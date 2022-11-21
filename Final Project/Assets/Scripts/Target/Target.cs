using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Target : MonoBehaviour, ITarget
{
    [SerializeField] private GameObject targetGO;
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
}
