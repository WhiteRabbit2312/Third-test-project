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
    [SerializeField] private TimerUI _timerUI;
    public override void Spawned()
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
            Destroy(_playerStats);
            Destroy(_gun);
            Destroy(_killUI);
            Destroy(_timerUI);
            Destroy(_killAndTimeMenu);
        }
    }
}
