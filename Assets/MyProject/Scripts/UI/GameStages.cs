using UnityEngine;
using Fusion;
using TMPro;
using System;

public class GameStages : NetworkBehaviour
{
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private TextMeshProUGUI _timerText;
    [Networked] private int _timer { get; set; }
    private BasicSpawner _basicSpawner;

    public override void Spawned()
    {
        _timer = 15000;//15000; 5 minutes
        _basicSpawner = Runner.GetComponent<BasicSpawner>();
    }

    public override void FixedUpdateNetwork()
    {
        if(_basicSpawner.PlayerDictionary.Count == 2)
        {
            if (_timer > 0)
            {
                //_timerText.text = $"Time left: { (_timer / 50) / 60 } : {(_timer / 50) % 60 }";
                _timerText.text = _timer.ToString();
                _timer--;
            }

            else
            {
                _resultPanel.SetActive(true);
            }
        }  
    }
}
