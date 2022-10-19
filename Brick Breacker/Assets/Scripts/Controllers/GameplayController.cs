using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    private GameObject[] bricks1, bricks2;
    private Ball ball;

    private int brickCounter, levelCounter = 1;
    private int life = 2;
    private bool died;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }
    void Update()
    {
        BrickCounter();
        if(brickCounter == 0)
        {
            levelCounter++;
        }
    }
    void BrickCounter()
    {
        bricks1 = GameObject.FindGameObjectsWithTag("Brick");
        bricks2 = GameObject.FindGameObjectsWithTag("Brick2");

        brickCounter = bricks1.Length + bricks2.Length;
    }
}
