using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour {

    public Rigidbody2D projectile;

    public float moveSpeed = 10.0f;

	// Use this for initialization
	void Start ()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        projectile.velocity = new Vector2(0, 1) * moveSpeed;	
	}

    //hit detection

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
//