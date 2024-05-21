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
    private int _fullAmmo = 5;
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
                Runner.Despawn(Object);
                _grabAmmo = false;

            }

            else
            {
                transform.position = _ammunitionPlace.transform.position;
            }
           
        }

        
    }


    private void OnCollisionEnter(Collision other)
    {
        Debug.LogError("Collision ");
        if(other.gameObject.TryGetComponent(out Shooting shooting))
        {
            _grabAmmo = true;
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _grabAmmo = false;
    }
}
