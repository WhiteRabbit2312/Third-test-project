using UnityEngine;
using Fusion;
using System.Collections;

public class Bullet : NetworkBehaviour
{
    [SerializeField] private float _speed;
    private KillCounter _killCounter;
    private int _damage = 10;

    public override void Spawned()
    {
        _killCounter = GameObject.FindObjectOfType<KillCounter>();
    }
    public override void FixedUpdateNetwork()
    {
        transform.Translate(Vector3.forward * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerStats playerStats) 
            && other.GetComponent<NetworkObject>().InputAuthority != Object.InputAuthority)
        {
            playerStats.HP -= _damage;

            Debug.LogError("Player HP: " + playerStats.HP);

            if (playerStats.HP == 0)
            {
                Debug.LogError("Death");

                int currentKills = _killCounter.KillDictionary[Object.InputAuthority];
                currentKills++;
                _killCounter.KillDictionary.Set(Object.InputAuthority, currentKills);

                Debug.LogError("Kills in bullet script: " + _killCounter.KillDictionary[Object.InputAuthority]);
                foreach (var item in _killCounter.KillDictionary)
                {
                    Debug.LogError("Player: " + item.Key + "Bullet all kills: " + item.Value);
                }

                
            }
            

        }

    }


    

}
