using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrong : Enemy
{
    public int hits;
    // Use this for initialization
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0)
            Destroy(gameObject);
        enemy.velocity = new Vector2(0, -1) *  moveSpeed;
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.gameObject.name == "Floor")
        {
            playerScript.TakeDamage(enemydmg);
            Destroy(gameObject);
            //SendMessageUpwards("TakeDamage", dmg);
        }
        if (col.gameObject.tag == "Player")
        {
            playerScript.TakeDamage(enemydmg);
            Destroy(gameObject);
        }
    }
}
