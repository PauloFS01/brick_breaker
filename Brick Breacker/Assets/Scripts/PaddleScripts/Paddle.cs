using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 0.03f , xBounds = 1.83f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
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
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, - xBounds, xBounds), transform.position.y);
    }
}
