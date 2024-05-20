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

#if UNITY_EDITOR
        _myAction = _actionReferenceShootingUnityEditor;
#else
        _myAction = _actionReferenceShooting;
#endif

    }

    public override void FixedUpdateNetwork()
    {
        if (_myAction.action.IsPressed())
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
