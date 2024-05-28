using UnityEngine;
using Fusion;
using UnityEngine.XR.Interaction.Toolkit;

public class Ammunition : NetworkBehaviour
{
    [SerializeField] private NetworkObject _ammunitionPlace;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private NetworkObject _gun;
    [SerializeField] private NetworkObject _ammoBox;
    [SerializeField] private NetworkObject _ammoPlace;
    [SerializeField] private Shooting _shooting;
    
    private Quaternion _setRotation = new Quaternion(0f, 0f, 0f, 0f);

    private NetworkObject _noAmmo;
    private XRGrabInteractable _grabInteractable;

    private int _fullAmmo = 40;
    private bool _grabAmmo;

    public override void Spawned()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        SetAmmoToGun();
    }

    public override void FixedUpdateNetwork()
    {
        if (!_grabInteractable.isSelected)
        {
            if (_grabAmmo)
            {
                Runner.Despawn(_noAmmo);
                SetAmmoToGun();
                _grabAmmo = false;
            }

            transform.position = _ammunitionPlace.transform.position;
            transform.rotation = _setRotation;
        }
    }

    private void SetAmmoToGun()
    {
        _noAmmo = Runner.Spawn(_ammoBox, _ammoPlace.transform.position);
        _noAmmo.gameObject.transform.SetParent(_gun.transform);
        _noAmmo.transform.rotation = _setRotation;
        Rigidbody ammoRB = _noAmmo.GetComponent<Rigidbody>();
        _shooting.Init(ammoRB);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Shooting shooting))
        {
            if (!_grabInteractable.isSelected)
            {
                _playerStats.Ammo = _fullAmmo;
                _grabAmmo = true;
            }
        }
    }

}
