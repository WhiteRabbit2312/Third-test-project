using UnityEngine;
using TMPro;
using Fusion;

public class HandUI : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI _textHP;
    [SerializeField] PlayerStats _playerStats;

    public override void FixedUpdateNetwork()
    {
        _textHP.text = _playerStats.HP.ToString();
    }

}
