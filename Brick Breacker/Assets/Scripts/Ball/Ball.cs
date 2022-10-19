using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed, multipler, constantSpeed, ballDir;

    public Transform startPoint;
    private Rigidbody2D myBody;

    private bool canMove, shoot;
    private int score;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (canMove)
        {   
            if(!shoot)
            {
                shoot = true;
                myBody.AddForce(new Vector2(ballDir, speed * multipler));
            }
        }
        else
        {
            transform.position = startPoint.position;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canMove = true;
        }
        myBody.velocity = constantSpeed * myBody.velocity.normalized;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Brick")
        {
            Destroy(target.gameObject);
            score += 100;
            PlayerPrefs.SetInt("Score", score);
        }
        if (target.gameObject.tag == "Brick2")
        {
            target.gameObject.tag = "Brick";
            score += 100;
            PlayerPrefs.SetInt("Score", score);
        }
    }
}
