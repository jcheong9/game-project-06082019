using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMoveRandomly : MonoBehaviour
{

    public Rigidbody2D rb;
    public float accelerationTime = 0.3f;
    public float maxSpeed = 1f;
    private Vector2 movement;
    private float timeLeft;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            timeLeft += accelerationTime;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }


}
