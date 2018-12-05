using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //skapar variabler
    public GameObject[] enemyPrefabs = new GameObject[5];
    Vector3 spawnPos;
    public float maxSpawnposX, minSpawnPosX, maxSpawnPosY, minSpawnPosY;

    public float spawnTimer;
    public float spawnTimerMax;

    public float time;
    void Start()
    {
        spawnTimer = spawnTimerMax;
    }

    // Spawnar en random prefab ifrån arrayn enemyprefabs.
    //Spawnar på en random position mellan två x värden.
    //Ökar spawnraten efter var 20,30,40 och 50 sekunder.

    void Update()
    {
        time += Time.deltaTime;
        if (spawnTimer > 0)
            spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnPos = new Vector3(Random.Range(minSpawnPosX, maxSpawnposX), Random.Range(minSpawnPosY, maxSpawnPosY));
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPos, Quaternion.identity);
            spawnTimer = spawnTimerMax;
        }
        if (time == 20f)
            spawnTimerMax--;
        if (time == 30f)
            spawnTimerMax--;
        if (time == 40f)
            spawnTimerMax--;
        if (time == 50f)
            spawnTimerMax--;

    }

}
