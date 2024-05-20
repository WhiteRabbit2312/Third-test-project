using UnityEngine;
using Fusion;
using TMPro;
using System;

public class TimerUI : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    public event Action OnEndGame;
    [Networked] private int _breakTimer { get; set; }
    [Networked] private int _timer { get; set; }
    

    public override void Spawned()
    {
        _breakTimer = 1500; // 30 seconds
        _timer = 15000; // 5 minutes
    }

    public override void FixedUpdateNetwork()
    {
        if (_breakTimer > 0)
        {
            _timerText.text = $"Break time: { (_breakTimer / 50)}";
            Debug.LogError("Time: " + (_breakTimer / 50));
            _breakTimer--;
        }

        else
        {
            if (_timer > 0)
            {
                _timerText.text = $"Time left: { (_timer / 50) / 60 } : {(_timer / 50) % 60 }";
                _timer--;
            }

            else
            {
                OnEndGame?.Invoke();
            }
        }  
    }
}
