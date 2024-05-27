using UnityEngine;
using Fusion;
using TMPro;
using System;

public class GameStages : NetworkBehaviour
{
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private TextMeshProUGUI _timerText;
    private const int _playersInGame = 1;
    private int _oneSecondPerTick = 50;
    private int _secondsInMinute = 60;
    

    [Networked] private int _timer { get; set; }
    private BasicSpawner _basicSpawner;

    public override void Spawned()
    {
        _timer = 1000;//15000; 5 minutes
        _basicSpawner = Runner.GetComponent<BasicSpawner>();
    }

    public override void FixedUpdateNetwork()
    {
        if(_basicSpawner.PlayerDictionary.Count == _playersInGame)
        {
            if (_timer > 0)
            {
                _timerText.text = $"Time left: { (_timer / _oneSecondPerTick) / _secondsInMinute } : {(_timer / _oneSecondPerTick) % _secondsInMinute }";
                _timer--;
            }

            else
            {
                _resultPanel.SetActive(true);
                //_resultPanel.GetComponent<ResultsPanel>().Init();
            }
        }  
    }
}
