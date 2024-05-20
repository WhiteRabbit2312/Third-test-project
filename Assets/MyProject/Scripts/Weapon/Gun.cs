using UnityEngine;
using Fusion;

public class Gun : NetworkBehaviour
{
    private Transform _playerToFollow;
    [SerializeField]private float _offsetX;
    [SerializeField]private float _offsetY;
    [SerializeField]private float _offsetZ;

    public override void Spawned()
    {
        _playerToFollow = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    public override void FixedUpdateNetwork()
    {
        Follow();
    }

    private void Follow()
    {
        transform.position = new Vector3(_playerToFollow.position.x, 
            _playerToFollow.position.y, _playerToFollow.position.z);
    }
}
