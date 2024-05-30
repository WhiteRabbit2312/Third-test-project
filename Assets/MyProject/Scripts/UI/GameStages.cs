using UnityEngine;
using Fusion;
using TMPro;

public class GameStages : NetworkBehaviour
{
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private TextMeshProUGUI _timerText;
    
    [Networked] private int _timer { get; set; } = 150;//5 minutes

    private BasicSpawner _basicSpawner;
    private int _playersInGame = 2;
    private int _oneSecondPerTick = 50;
    private int _ticksInSecond = 60;

    public override void Spawned()
    {
        _basicSpawner = Runner.GetComponent<BasicSpawner>();
    }

    public override void FixedUpdateNetwork()
    {
        if(_basicSpawner.PlayerDictionary.Count == _playersInGame)
        {
            if (_timer > 0)
            {
                _timerText.text = $"Time left: { (_timer / _oneSecondPerTick) / _ticksInSecond } : {(_timer / _oneSecondPerTick) % _ticksInSecond }";

                //_timerText.text = $"Time left: { _timer / _oneSecondPerTick} : {_timer  % _oneSecondPerTick }";
                _timer -= 2;
                
            }

            else
            {
                _resultPanel.SetActive(true);
            }
        }  
    }
}
