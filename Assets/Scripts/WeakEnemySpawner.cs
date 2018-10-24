using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemySpawner : EnemySpawner
{

    public GameObject weakEnemy; //this is the prefab for weakEnemy

    private void Awake()
    {
        maxSpawnRateInSeconds = 5f;
    }

    public override void Start()
    {
        base.Start();
    }


    public override void EnemySpawn()
    {
        base.EnemySpawn();

        //the enemies should spawn randomly between the top- and bottom-left edges of the screen

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Create enemy
        //GameObject Enemy = Instantiate(weakEnemy, new Vector3(max.x, Random.Range(min.y, max.y), 0), Quaternion.identity);
        GameObject Enemy = Instantiate(weakEnemy, new Vector3(Random.Range(-5.5f, 5.5f), max.y,0), Quaternion.identity);
    }


    public override void ScheduleNextEnemySpawn()
    {
        base.ScheduleNextEnemySpawn();
    }


    public override void IncreaseSpawnRate()
    {
        base.IncreaseSpawnRate();
    }
}