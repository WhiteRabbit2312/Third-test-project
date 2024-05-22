using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Ammunition : NetworkBehaviour
{
    [SerializeField] private NetworkObject _ammunitionPlace;
    [SerializeField] private PlayerStats _playerStats;
    private XRGrabInteractable _grabInteractable;
    private int _fullAmmo = 70;
    private bool _grabAmmo;

    public override void Spawned()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
    }

    public override void FixedUpdateNetwork()
    {
        if (!_grabInteractable.isSelected)
        {
            if (_grabAmmo)
            {
                Debug.LogError("Set ammo");
                Debug.LogError("Ammo " + _playerStats.Ammo);
                _playerStats.Ammo = _fullAmmo;
                _grabAmmo = false;

            }

            transform.position = _ammunitionPlace.transform.position;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogError("Collision ");
        if(collision.gameObject.TryGetComponent(out Shooting shooting))
        {
            _grabAmmo = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Shooting shooting))
        {
            _grabAmmo = false;
        }
    }
}
