using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using Player;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    [SerializeField] private PlayerInputSystem inputSystem;

    public PlayerInputSystem InputSystem => inputSystem;
    public static NetworkPlayer LocalPlayer { get; set; }

    public override void Spawned()
    {
        Debug.Log("Spawned");
        if (Object.HasInputAuthority)
        {
            LocalPlayer = this;
        }
    }


    public void PlayerLeft(PlayerRef player)
    {
        if (Object.HasInputAuthority)
        {
            Runner.Despawn(Object);
        }
    }
}

public struct NetworkMovementInputData : INetworkInput
{
    public Vector2 MovementInput;

    public NetworkBool MovementStarted;
    public NetworkBool MovementCanceled;

    public NetworkBool BasicAttackStarted;
    public NetworkBool BasicPerformedStarted;
    public NetworkBool BasicCanceledStarted;
}