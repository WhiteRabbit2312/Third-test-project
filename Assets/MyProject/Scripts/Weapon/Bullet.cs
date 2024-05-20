using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Bullet : NetworkBehaviour
{
    [SerializeField] private float _speed;
    private int _damage = 10;

    public override void FixedUpdateNetwork()
    {
        transform.Translate(Vector3.forward * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerStats playerStats))
        {
            playerStats.HP -= _damage;

            if (playerStats.HP <= 0)
            {
                KillDatabase.Instance.DetectKill(Object.InputAuthority);
            }
        }
    }
}
