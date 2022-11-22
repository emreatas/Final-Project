using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkRunnerSpawner : MonoBehaviour
{
    [SerializeField] private NetworkRunner networkRunnerPrefab;

    private NetworkRunner m_Runner;
    
    private void Start()
    {
        m_Runner = Instantiate(networkRunnerPrefab);
        
        StartGame(GameMode.AutoHostOrClient);
    }

    async void StartGame(GameMode gameMode)
    {
        m_Runner.ProvideInput = true;

        await m_Runner.StartGame(new StartGameArgs()
        {
            GameMode = gameMode,
            SessionName = "TestRoom",
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneManager = m_Runner.AddComponent<NetworkSceneManagerDefault>()
        });
    }
}
