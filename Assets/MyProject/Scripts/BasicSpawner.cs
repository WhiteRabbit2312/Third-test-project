using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.SceneManagement;

public class BasicSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    private NetworkRunner _runner;
    //[Networked] public NetworkDictionary<PlayerRef, PlayerStats> PlayerDictionary => default;
    public Dictionary<PlayerRef, PlayerStats> PlayerDictionary = new Dictionary<PlayerRef, PlayerStats>();
    private KillCounter _killCounter;
    private float _spawnPointY = 0.55f;

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
        StartGame(GameMode.Shared);
    }

    public void PlayerJoined(PlayerRef player)
    {
        _killCounter = GameObject.FindObjectOfType<KillCounter>();
        _killCounter.KillDictionary.Set(player, 0);

        Debug.LogError("Player name " + player);

        foreach(var item in _killCounter.KillDictionary)
        {
            Debug.LogError("Player: " + item.Key);
        }

        if (player == Runner.LocalPlayer)
        {
            Runner.Spawn(PlayerPrefab, new Vector3(0, _spawnPointY, 0), Quaternion.identity, player);
        }
    }
}
