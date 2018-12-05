using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingEnemy : Enemy
{
    //Skapar Variabler
    public float dodge;
    public float timerMax;
    public float dodgeMin;
    public float dodgeMax;

    private float dodgeTimer;
    // Use this for initialization
    void Start()
    {
        dodgeTimer = timerMax; //Sätter dodgetimer till max timer
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update(); //Tar base update funktionen från Enemy scriptet

        //Kollar om timerns går under 0 och då startas funktionen dodge
        if (dodgeTimer > 0)
            dodgeTimer -= Time.deltaTime;
        if (dodgeTimer <= 0)
            Dodge();
    }

    //Overridar MoveEnemy så dodge är med
    //Gäller inte för andra är object med dodgingenemy scriptet
    protected override void MoveEnemy()
    {
        enemy.velocity = new Vector2(dodge * moveSpeed, (-1 * moveSpeed));
    }

    //Denna funktionen tar fram ett random tal mellan 3-7 och sätter det till max dodgevärdet.
    //Sen sätter vi dodgeMin till ett tal mellan -3 och -7.
    //Sätter tar vi fram ett random tal mellan dodgemin och dodgemax. Det värdet måste vara minst -7 och högst 7 men får ej vara mellan -3 och 3
    //Så då adderar vi 3 om dodge är mellan 0 och 4 eller subtraherar med 3 om det är mellan -4 och 0

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

    //Om objectet collidar med en vägg sätter vi dodge så den förflyttas bort från väggen.
    //Sen om den kolliderar med floor vilket är en collider i botten av skärmen så destroyar vi gameobjectet.
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