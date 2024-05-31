using UnityEngine;
using Fusion;
using TMPro;

public class KillUI : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI _textKill;

    private KillCounter _killCounter;

    public override void Spawned()
    {
        _killCounter = GameObject.FindObjectOfType<KillCounter>();
    }

    public override void FixedUpdateNetwork()
    {
        if(_killCounter != null)
            _textKill.text = "Kills: " + _killCounter.KillDictionary[Object.InputAuthority].ToString();
    }
}
