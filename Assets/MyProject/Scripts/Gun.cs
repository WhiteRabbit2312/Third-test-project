using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Gun : NetworkBehaviour
{
    private Transform _playerToFollow;

    public override void Spawned()
    {
        _playerToFollow = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    public override void FixedUpdateNetwork()
    {

        Follow();
    }

    private void Follow()
    {
        transform.position = _playerToFollow.position;
    }
}
