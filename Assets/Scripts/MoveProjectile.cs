using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour {

    public Rigidbody2D projectile;
    public GameController gc;

    public float moveSpeed = 10.0f;
    // Use this for initialization
    private void Awake()
    {
        projectile = GetComponent<Rigidbody2D>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	// Update is called once per frame
	void Update ()
    {
        projectile.velocity = new Vector2(0, 1) * moveSpeed;	
	}

    //hit detection
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().enemyHP--;
            if (collision.gameObject.name == "WeakEnemy(Clone)")
                gc.points += 5;
            if (collision.gameObject.name == "DodgingEnemy(Clone)")
                gc.points += 15;
            if (collision.gameObject.name == "StrongEnemy(Clone)")
                gc.points += 10;
            if (collision.gameObject.name == "EnemyShootingDodge(Clone)")
                gc.points += 15;
        }
        /*
        if (collision.gameObject.name == "StrongEnemy")
        {
            collision.gameObject.GetComponent<EnemyStrong>().enemyHP--;
            Debug.Log("Damaged");
            
        }
        */
        Destroy(gameObject);
    }
}
