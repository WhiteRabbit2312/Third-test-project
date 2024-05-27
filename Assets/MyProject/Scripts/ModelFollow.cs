using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ModelFollow : NetworkBehaviour
{
    [SerializeField] private NetworkObject[] _objectsToFollow;
    private float _speed = 5f;

    public override void FixedUpdateNetwork()
    {
        foreach (var item in _objectsToFollow)
        {
            Vector3 direction = item.transform.position - transform.position;
            direction.Normalize();

            item.transform.position += direction * _speed * Time.deltaTime;
        }
    }
}
