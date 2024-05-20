using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

public class KillUI : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI _textKill;
    [SerializeField] PlayerStats _playerStats;

    public override void FixedUpdateNetwork()
    {
        _textKill.text = KillDatabase.Instance.GetKill(Object.InputAuthority).ToString();
    }
}
