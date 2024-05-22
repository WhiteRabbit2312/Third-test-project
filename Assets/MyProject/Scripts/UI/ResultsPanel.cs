using UnityEngine;
using Fusion;
using TMPro;
using System.Linq;

public class ResultsPanel : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI _textResult;
    private KillCounter _killCounter;

    public void Awake()
    {
        _killCounter = GameObject.FindObjectOfType<KillCounter>();
        _textResult.text = "Winner: " + _killCounter.KillDictionary.Max().Key + " Kills: " + _killCounter.KillDictionary.Max().Value.ToString();

        Debug.LogError("Result kill " + _killCounter.KillDictionary.Max().Key + " Kills: " + _killCounter.KillDictionary.Max().Value.ToString());
    }

    
}
