using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPopup : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI newHighScoreText;

    private GameManager gameManager;

    public void Show(int newScore, GameManager manager)
    {
        gameManager = manager;
        gameObject.SetActive(true);

        scoreText.text = "Score: " + newScore;

        int highScore = PlayerPrefs.GetInt("HighScore");

        highScoreText.text = "High Score: " + highScore;

        if(newScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", newScore);
            newHighScoreText.text = "New high score!!!";
        }
        else
        {
            newHighScoreText.text = "better luck next time!";
        }
    }

    public void ReturnToMenu()
    {
        gameObject.SetActive(false);

        gameManager.ShowMenu();
    }

    public void RestartGame()
    {
        gameObject.SetActive(false);

        gameManager.StartGame();

    }
}
