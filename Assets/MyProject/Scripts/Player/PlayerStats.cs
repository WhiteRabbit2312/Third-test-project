using UnityEngine;
using Fusion;

public class PlayerStats : NetworkBehaviour
{
    public int HP = 100;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            Debug.LogError("HP: " + HP);
            HP -= bullet.Damage;
        }
    }
}
