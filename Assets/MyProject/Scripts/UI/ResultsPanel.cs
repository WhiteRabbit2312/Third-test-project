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

        Debug.LogError("Kill dictionary length: " + _killCounter.KillDictionary.Count + " Text dictionary: " + _textResult.Length);
        int i = 0; 
        foreach(var item in _killCounter.KillDictionary)
        {
            _textResult[i].text = "Player " + (i + 1) + " kills: " + item.Value.ToString();
            i++;
        }

        Debug.LogError("Result kill " + _killCounter.KillDictionary.Max().Key + " Kills: " + _killCounter.KillDictionary.Max().Value.ToString());
    }

    
}
