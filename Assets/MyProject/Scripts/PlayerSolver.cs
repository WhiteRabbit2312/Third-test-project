using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using Unity.XR.CoreUtils;

public class PlayerSolver : NetworkBehaviour
{
    [SerializeField] private ActionBasedContinuousMoveProvider _actionBasedContinuousMoveProvider;
    [SerializeField] private LocomotionSystem _locomotionSystem;
    [SerializeField] private XROrigin _xROrigin;
    public override void Spawned()
    {
        if (!HasInputAuthority)
        {
            Destroy(_actionBasedContinuousMoveProvider);
            Destroy(_locomotionSystem);
            Destroy(_xROrigin);
        }
    }
}
