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

        if(transform.position.z < -5 || transform.position.z > 45)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        float dist = 3f;

        Debug.DrawRay(transform.position, transform.forward * dist, Color.green);

        if(Physics.Raycast(transform.position, transform.forward, out hit, dist))
        {
            Debug.DrawRay(transform.position, transform.forward * dist, Color.red);
            if(hit.collider.CompareTag("Car"))
            {
                carSpeed = hit.collider.gameObject.GetComponent<CarBehaviour>().carSpeed;
            }
        }
    }
}
