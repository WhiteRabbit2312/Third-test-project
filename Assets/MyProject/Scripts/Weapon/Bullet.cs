using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Bullet : NetworkBehaviour
{
    [SerializeField] private float _speed;
    public int Damage = 10;

    public override void FixedUpdateNetwork()
    {
        transform.Translate(Vector3.forward * _speed);
    }
}
