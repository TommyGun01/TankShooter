using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject Projectile;
    public Transform projectileSpawn;

    public float nextFire = 1.0f;
    public float currentTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        EnemyShooting();
    }

    public void EnemyShooting()
    {
        currentTime += Time.deltaTime;

        if(currentTime > nextFire)
        {
            nextFire += currentTime;
            Instantiate(Projectile, projectileSpawn.position, Quaternion.identity);
            nextFire -= currentTime;
            currentTime = 0.0f;
        }
    }
}
