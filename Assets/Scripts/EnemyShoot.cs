using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //variabler
    public GameObject Projectile;
    public Transform projectileSpawn;

    public float nextFire = 1.0f;
    public float currentTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        EnemyShooting();
    }
    //spawnar projectilen efter en visst antal sekunder som styrs av vad nextfire är. Efter första skottet väntar man i x antal sekunder innan nästa
    //då x är nextfire värdet.
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
