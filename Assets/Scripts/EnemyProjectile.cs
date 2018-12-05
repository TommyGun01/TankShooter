using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    //Gör variabler
    public Rigidbody2D Projectile;

    public float moveSpeed = 5.0f;

    // Länkar projectile till objektets rigidbody2d

    void Start()
    {
        Projectile = this.gameObject.GetComponent<Rigidbody2D>();

    }

    // Förflyttar projektilen ner.
    void Update()
    {
        Projectile.velocity = new Vector2(0, -1) * moveSpeed;
    }

    //Om projektilen träffar spelaren förstörs spelaren och om projektilen träffar botten så förstörs den.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "Floor")
        {
            Destroy(gameObject);
        }
    }

}
