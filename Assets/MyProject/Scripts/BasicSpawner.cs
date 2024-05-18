using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.SceneManagement;
using Fusion.Sockets;
using System;

public class BasicSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    private NetworkRunner _runner;
    public List<PlayerRef> Players = new List<PlayerRef>();

    public async void StartGame(GameMode mode)
    {
        if (_runner != null)
            return;

        _runner = GetComponent<NetworkRunner>();
        var scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex);
        var sceneInfo = new NetworkSceneInfo();
        if (scene.IsValid)
        {
            sceneInfo.AddSceneRef(scene, LoadSceneMode.Additive);
        }

        await _runner.StartGame(new StartGameArgs()
        {
            GameMode = mode,
            SessionName = "TestRoom",
            Scene = SceneRef.FromIndex(1),
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
        });
    }

    public void ConnectButton()
    {
        Debug.Log("Connected");
        StartGame(GameMode.Shared);
    }

    public void PlayerJoined(PlayerRef player)
    {
        
        if (player == Runner.LocalPlayer)
        {
            Runner.Spawn(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity, player);
            Players.Add(player);

        }
    }
}
