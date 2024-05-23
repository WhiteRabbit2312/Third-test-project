using UnityEngine;
using Fusion;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooting : NetworkBehaviour
{
    [SerializeField] private InputActionReference _actionReferenceShootingUnityEditor;
    [SerializeField] private InputActionReference _actionReferenceShooting;
    private PlayerStats _playerStats;

    private InputActionReference _myAction;
    [SerializeField] private NetworkObject _bullet;
    [SerializeField] private NetworkObject _spawnBulletPos;
    [SerializeField] private NetworkObject _gunPlace;
    private XRGrabInteractable _grabInteractable;

    public override void Spawned()
    {
        _playerStats = GetComponentInParent<PlayerStats>();
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _myAction = _actionReferenceShooting;
        _myAction.action.started += ShootInput;

#if UNITY_EDITOR

#else
        _myAction = _actionReferenceShooting;
#endif

    }

    public override void FixedUpdateNetwork()
    {
        if (!_grabInteractable.isSelected)
        {
            transform.position = _gunPlace.transform.position;
        }
    }


    public void ShootInput(InputAction.CallbackContext context)
    {
        if (HasInputAuthority)
        {
            if (_playerStats.Ammo > 0)
            {
                _playerStats.Ammo--;
                //Debug.LogError("Shoot");
                NetworkObject nOBullet = Runner.Spawn(_bullet, _spawnBulletPos.transform.position, Quaternion.identity.normalized, Runner.LocalPlayer);
                nOBullet.transform.rotation = transform.rotation;
            }
        }
    }
}
