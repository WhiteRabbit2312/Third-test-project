using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    [SerializeField] private NetworkObject _gun;

    public override void Spawned()
    {
        Runner.Spawn(_gun);
    }

    public override void FixedUpdateNetwork()
    {
        Movement();
    }

    public void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward);
        }
    }
}
