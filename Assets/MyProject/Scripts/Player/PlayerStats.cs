using UnityEngine;
using Fusion;

public class PlayerStats : NetworkBehaviour
{
    private Vector3 _spawnPoint = new Vector3(0, 0.55f, 0);
    private BasicSpawner _basicSpawner;
    [Networked] public int HP { get; set; } = 100;
    [Networked] public int Kills { get; set; } = 0;

    public override void Spawned()
    {
        _basicSpawner = Runner.GetComponent<BasicSpawner>();
        _basicSpawner.PlayerDictionary.Add(Object.InputAuthority, this);
    }

    public override void FixedUpdateNetwork()
    {
        Debug.LogError("Player stats; " + Kills);
        ZeroHP();
    }

    private void ZeroHP()
    {
        if(HP == 0)
        {
            ReturnToSpawnPoint();
        }
    }

    private void ReturnToSpawnPoint()
    {
        Debug.LogError("Return to spawn");
        transform.position = _spawnPoint;
    }

}
