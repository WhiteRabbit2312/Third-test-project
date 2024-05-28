using UnityEngine;
using Fusion;
using TMPro;

public class GameStages : NetworkBehaviour
{
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private TextMeshProUGUI _timerText;
    
    [Networked] private float _timer { get; set; }

    private BasicSpawner _basicSpawner;
    private int _playersInGame = 2;
    private int _oneSecondPerTick = 3000;

    public override void Spawned()
    {
        _timer = 60*5; //5 minutes
        _basicSpawner = Runner.GetComponent<BasicSpawner>();
    }

    public override void FixedUpdateNetwork()
    {
        if(_basicSpawner.PlayerDictionary.Count == _playersInGame)
        {
            if (_timer > 0)
            {
                _timerText.text = $"Time left: { _timer / _oneSecondPerTick} : {_timer  % _oneSecondPerTick }";
                _timer -= Runner.DeltaTime;
            }

            else
            {
                _resultPanel.SetActive(true);
            }
        }  
    }
}
