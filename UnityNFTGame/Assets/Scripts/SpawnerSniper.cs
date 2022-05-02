using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSniper : MonoBehaviour
{
    public GameObject enemySniper;
    public Transform[] spawnPoints;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    private void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnPoints.Length);
            Instantiate(enemySniper, spawnPoints[randPos].position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
