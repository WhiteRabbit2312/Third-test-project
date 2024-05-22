using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class KillCounter : NetworkBehaviour
{
    [Networked] public NetworkDictionary<PlayerRef, int> KillDictionary => default;
}
