using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public GameManager gameManager;
    public float sensibility;
    public float speed;

    public float drag;
    public float horsePower;

    public int score;

    [Header("speed setup")]
    public float minSpeed;  // TODO: make it car-dependent
    public float maxSpeed;

    public HoldButtonBehaviour speedUpButton;
    public HoldButtonBehaviour slowDownButton;

    // Start is called before the first frame update
    void Start()
    {
        speed = minSpeed;
    }

    public void Init(GameManager manager, HoldButtonBehaviour speedUp, HoldButtonBehaviour slowDown)
    {
        gameManager = manager;
        speedUpButton = speedUp;
        slowDownButton = slowDown;
    }

    // Update is called once per frame
    void Update()
    {
        score += (int)(speed * Time.deltaTime);

        float hor = Input.GetAxis("Horizontal");

        float gyroHor = Input.gyro.gravity.x;

        Vector3 movement = Vector3.right * sensibility * Time.deltaTime;

        // TODO: set bounds for movement

        transform.position += movement * hor + movement * gyroHor * 10;  // right: 1,0,0

        float ver = Input.GetAxis("Vertical");

        float verButton = speedUpButton.isDown ? 1 : 0;

        if(slowDownButton.isDown)
        {
            verButton = -1;
        }

        speed += ver * horsePower - drag + verButton * horsePower;

        if(speed < minSpeed)
        {
            speed = minSpeed;
        }
        else if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            // game over
            gameManager.GameOver();

        }
    }
}
