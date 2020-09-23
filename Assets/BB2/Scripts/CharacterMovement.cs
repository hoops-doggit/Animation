using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public bool standInPlace;
    private float yaw = 0;
    public float mouseYSensitivity = 1;

    Vector3 movement;
    [SerializeField] private float speed = 1;
    [SerializeField] private Animator controller = null;

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");        

        controller.SetFloat("BlendX", movement.x);
        controller.SetFloat("BlendY", movement.z);

        

        if (!standInPlace)
        {
            movement *= speed;
            transform.Translate(movement * speed * Time.deltaTime);
        }


        yaw += Input.GetAxis("Mouse X") * mouseYSensitivity;

        if(movement.magnitude > 0)
        {
            transform.rotation = Quaternion.Euler(0, yaw, 0);
        }
        
        
    }
}
