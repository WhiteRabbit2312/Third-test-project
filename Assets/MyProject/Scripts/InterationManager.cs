using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterationManager : MonoBehaviour
{
    [SerializeField] private Transform pos;

    public void CreateObj(GameObject prefab)
    {
        Instantiate(prefab, pos.position, pos.rotation);
    }
}
