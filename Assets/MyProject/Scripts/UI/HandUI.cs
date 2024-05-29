using UnityEngine;
using TMPro;
using Fusion;

public class HandUI : NetworkBehaviour
{
    [SerializeField] private NetworkObject _gun;
    [SerializeField] private TextMeshProUGUI _textHP;
    [SerializeField] private TextMeshProUGUI _textAmmo;
    [SerializeField] private TextMeshProUGUI _textDebug;
    [SerializeField] private PlayerStats _playerStats;

    public override void FixedUpdateNetwork()
    {
        _textHP.text = _playerStats.HP.ToString();
        _textAmmo.text = _playerStats.Ammo.ToString();
        _textDebug.text = _gun.gameObject.layer.ToString();
    }

}
