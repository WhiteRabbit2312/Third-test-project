using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.SceneManagement;

public class BasicSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    private NetworkRunner _runner;
    public Dictionary<PlayerRef, PlayerStats> PlayerDictionary = new Dictionary<PlayerRef, PlayerStats>();
    private KillCounter _killCounter;
    private Vector3 _spawnPoint = new Vector3(0f, 0.55f, 0f);

    private void Awake()
    {
        GameObject objectToDestroy = GameObject.Find("");
    }

    public async void StartGame(GameMode mode)
    {
        if (_runner != null)
            return;


        _runner = gameObject.AddComponent<NetworkRunner>();

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

        if (player == Runner.LocalPlayer)
        {
            Runner.Spawn(PlayerPrefab, _spawnPoint, Quaternion.identity, player);
        }
    }
}
