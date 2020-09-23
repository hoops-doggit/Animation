using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineSpin : MonoBehaviour
{

    public Transform lowerSpine;
    public float sensitivityX = 1;
    public Quaternion offset;
    float spineSpin;

    // Update is called once per frame
    void LateUpdate()
    {
        spineSpin += Input.GetAxis("Mouse X") * sensitivityX;
        lowerSpine.eulerAngles = new Vector3(0, spineSpin, 0);

        // complete guess. Math to apply overall model tilt to the spine:
        lowerSpine.rotation = transform.rotation * lowerSpine.rotation;
    }
}
