using UnityEngine;
using Fusion;

public class KillDatabase : NetworkBehaviour
{
    private BasicSpawner _basicSpawner;

    public override void Spawned()
    {
        //_basicSpawner = Runner.GetComponent<BasicSpawner>();
    }

    public override void FixedUpdateNetwork()
    {
        //Debug.LogError("Player dictionary: " + _basicSpawner.PlayerDictionary.Count);
    }

    public void DetectKill(PlayerRef playerRef)
    {
        //_basicSpawner.PlayerDictionary[playerRef].Kills++;
        //Debug.LogError("Kill " + _basicSpawner.PlayerDictionary[playerRef].Kills);
    }
}
