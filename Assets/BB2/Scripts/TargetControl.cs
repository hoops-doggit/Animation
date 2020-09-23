using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{

    public float speed;

    void Update()
    {
        float h = 0;
        float v = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            v += speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            v -= speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            h += speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            h -= speed;
        }


        transform.Translate(new Vector3(h, v, 0));

    }
}
