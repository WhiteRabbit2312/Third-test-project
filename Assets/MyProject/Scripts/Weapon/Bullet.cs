using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Bullet : NetworkBehaviour
{
    [SerializeField] private float _speed;
    public override void FixedUpdateNetwork()
    {
        transform.Translate(Vector3.forward * _speed);
    }
}
