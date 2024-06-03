using UnityEngine;
using Fusion;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooting : NetworkBehaviour
{
    [SerializeField] private InputActionReference _actionReferenceShootingLeft;
    [SerializeField] private InputActionReference _actionReferenceShootingLeftRight;
    [SerializeField] private InputActionReference _actionRemoveAmmoLeft;
    [SerializeField] private InputActionReference _actionRemoveAmmoRight;
    [SerializeField] private InputActionReference _actionRGrabLeft;
    [SerializeField] private InputActionReference _actionRGrabRight;

    [Space]
    [SerializeField] private InputActionReference _testShootLeft;
    [SerializeField] private InputActionReference _testShootRight;
    [SerializeField] private InputActionReference _testGrabLeft;
    [SerializeField] private InputActionReference _testGrabRight;
    [SerializeField] private InputActionReference _testRemoveLeft;
    [SerializeField] private InputActionReference _testRemoveRight;

    [Space]
    [SerializeField] private InputActionReference _actionNButton;

    [SerializeField] private NetworkObject _bullet;
    [SerializeField] private NetworkObject _spawnBulletPos;
    [SerializeField] private NetworkObject _gunPlace;
    [SerializeField] private NetworkObject _ammoPlace;

    [SerializeField] private Ammunition _ammunition;
    private PlayerStats _playerStats;
    private InputActionReference _myActionRemoveAmmo;
    private InputActionReference _myActionShoot;


    private Rigidbody _ammoBoxRB;
    private XRGrabInteractable _grabInteractable;

    private Vector3 _gunScale = new Vector3(1f, 1f, 1f);
    private int _grabbedLayer = 11;
    private int _interactLayer = 6;

    public override void Spawned()
    {
        _playerStats = GetComponentInParent<PlayerStats>();
        _grabInteractable = GetComponent<XRGrabInteractable>();
    }

    public override void FixedUpdateNetwork()
    {
        if (_grabInteractable.isSelected && gameObject.layer != _grabbedLayer)
        {
            gameObject.layer = _grabbedLayer;

            /*
            if (_testGrabLeft.action.IsPressed())
            {
                _myActionShoot = _testShootLeft;
                _myActionRemoveAmmo = _testRemoveLeft;
                _myActionShoot.action.started += ShootInput;
            }

            if (_testGrabRight.action.IsPressed())
            {
                _myActionShoot = _testShootRight;
                _myActionRemoveAmmo = _testRemoveRight;
                _myActionShoot.action.started += ShootInput;
            }
            */
            if (_actionRGrabLeft.action.IsPressed())
            {
                _myActionShoot = _actionReferenceShootingLeft;
                _myActionRemoveAmmo = _actionRemoveAmmoLeft; 
            }

            if (_actionRGrabRight.action.IsPressed())
            {
                _myActionShoot = _actionReferenceShootingLeftRight;
                _myActionRemoveAmmo = _actionRemoveAmmoRight;
            }

            _myActionShoot.action.started += ShootInput;
        }


        if (!_grabInteractable.isSelected)
        {
            SetGunToSoket();
        }

        if (_myActionRemoveAmmo != null && _myActionRemoveAmmo.action.IsPressed())
        {
            RemoveAmmo();
        }

    }

    private void SetGunToSoket()
    {
        gameObject.layer = _interactLayer;

        transform.position = _gunPlace.transform.position;
        transform.rotation = _gunPlace.transform.rotation;
        transform.localScale = _gunScale;

        if (_myActionShoot != null)
        {
            _myActionShoot.action.started -= ShootInput;
        }
    }

    private void RemoveAmmo()
    {
        _ammoBoxRB.isKinematic = false;
        _ammoBoxRB.gameObject.transform.SetParent(null);
        _ammoPlace.transform.DetachChildren();
        _ammunition.AmmoSetToGun = false;
        _playerStats.Ammo = 0;
    }

    public void Init(Rigidbody no)
    {
        _ammoBoxRB = no;
    }

    public void ShootInput(InputAction.CallbackContext context)
    {
        Debug.LogError("Shoot");
        if (HasInputAuthority && _grabInteractable.isSelected && _ammunition.AmmoSetToGun)
        {
            if(_playerStats.Ammo > 0)
            {
                _playerStats.Ammo--;

                NetworkObject nOBullet = Runner.Spawn(_bullet, _spawnBulletPos.transform.position/*new Vector3(transform.position.x,
                    transform.position.y, transform.position.z)*/, Quaternion.identity.normalized, Runner.LocalPlayer);
                nOBullet.transform.rotation = transform.rotation;
            }
        }
    }
}
