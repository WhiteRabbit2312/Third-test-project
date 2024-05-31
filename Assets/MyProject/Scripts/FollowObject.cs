using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform _object;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _zOffset;

    private void Update()
    {
        Vector3 newPosition = new Vector3(_object.transform.position.x + _xOffset, _yOffset, _object.transform.position.z + _zOffset);
        transform.position = newPosition;
        Quaternion newRotation = Quaternion.Euler(0, _object.transform.rotation.eulerAngles.y, 0);
        transform.rotation = newRotation;
    }
}
