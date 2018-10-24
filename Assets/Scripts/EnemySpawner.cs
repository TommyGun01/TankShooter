using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    public float maxSpawnRateInSeconds;

    public virtual void Start()
    {
        Invoke("EnemySpawn", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);

    }

    public virtual void EnemySpawn()
    {
        ScheduleNextEnemySpawn();
    }

    public virtual void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInSeconds = Random.Range(maxSpawnRateInSeconds - 3, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInSeconds = 1f;
        }
        Invoke("EnemySpawn", spawnInSeconds);

    }

    public virtual void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;
        if (maxSpawnRateInSeconds == 1)
            CancelInvoke("IncreaseSpawnRate");
    }
}
