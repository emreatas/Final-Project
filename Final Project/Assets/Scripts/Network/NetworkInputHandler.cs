using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class NetworkInputHandler : MonoBehaviour
{
    
    
    
    private Vector2 movementVector;
    
    private void Update()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = Input.GetAxis("Vertical");
    }

    public NetworkInputData GetInputData()
    {
        NetworkInputData inputData = new NetworkInputData();

        inputData.movementVector = movementVector;
        
        return inputData;
    }
}

public struct NetworkInputData : INetworkInput
{
    public Vector2 movementVector;

    public NetworkBool movementCanceled;
}
