﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private bool standInPlace;    
    [SerializeField] private bool gunDrawn;    
    [SerializeField] private float mouseYSensitivity = 1;

    
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private Animator controller = null;

    private float yaw = 0;
    Vector3 movement;

    private void Start()
    {
        controller.SetBool("Armed", gunDrawn);
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");        

        controller.SetFloat("BlendX", movement.x);
        controller.SetFloat("BlendY", movement.z);
        

        if (!standInPlace)
        {
            movement *= movementSpeed;
            transform.Translate(movement * movementSpeed * Time.deltaTime);
        }


        yaw += Input.GetAxis("Mouse X") * mouseYSensitivity;

        if(movement.magnitude > 0)
        {
            transform.rotation = Quaternion.Euler(0, yaw, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (gunDrawn)
            {
                gunDrawn = false;
                controller.SetBool("Armed", gunDrawn);
            }
            else
            {
                gunDrawn = true;
                controller.SetBool("Armed", gunDrawn);
            }
        }
        
        
    }
}
