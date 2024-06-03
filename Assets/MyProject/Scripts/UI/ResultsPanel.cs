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

        int i = 0; 
        foreach(var item in _killCounter.KillDictionary)
        {
            int plyaerNumber = i + 1;
            _textResult[i].text = "Player " + plyaerNumber + " kills: " + item.Value.ToString();
            i++;
        }
    }

    
}
