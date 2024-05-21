using UnityEngine;
using Fusion;
using TMPro;

public class KillUI : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI _textKill;
    [SerializeField] PlayerStats _playerStats;

    public override void FixedUpdateNetwork()
    {
        _textKill.text = _playerStats.Kills.ToString();
    }
}
