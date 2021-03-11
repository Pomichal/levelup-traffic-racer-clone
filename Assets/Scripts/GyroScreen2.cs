using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GyroScreen2 : MonoBehaviour
{
    public TextMeshProUGUI gyroText;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        PrintGyroText();
    }

    void PrintGyroText()
    {
        gyroText.text = GyroToUnity(Input.gyro.attitude) + "\n" +
            GyroToUnity(Input.gyro.attitude).eulerAngles + "\n" +
            Input.gyro.gravity;
    }

    private Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
