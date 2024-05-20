using UnityEngine;
using Fusion;

public class PlayerStats : NetworkBehaviour
{
    public int HP = 100;
    public int Kills = 0;
    

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

   

    private void SetKills()
    {
        Kills++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            Debug.LogError("HP: " + HP);
            HP -= bullet.Damage;
        }
    }
}
