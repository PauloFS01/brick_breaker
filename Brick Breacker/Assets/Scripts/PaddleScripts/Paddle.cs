using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Paddle : MonoBehaviour
{
    public float speed = 0.03f , xBounds = 1.83f;

    int direction = 0;
    float previousPositionX;

    private GameObject ball;
    private float speedBall;

    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        // if paddle is in right side ball will receive right impulse
        // if it is on the left side ball  will receive left impulse
        if (direction < 1)
        {
            ball.GetComponent<Ball>().ballDir = 100;
        }
        else if(direction > -1)
        {
            ball.GetComponent<Ball>().ballDir = -100;
        }
        else
        {
            ball.GetComponent<Ball>().ballDir = 0;
        }
    }

    private void LateUpdate()
    {
        previousPositionX = transform.position.y;
    }

    private void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if(h > 0)
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        }else if (h < 0)
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        }
        if (previousPositionX > transform.position.x)
            direction = -1;
        else if (previousPositionX < transform.position.x)
            direction = 1;
        else
            direction = 0;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, - xBounds, xBounds), transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        float adjust = 3 * direction;
        target.rigidbody.velocity = new Vector2(target.rigidbody.velocity.x + adjust, target.rigidbody.velocity.y);
    }
}
