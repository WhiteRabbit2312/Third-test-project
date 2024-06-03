using UnityEngine;
using Fusion;

public class Bullet : NetworkBehaviour
{
    [SerializeField] private float _speed;
    private KillCounter _killCounter;
    private int _damage = 10;
    private float _scale = 0.0001f;

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

            if (playerStats.HP == 0)
            {
                playerStats.HP = 100;
                playerStats.ReturnToSpawnPoint();

                int currentKills = _killCounter.KillDictionary[Object.InputAuthority];
                currentKills++;
                _killCounter.KillDictionary.Set(Object.InputAuthority, currentKills);
            }

            transform.localScale = new Vector3(_scale, _scale, _scale);

        }
        if(other.gameObject.tag == "Obstacle" && HasInputAuthority)
        {
            Runner.Despawn(Object);
        }
    }

    


}

