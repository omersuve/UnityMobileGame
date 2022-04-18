using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.instance;
    }

    void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Enemy", transform.position, Quaternion.identity);
    }
}
