using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooting : NetworkBehaviour
{
    [SerializeField] private NetworkObject _bullet;
    [SerializeField] private NetworkObject _spawnBulletPos;
    [SerializeField] private NetworkObject _gunPlace;
    private XRGrabInteractable _grabInteractable;

    public override void Spawned()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
    }

    public override void FixedUpdateNetwork()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootInput();
        }

        if (!_grabInteractable.isSelected)
        {
            transform.position = _gunPlace.transform.position;
        }
    }


    public void ShootInput()
    {
        
        if (_grabInteractable.isSelected)
        {
            Debug.LogError("Shoot");
            Runner.Spawn(_bullet, _spawnBulletPos.transform.position, Quaternion.identity);
        }
    }
}
