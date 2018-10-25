using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    public Rigidbody2D Projectile;

    public float moveSpeed = 5.0f;

	// Use this for initialization
	void Start ()
    {
        Projectile = this.gameObject.GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Projectile.velocity = new Vector2(0, -1) * moveSpeed;	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }

}
