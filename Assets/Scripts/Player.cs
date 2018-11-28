using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public int playerHP;

    public Rigidbody2D player;
    // Use this for initialization
    private void Awake()
    {
        player = this.GetComponent<Rigidbody2D>();
    }
	// Update is called once per frame
	void FixedUpdate ()
    {
        MovePlayer();
        if (playerHP <= 0)
            Destroy(gameObject);
	}
    public void MovePlayer()
    {
        //this.transform.Translate(Input.GetAxis("Horizontal"), 0, 0);
        player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
    }
    public void TakeDamage(int dmg)
    {
        playerHP -= dmg;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
}
