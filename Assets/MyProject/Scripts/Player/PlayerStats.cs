using UnityEngine;
using Fusion;

public class PlayerStats : NetworkBehaviour
{
    private BasicSpawner _basicSpawner;
    public int HP { get; set; } = 100;
    public int Kills { get; set; } = 0;

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
            HP = 100;
        }
    }

}
