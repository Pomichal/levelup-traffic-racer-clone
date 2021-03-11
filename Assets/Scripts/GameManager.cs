using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<CarBehaviour> carPrefabs;
    public PlayerBehaviour playerPrefab;
    public float spawnTime;

    [Header("UI")]
    public GameOverPopup gameOverPopup;
    public MenuScreen menuScren;
    public InGameScreen inGameScreen;

    private float timer;
    private bool gameOn;
    private PlayerBehaviour playerInstance;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        ShowMenu();
    }

    public void ShowMenu()
    {
        inGameScreen.Hide();
        menuScren.Show(this);
    }

    // TODO: setup the basic game loop
    public void StartGame()
    {
        timer = spawnTime;
        playerInstance = Instantiate(playerPrefab);
        playerInstance.Init(this, inGameScreen.speedUpButton, inGameScreen.slowDownButton);
        gameOn = true;
        inGameScreen.Show();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOn)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                timer = spawnTime;
                SpawnCar();
            }
        }
    }

    private void SpawnCar()
    {
        int line = Random.Range(0, 4);

        CarBehaviour car = Instantiate(
                carPrefabs[Random.Range(0, carPrefabs.Count)],
                new Vector3(-1.5f + 1.5f * line, 0, 20),
                Quaternion.identity);
        car.Init(playerInstance, Random.Range(playerInstance.minSpeed * 0.7f, playerInstance.maxSpeed * 0.9f));
    }

    public void GameOver()
    {
        gameOverPopup.Show(playerInstance.score, this);
        inGameScreen.Hide();
        gameOn = false;
        Destroy(playerInstance.gameObject);
    }
}
