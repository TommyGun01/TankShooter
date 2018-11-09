using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingEnemy : Enemy
{
    
    public float dodge;
    private float dodgeTimer;
    public float timerMax;
    public float dodgeMin;
    public float dodgeMax;
    // Use this for initialization
    void Start()
    {
        dodgeTimer = timerMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (dodgeTimer > 0)
            dodgeTimer -= Time.deltaTime;
        if (dodgeTimer <= 0)
            Dodge();

        enemy.velocity = new Vector2(dodge *moveSpeed, (-1 * moveSpeed));
        if (enemyHP <= 0)
            Destroy(gameObject);
    }
    public void Dodge()
    {
        dodgeMax = Random.Range(3, 7);
        dodgeMin = Random.Range(-3, -7);
        dodge = Random.Range(dodgeMin, dodgeMax);
        if (dodge < 4 && dodge > 0)
            dodge += 3;
        if (dodge > -4 && dodge < 0)
            dodge -= 3;
        dodgeTimer = timerMax;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "RightWall")
        {
            Debug.Log("Hit the right wall");
            dodge -= 7;
        }
        if (col.gameObject.name == "LeftWall")
        {
            Debug.Log("Hit the left wall");
            dodge += 7;
        }
        if (col.gameObject.name == "Floor")
            Destroy(gameObject);
        
    }
}
