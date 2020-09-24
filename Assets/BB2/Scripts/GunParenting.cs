using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParenting : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] Transform gunHand;
    private Transform back;
    Vector3 startPos;
    Quaternion startRot;
    Animator animator;

    private void Start()
    {
        if(gun == null)
        {
            return;
        }
        back = gun.transform.parent;
        startPos = gun.transform.localPosition;
        startRot = gun.transform.localRotation;
        animator = GetComponent<Animator>();
    }

    public void GunState(int i)
    {
        switch (i)
        {
            case 0: 
                // sets the weight of the second layer in layers panel to 1
                animator.SetLayerWeight(1, 1);
                break;
            case 1: 
                // sets the weight of the second layer in layers panel to 0
                animator.SetLayerWeight(1, 0);
                break;

        }
    }

    public void ParentGun()
    {
        // this gets called by an event in the draw gun animation clip
        // it just parents the gun object to the hand
        gun.transform.SetParent(gunHand);
        Debug.Log("parented gun");
    }

    public void RotateGun(int i)
    {
        // this method gets called twice during the draw gun animation
        // it just sets the rotation of the gun so that it looks believable enough
        switch (i)
        {
            case 0:// when gun is near head
                gun.transform.localRotation = Quaternion.Euler(6.607f, -65.626f, -176.043f);
                break;
            case 1:// when gun is near other hand
                gun.transform.localRotation = Quaternion.Euler(22.875f, -39.69f, -165.719f);
                break;
            case 2:// when character is running forwards
                gun.transform.localRotation = Quaternion.Euler(22.875f, -39.69f, -191.785f);
                Debug.Log("words");
                break;
        }
        
    }

    public void UnparentGun()
    {
        // this gets called in an event at the end of the animation clip that puts the gun back
        gun.transform.SetParent(back);
        gun.transform.localPosition = startPos;
        gun.transform.localRotation = startRot;
    }

}
