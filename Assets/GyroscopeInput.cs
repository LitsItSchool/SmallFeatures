using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeInput : MonoBehaviour {

    private bool isGyroAvailable;

    void Start()
    {
        isGyroAvailable = SystemInfo.supportsGyroscope;
    }

    void Update () {
        if (isGyroAvailable)
        {
           transform.rotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        }
    }
}
