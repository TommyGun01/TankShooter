using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Gör variabler
    public GameObject projectile;
    public Transform projectileSpawn;

    public float nextFire = 1.0f;
    public float currentTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        projectileSpawn = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Shoots();
    }

    //Spawnar projektilen, har en cooldown som regleras av nextFire
    public void Shoots()
    {
        currentTime += Time.deltaTime;
        if (Input.GetButton("Fire1") && currentTime > nextFire)
        {
            nextFire += currentTime;

            Instantiate(projectile, projectileSpawn.position, Quaternion.identity);

            nextFire -= currentTime;
            currentTime = 0.0f;
        }
    }
}
