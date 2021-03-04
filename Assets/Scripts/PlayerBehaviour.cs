using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float sensibility;
    public float speed;

    public float drag;
    public float horsePower;

    [Header("speed setup")]
    public float minSpeed;  // TODO: make it car-dependent
    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        speed = minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * hor * sensibility * Time.deltaTime;  // right: 1,0,0

        float ver = Input.GetAxis("Vertical");

        speed += ver * horsePower - drag;

        if(speed < minSpeed)
        {
            speed = minSpeed;
        }
        else if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}
