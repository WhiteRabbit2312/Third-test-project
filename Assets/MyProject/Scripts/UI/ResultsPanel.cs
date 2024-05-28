using UnityEngine;
using Fusion;
using TMPro;
using System.Linq;

public class ResultsPanel : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _textResult;
    private KillCounter _killCounter;

    public void OnEnable()
    {
        _killCounter = GameObject.FindObjectOfType<KillCounter>();

        foreach(var item in _killCounter.KillDictionary)
        {
            _textResult[item.Key.AsIndex].text = item.Value.ToString();
        }

        Debug.LogError("Result kill " + _killCounter.KillDictionary.Max().Key + " Kills: " + _killCounter.KillDictionary.Max().Value.ToString());
    }

    
}
