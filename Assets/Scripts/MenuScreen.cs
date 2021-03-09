using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{

    public TextMeshProUGUI highScoreText;

    private GameManager gameManager;

    public void Show(GameManager manager)
    {
        gameManager = manager;
        gameObject.SetActive(true);

        int highScore = PlayerPrefs.GetInt("HighScore");

        highScoreText.text = "High Score: " + highScore;
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        gameManager.StartGame();
    }
}
