using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class KillDatabase : NetworkBehaviour
{
    public static KillDatabase Instance;
    private BasicSpawner _basicSpawner;


    public override void Spawned()
    {
        Instance = this;
        _basicSpawner = Runner.GetComponent<BasicSpawner>();
    }


    public int GetKill(PlayerRef playerRef)
    {
        Debug.LogError("Get kill: " + _basicSpawner.PlayerDictionary[playerRef].Kills);
            return _basicSpawner.PlayerDictionary[playerRef].Kills;
    }
    public void DetectKill(PlayerRef playerRef)
    {
        _basicSpawner.PlayerDictionary[playerRef].Kills++;
        Debug.LogError("Kill " + _basicSpawner.PlayerDictionary[playerRef].Kills);
    }
}
