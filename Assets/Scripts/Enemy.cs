using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D enemy; //Referense för Enemy
    public float moveSpeed = 15.0f;
    public bool changeDirections = false;

	// Use this for initialization
	void Start ()
    {
        enemy = this.gameObject.GetComponent<Rigidbody2D> ();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveEnemy();
	}

    public void MoveEnemy()
    {
        if (changeDirections == true)
        {
            enemy.velocity = new Vector2(1, 0) * -1 * moveSpeed;
        }
        else if (changeDirections == false)
        {
            enemy.velocity = new Vector2(1, 0) * moveSpeed;
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
    }

}

