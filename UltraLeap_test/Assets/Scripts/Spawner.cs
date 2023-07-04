using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject anchoredObject;
    [SerializeField] Transform spawnPoint;

    public void Spawn()
    {
        Instantiate(anchoredObject, spawnPoint.position, Quaternion.identity);
    }
}
