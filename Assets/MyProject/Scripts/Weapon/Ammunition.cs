using UnityEngine;
using Fusion;
using UnityEngine.XR.Interaction.Toolkit;

public class Ammunition : NetworkBehaviour
{
    [SerializeField] private NetworkObject _ammunitionPlace;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private NetworkObject _gun;
    [SerializeField] private NetworkObject _ammoBox;
    private XRGrabInteractable _grabInteractable;
    [SerializeField] private Shooting _shooting;
    private int _fullAmmo = 70;
    private bool _grabAmmo;
    private Quaternion _setRotation = new Quaternion(0f, 0f, 0f, 0f);
    private Vector3 _ammoScale = new Vector3(0.1f, 1, 0.1f);

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
                NetworkObject noAmmo = Runner.Spawn(_ammoBox, _gun.transform.position);
                noAmmo.gameObject.transform.SetParent(_gun.transform);
                noAmmo.transform.rotation = _setRotation;
                Rigidbody ammoRB = noAmmo.GetComponent<Rigidbody>();
                _shooting.Init(ammoRB);
                _grabAmmo = false;
            }


            transform.position = _ammunitionPlace.transform.position;
            transform.rotation = _setRotation;
            transform.localScale = _ammoScale;

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
