using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public bool standInPlace;

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
            transform.Translate(movement);
        }
        
    }
}
