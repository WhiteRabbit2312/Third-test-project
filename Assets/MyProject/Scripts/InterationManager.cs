using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System.Linq;

public class InterationManager : NetworkBehaviour
{
    private BasicSpawner _playerSpawner;
    private List<PlayerRef> _playerRef = new List<PlayerRef>();

    public override void Spawned()
    {
        _playerSpawner = FindObjectOfType<BasicSpawner>();
        _playerRef = _playerSpawner.Players;
    }
    public void CreateObj(GameObject prefab)
    {
        Debug.Log("Spawn sphere");

        if (_playerRef.FirstOrDefault<PlayerRef>() == Runner.LocalPlayer)
            Runner.Spawn(prefab, new Vector3(1, 1, 1), Quaternion.identity);
    }
}
