using UnityEngine;

public class ThrowGun : MonoBehaviour
{
    public void SetGunToBelt(Transform gunPlace)
    {
        transform.position = gunPlace.position;
    }
}
