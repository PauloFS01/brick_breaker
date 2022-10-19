using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text scoreText, lifeScoreText, highScoreText, pauseText;
    public Button playBtn, pauseBtn;

    public Sprite[] playSprite;

    public GameObject pausePanel;
    //public GameObject[] level;

    private void Awake()
    {
        instance = this;
    }
    public void NextLevelPanel()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseText.text = "Yes Done!";
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

        pauseBtn.interactable = true;
        playBtn.onClick.RemoveAllListeners();
        playBtn.onClick.AddListener(() => NextLevel());
    }
    void NextLevel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        /*
         * if level counter is 2
         * ball will go back to its place and we will add another level
         */
    }
    void Died()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseText.text = "Game over";

        pauseBtn.interactable = true;
        playBtn.onClick.RemoveAllListeners();
        playBtn.image.sprite = playSprite[1];
        playBtn.onClick.AddListener(() => PlayAgain());
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseText.text = "Paused";

        playBtn.onClick.RemoveAllListeners();
        playBtn.image.sprite = playSprite[0];
        playBtn.onClick.AddListener(() => Unpause());


    }
    public void Unpause()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

/*    void ScoreTextFunction()
    {
        GameController.instance.scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
    }*/
}
