using UnityEngine;
using Fusion;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooting : NetworkBehaviour
{
    [SerializeField] private InputActionReference _actionReferenceShootingUnityEditor;
    [SerializeField] private InputActionReference _actionReferenceShooting;
    [SerializeField] private InputActionReference _actionRemoveAmmoLeft;
    [SerializeField] private InputActionReference _actionRemoveAmmoRight;
    
    [SerializeField] private NetworkObject _bullet;
    [SerializeField] private NetworkObject _spawnBulletPos;
    [SerializeField] private NetworkObject _gunPlace;
    [SerializeField] private NetworkObject _ammoPlace;

    private PlayerStats _playerStats;
    private InputActionReference _myAction;
    private Rigidbody _ammoBoxRB;
    private XRGrabInteractable _grabInteractable;

    private Vector3 _gunScale = new Vector3(1f, 1, 1f);

    public override void Spawned()
    {
        _playerStats = GetComponentInParent<PlayerStats>();
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _myAction = _actionReferenceShooting;
        _myAction.action.started += ShootInput;
    }

    public override void FixedUpdateNetwork()
    {
        if (!_grabInteractable.isSelected)
        {
            transform.position = _gunPlace.transform.position;
            transform.rotation = _gunPlace.transform.rotation;
            transform.localScale = _gunScale;
        }

        if (_actionRemoveAmmoLeft.action.IsPressed() || _actionRemoveAmmoRight.action.IsPressed())
        {
            _ammoBoxRB.isKinematic = false;
            _ammoPlace.transform.DetachChildren();
        }
    }

    public void Init(Rigidbody no)
    {
        _ammoBoxRB = no;
    }

    public void ShootInput(InputAction.CallbackContext context)
    {
        if (HasInputAuthority && _grabInteractable.isSelected)
        {
            if(_playerStats.Ammo > 0)
            {
                _playerStats.Ammo--;
                NetworkObject nOBullet = Runner.Spawn(_bullet, transform.position, Quaternion.identity.normalized, Runner.LocalPlayer);
                nOBullet.transform.rotation = transform.rotation;
            }
        }
    }
}
