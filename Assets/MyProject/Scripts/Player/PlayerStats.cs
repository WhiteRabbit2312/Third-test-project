using UnityEngine;
using Fusion;

public class PlayerStats : NetworkBehaviour
{
    private Vector3 _spawnPoint = new Vector3(0, 0.55f, 0);
    private BasicSpawner _basicSpawner;
    [Networked] public int HP { get; set; } = 100;
    [Networked] public int Kills { get; set; } = 0;
    [Networked] public int Ammo { get; set; } = 40;

    public override void Spawned()
    {
        _basicSpawner = Runner.GetComponent<BasicSpawner>();
        _basicSpawner.PlayerDictionary.Add(Object.InputAuthority, this);
    }

    public override void FixedUpdateNetwork()
    {
        ZeroHP();
    }

    private void ZeroHP()
    {
        if(HP == 0)
        {
            ReturnToSpawnPoint();
            HP = 100;
        }
    }

    private void ReturnToSpawnPoint()
    {
        transform.position = _spawnPoint;
    }
}
