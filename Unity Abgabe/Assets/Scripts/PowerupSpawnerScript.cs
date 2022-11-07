using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnerScript : MonoBehaviour
{
    public GameObject SpeedPowerup;
    public Transform[] spawnPoints;

    public float timeBetweenSpawns;
    float nextSpawnTime;

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Instantiate(SpeedPowerup, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
