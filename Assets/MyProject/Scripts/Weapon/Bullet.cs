using UnityEngine;
using Fusion;

public class Bullet : NetworkBehaviour
{
    [SerializeField] private float _speed;
    private int _damage = 10;
    private PlayerStats _playerStatsOfBullletPlayer;

    public void Init(PlayerStats playerStats)
    {
        _playerStatsOfBullletPlayer = playerStats;
    }

    public override void FixedUpdateNetwork()
    {
        transform.Translate(Vector3.forward * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerStats playerStats))
        {
            playerStats.HP -= _damage;
           
            if (playerStats.HP <= 0)
            {
                _playerStatsOfBullletPlayer.Kills++;
                Debug.LogError("Bullet hit error");
                KillDatabase.Instance.DetectKill(Object.InputAuthority);
            }
        }
    }
}
