using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron;

public class BunBoozlerController : MonoBehaviour
{
    private KeyCode up, down, left, right;
    public float speed, acceleration, maxSpeed, deceleration, minSpeed;
    public Vector2 input, movement;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        up = KeyCode.W;
        down = KeyCode.S;
        left = KeyCode.A;
        right = KeyCode.D;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetKey(up) && !Input.GetKey(down))
        {
            if(movement.y < maxSpeed)
            {
                movement.y = movement.y + acceleration;
            }
            else
            {
                movement.y = maxSpeed;
            }
        }
        else if (Input.GetKey(down) && !Input.GetKey(up))
        {
            if (movement.y > -maxSpeed)
            {
                movement.y = movement.y - acceleration;
            }
            else
            {
                movement.y = -maxSpeed;
            }
        }
        else
        {
            if(Mathf.Sign(movement.y) == 1)
            {
                movement.y *= deceleration;
            }
            else
            {
                movement.y *= deceleration;
            }
        }

        if (Input.GetKey(right) && !Input.GetKey(left))
        {

            if (movement.x < maxSpeed)
            {
                movement.x = movement.x + acceleration;
            }
            else
            {
                movement.x = maxSpeed;
            }

        }
        else if (Input.GetKey(left) && !Input.GetKey(right))
        {

            if (movement.x > -maxSpeed)
            {
                movement.x = movement.x - acceleration;
            }
            else
            {
                movement.x = -maxSpeed;
            }
        }
        else
        {
            if (Mathf.Sign(movement.x) == 1)
            {
                movement.x *= deceleration;
            }
            else
            {
                movement.x *= deceleration;
            }
        }

        if(movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        animator.SetFloat("InputX", movement.x / maxSpeed);
        animator.SetFloat("InputY", movement.y /  maxSpeed);

        transform.position += new Vector3(movement.x, 0, movement.y); 
    }

}
