using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObjects : MonoBehaviour {

    public float tumble;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = Random.value * tumble;
    }
}
