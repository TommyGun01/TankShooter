using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Skapar variabler
    public Rigidbody2D enemy; //Referense för Enemy
    public float moveSpeed = 15.0f;

    public int enemyHP;
    public int enemydmg;

    public Player playerScript;
    public GameController gc;

    //Länkar variabler med komponenter.
    protected virtual void Awake()
    {
        enemy = this.gameObject.GetComponent<Rigidbody2D>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    //Update där vi kollar om objektet har under 0 och isåfall förstör vi objektet.
    protected virtual void Update()
    {
        if (enemyHP <= 0)
            Destroy(gameObject);

        MoveEnemy();
    }

    //Förflyttar objektet i y led neråt.
    protected virtual void MoveEnemy()
    {
        enemy.velocity = new Vector2(0, -moveSpeed);
    }

    //Om objectet kolliderar med golvet förstörs objektet och vid kollision med spelaren så förstörs båda.
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