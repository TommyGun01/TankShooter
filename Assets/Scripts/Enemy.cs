using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Rigidbody2D enemy; //Referense för Enemy
    public float moveSpeed = 15.0f;

    public int enemyHP;
    public int enemydmg;

    public Player playerScript;
    public GameController gc;

    protected virtual void Awake()
    {
        enemy = this.gameObject.GetComponent<Rigidbody2D>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    protected virtual void Update()
    {
        if (enemyHP <= 0)
            Destroy(gameObject);

        MoveEnemy();
    }

    protected virtual void MoveEnemy()
    {
        enemy.velocity = new Vector2(0, -moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {

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