using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraScoreSpawner : MonoBehaviour
{

    public GameObject extraScore;
    public Transform[] spawnPoints;

    public float timeBetweenSpawns;
    float nextSpawnTime;

    void Start()
    {

    }

    //1. Objekt Spawn sofort, ab dann immer im festgelegten Intervall
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Instantiate(extraScore, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
