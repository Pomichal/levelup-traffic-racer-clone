using TMPro;
using UnityEngine;

public class GyroScreen : MonoBehaviour
{
    public TextMeshProUGUI gyroText;

    void Start()
    {
        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.0167f;

    }

    void Update()
    {

        RedrawGyroscopeText();
    }
    void RedrawGyroscopeText()
    {
        gyroText.text = "gtu: " + GyroToUnity(Input.gyro.attitude) + "\n" +
            GyroToUnity(Input.gyro.attitude).eulerAngles + "\n" +
            Input.gyro.gravity;
    }

    private Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
