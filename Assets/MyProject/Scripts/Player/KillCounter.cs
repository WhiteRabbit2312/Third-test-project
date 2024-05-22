using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System;

public class KillCounter : NetworkBehaviour
{
    [Networked, OnChangedRender(nameof(Huy))] public NetworkDictionary<PlayerRef, int> KillDictionary => default;

    private void Huy()
    {
        foreach (var item in KillDictionary)
        {
            Debug.LogError("Player: " + item.Key + "Bullet all kills: " + item.Value);
        }
    }
}
