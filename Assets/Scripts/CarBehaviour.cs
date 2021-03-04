using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{

    public float carSpeed;

    public PlayerBehaviour player;

    public void Init(PlayerBehaviour p, float speed)
    {
        player = p;
        carSpeed = speed;
    }

    void Update()
    {
        transform.position += Vector3.forward * (carSpeed - player.speed) * Time.deltaTime;

        if(transform.position.z < -5)
        {
            Destroy(gameObject);
        }
    }
}
