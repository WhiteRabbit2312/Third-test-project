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
    private XRGrabInteractable _grabInteractable;
    [SerializeField] private Shooting _shooting;
    private int _fullAmmo = 40;
    private bool _grabAmmo;
    private Quaternion _setRotation = new Quaternion(0f, 0f, 0f, 0f);
    private NetworkObject _noAmmo;

    public override void Spawned()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _noAmmo = Runner.Spawn(_ammoBox, _ammoPlace.transform.position);
        _noAmmo.transform.rotation = _setRotation;
        _noAmmo.gameObject.transform.SetParent(_gun.transform);
        Rigidbody ammoRB1 = _noAmmo.GetComponent<Rigidbody>();
        _shooting.Init(ammoRB1);

    }

    public override void FixedUpdateNetwork()
    {
        if (!_grabInteractable.isSelected)
        {
            if (_grabAmmo)
            {
                Runner.Despawn(_noAmmo);
                _noAmmo = Runner.Spawn(_ammoBox, _ammoPlace.transform.position);
                _noAmmo.gameObject.transform.SetParent(_gun.transform);
                _noAmmo.transform.rotation = _setRotation;
                Rigidbody ammoRB = _noAmmo.GetComponent<Rigidbody>();
                _shooting.Init(ammoRB);
                _grabAmmo = false;
            }


            transform.position = _ammunitionPlace.transform.position;
            transform.rotation = _setRotation;
            //transform.localScale = _ammoScale;

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Shooting shooting))
        {
            Debug.Log("Is interacting");
            if (!_grabInteractable.isSelected)
            {
                Debug.LogError("Set ammo");
                Debug.LogError("Ammo " + _playerStats.Ammo);
                _playerStats.Ammo = _fullAmmo;
                _grabAmmo = true;
            }
        }
    }

}
