using UnityEngine;
using TMPro;
using Fusion;

public class HandUI : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI _textHP;
    [SerializeField] private TextMeshProUGUI _textAmmo;
    [SerializeField] PlayerStats _playerStats;

    public override void FixedUpdateNetwork()
    {
        _textHP.text = _playerStats.HP.ToString();
        _textAmmo.text = _playerStats.Ammo.ToString();
    }

}
