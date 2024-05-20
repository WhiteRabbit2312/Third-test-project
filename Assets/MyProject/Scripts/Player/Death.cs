using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Death : NetworkBehaviour
{
    private PlayerStats _playerStats;
    private Vector3 _spawnPoint = new Vector3(0, 0.55f, 0);

    public override void Spawned()
    {
        _playerStats = GetComponent<PlayerStats>();
    }

    public override void FixedUpdateNetwork()
    {
        if(_playerStats.HP <= 0)
        {
            ReturnToSpawnPoint();
        }
    }

    private void ReturnToSpawnPoint()
    {
        transform.position = _spawnPoint;
    }
}
