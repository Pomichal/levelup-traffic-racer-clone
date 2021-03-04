using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<CarBehaviour> carPrefabs;
    public PlayerBehaviour player;
    public float spawnTime;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = spawnTime;
            SpawnCar();
        }
    }

    private void SpawnCar()
    {
        int line = Random.Range(0, 4);

        CarBehaviour car = Instantiate(
                carPrefabs[Random.Range(0, carPrefabs.Count)],
                new Vector3(-1.5f + 1.5f * line, 0, 20),
                Quaternion.identity);
        car.Init(player, Random.Range(player.minSpeed * 0.7f, player.maxSpeed * 0.9f));
    }
}
