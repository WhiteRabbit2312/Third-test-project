using UnityEngine;
using Fusion;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.XR;
using Unity.XR.CoreUtils;

public class PlayerSolver : NetworkBehaviour
{
    [SerializeField] private ActionBasedContinuousMoveProvider _actionBasedContinuousMoveProvider;
    [SerializeField] private ActionBasedContinuousTurnProvider _actionBasedContinuousTurnProvider;
    [SerializeField] private ActionBasedController _basedControllerLeft;
    [SerializeField] private ActionBasedController _basedControllerRight;
    [SerializeField] private TrackedPoseDriver _trackedPoseDriver;
    [SerializeField] private Camera _camera;
    [SerializeField] private LocomotionSystem _locomotionSystem;
    [SerializeField] private XROrigin _xROrigin;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private NetworkObject _gun;
    [SerializeField] private KillAndTimeMenu _killAndTimeMenu;
    [SerializeField] private KillUI _killUI;
    [SerializeField] private GameStages _gameStages;
    [SerializeField] private GameObject _playerModel;
    [SerializeField] private XRGrabInteractable _xRGrabInteractable;
    [SerializeField] private XRGrabInteractable _xRGrabInteractableAmmo;
    [SerializeField] private XRSimpleInteractable _xRSimpleInteractable;
    [SerializeField] private XRSimpleInteractable _xRSimpleInteractableAmmo;
    public override void Spawned()
    {
        DestroyEnemyComponents();
        HidePlayerModel();
    }

    private void HidePlayerModel()
    {
        if (HasInputAuthority)
        {
            Destroy(_playerModel);
        }
    }

    private void DestroyEnemyComponents()
    {
        if (!HasInputAuthority)
        {
            Destroy(_actionBasedContinuousMoveProvider);
            Destroy(_actionBasedContinuousTurnProvider);
            Destroy(_locomotionSystem);
            Destroy(_xROrigin);
            Destroy(_rb);
            Destroy(_basedControllerLeft);
            Destroy(_basedControllerRight);
            Destroy(_trackedPoseDriver);
            Destroy(_camera);
            Destroy(_gun);
            Destroy(_killUI);
            Destroy(_gameStages);
            Destroy(_killAndTimeMenu);
            Destroy(_xRGrabInteractable);
            Destroy(_xRGrabInteractableAmmo);
            Destroy(_xRSimpleInteractable);
            Destroy(_xRSimpleInteractableAmmo);
        }
    }
}
