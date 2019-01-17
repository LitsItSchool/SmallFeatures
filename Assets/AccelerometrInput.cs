using UnityEngine;

public class AccelerometrInput : MonoBehaviour {

    void Update()
    {
        transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
    }
}
