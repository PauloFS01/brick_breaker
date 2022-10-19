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
        ScoreTextFunction();
        if(brickCounter == 0)
        {
            GameController.instance.NextLevelPanel();
            levelCounter++;
        }
    }
    void ScoreTextFunction()
    {
        GameController.instance.scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
        if(PlayerPrefs.GetInt("Score", 0) > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        }
    }
    void BrickCounter()
    {
        bricks1 = GameObject.FindGameObjectsWithTag("Brick");
        bricks2 = GameObject.FindGameObjectsWithTag("Brick2");

        brickCounter = bricks1.Length + bricks2.Length;
    }
}
