using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D enemy; //Referense för Enemy
    public float moveSpeed = 15.0f;
    public bool changeDirections = false;

    public int enemyHP;
    public int enemydmg;

    public Player playerScript;

    public GameController gc;
	// Use this for initialization
	void Start ()
    {
        enemy = this.gameObject.GetComponent<Rigidbody2D> ();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (enemyHP<= 0)
            Destroy(gameObject);
        MoveEnemy();
	}

    public void MoveEnemy()
    {
        if (changeDirections == true)
        {
            enemy.velocity = new Vector2(0, -1) * -1 * moveSpeed;
        }
        else if (changeDirections == false)
        {
            enemy.velocity = new Vector2(0, -1) * moveSpeed;
        }

    }
     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "RightWall")
        {
            Debug.Log("Hit the right wall");
            changeDirections = true;
        }
        if(col.gameObject.name == "LeftWall")
        {
            Debug.Log("Hit the left wall");
            changeDirections = false;
        }
        if (col.gameObject.name == "Floor")
        {
            //playerScript.TakeDamage(enemydmg);
            Destroy(gameObject);
            //SendMessageUpwards("TakeDamage", dmg);
        }
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

}

