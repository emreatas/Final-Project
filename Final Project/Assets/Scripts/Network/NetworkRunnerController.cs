using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using Player;
using UnityEngine;

public class NetworkRunnerController : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField] private NetworkPlayer playerPrefab;

    private Dictionary<PlayerRef, GameObject> m_SpawnedPlayers = new Dictionary<PlayerRef, GameObject>();

    private PlayerInputSystem m_PlayerInputSystem;
    
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("On Player Spawned");

        if (runner.IsServer)
        {
            Vector3 spawnPosition = Vector3.zero;
            NetworkPlayer networkPlayerObject = runner.Spawn(playerPrefab, spawnPosition, Quaternion.identity, player);
            //networkPlayerObject.OnPlayerSpawned();
            m_SpawnedPlayers.Add(player,networkPlayerObject.gameObject);
        }
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("On Player Left");
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        Debug.Log("On Input");
        if (m_PlayerInputSystem == null && NetworkPlayer.LocalPlayer != null && NetworkPlayer.LocalPlayer.InputSystem != null)
        {
            m_PlayerInputSystem = NetworkPlayer.LocalPlayer.InputSystem;
        }

        if (m_PlayerInputSystem != null)
        {
            Debug.Log("Send Input");
            input.Set(m_PlayerInputSystem.GetPlayerInput());
        }
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        Debug.Log("On Input Missing");
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log("On Shutdown");
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("On Connected To Server");
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        Debug.Log("On Disconnected To Server");
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        Debug.Log("On Connect Request");
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        Debug.Log("On Connect Failed");
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        Debug.Log("On User Simulation Message");
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        Debug.Log("On Session List Updated");
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        Debug.Log("On Custom Authentication Response");
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        Debug.Log("On Host Migration");
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        Debug.Log("On Reliable Data Received");
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        Debug.Log("On Scene Load Done");
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        Debug.Log("On Scene Load Start");
    }
}
