using UnityEngine;
using Fusion;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooting : NetworkBehaviour
{
    [SerializeField] private InputActionReference _actionReferenceShootingUnityEditor;
    [SerializeField] private InputActionReference _actionReferenceShooting;
    private InputActionReference _myAction;
    [SerializeField] private NetworkObject _bullet;
    [SerializeField] private NetworkObject _spawnBulletPos;
    [SerializeField] private NetworkObject _gunPlace;
    private XRGrabInteractable _grabInteractable;

    public override void Spawned()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _myAction = _actionReferenceShootingUnityEditor;
        _myAction.action.started += ShootInput;

#if UNITY_EDITOR

#else
        _myAction = _actionReferenceShooting;
#endif

    }

    public override void FixedUpdateNetwork()
    {

        //if (_grabInteractable.isSelected)
        //{
        //ShootInput();
        //}

        if (!_grabInteractable.isSelected)
        {
            transform.position = _gunPlace.transform.position;
        }
        //}
    }


    public void ShootInput(InputAction.CallbackContext context)
    {
        if (HasInputAuthority)
        {
            Debug.LogError("Shoot");
            NetworkObject nOBullet = Runner.Spawn(_bullet, _spawnBulletPos.transform.position, Quaternion.identity.normalized, Runner.LocalPlayer);
            
            nOBullet.transform.rotation = transform.rotation;
        }
    }
}
