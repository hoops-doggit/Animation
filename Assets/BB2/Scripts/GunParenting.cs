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

    private void Start()
    {
        back = gun.transform.parent;
        startPos = gun.transform.localPosition;
        startRot = gun.transform.localRotation;
    }

    public void ParentGun()
    {
        gun.transform.SetParent(gunHand);
        Debug.Log("parented gun");
    }

    public void UnparentGun()
    {
        gun.transform.SetParent(back);
        gun.transform.localPosition = startPos;
        gun.transform.localRotation = startRot;
    }

}
