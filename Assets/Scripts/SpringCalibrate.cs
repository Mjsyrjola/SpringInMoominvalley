using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringCalibrate : MonoBehaviour {

    private float rotationZ = 0f;
    public float speed;

    void Start()
    {
        speed = 5;
    }

    void Update()
    {
        LockedRotation();
    }

    void LockedRotation()
    {
        rotationZ += -Input.GetAxis("Horizontal") * speed;
        rotationZ = Mathf.Clamp(rotationZ, -40, 90);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);
    }
}
