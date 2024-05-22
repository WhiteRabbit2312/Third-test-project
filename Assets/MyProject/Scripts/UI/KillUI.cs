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
        _textKill.text = _killCounter.KillDictionary[Object.InputAuthority].ToString();
    }
}
