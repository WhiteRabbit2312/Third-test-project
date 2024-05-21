using UnityEngine;
using Fusion;
using TMPro;

public class KillUI : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _textKill;
    [SerializeField] PlayerStats _playerStats;
    private BasicSpawner _basicSpawner;

    public override void Spawned()
    {
        _basicSpawner = Runner.GetComponent<BasicSpawner>();
    }

    public override void FixedUpdateNetwork()
    {
        foreach(var item in _basicSpawner.PlayerDictionary)
        {
            Debug.LogError("Player kills in KillUI: " + item.Value.Kills);
        //    Debug.LogError("KillDatabase kills: " + item.Value.Kills);
          //  _textKill[item.Key.AsIndex].text = $"Kills:  {item.Value.Kills} ";
        }

        Debug.LogError("Player dictionary " + _basicSpawner.PlayerDictionary.Count);

      
            
    }
}
