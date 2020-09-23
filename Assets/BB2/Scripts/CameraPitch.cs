using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPitch : MonoBehaviour
{
    public float mouseXSensitivity = 4;
    public float mouseYSensitivity = 4;
    private float pitch = 0;
    public bool invertY;
    private float yaw = 0;
    

    void LateUpdate()
    {
        float yInput = Input.GetAxis("Mouse Y");
        float xInput = Input.GetAxis("Mouse X");


        if (invertY)
        {
            yInput *= -1;
        }

        pitch += yInput * mouseYSensitivity;
        yaw += xInput * mouseXSensitivity;
        

        Vector3 currentRotation = transform.eulerAngles;

        transform.rotation = Quaternion.Euler(pitch, yaw, currentRotation.z);

    }
}
