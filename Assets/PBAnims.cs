using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBAnims : MonoBehaviour
{
    private Animator animController;
    public GameObject fx;
    public Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animController.SetBool("Walk", true);
        }
        else
        {
            animController.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animController.SetTrigger("Jump");
        }
    }

    public void InstantiateFX()
    {
        GameObject derp = Instantiate(fx,spawnPos, false);
        derp.transform.parent = spawnPos;
        derp.transform.localPosition = Vector3.zero;
        derp.transform.parent = null;
    }
}
