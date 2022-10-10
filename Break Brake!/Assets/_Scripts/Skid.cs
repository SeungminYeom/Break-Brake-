using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skid : MonoBehaviour
{
    Transform skidPool;

    Vector3 prePos = Vector3.zero;

    Quaternion skidRot;
    Vector3 deltaPos;

    private void Start()
    {
        skidPool = GameObject.Find("SkidPool").transform;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(CarMovement.instance.driftPower) > 20f)
        {
            deltaPos = (transform.position - prePos).normalized;
            skidRot = Quaternion.Euler(0, Mathf.Atan2(deltaPos.x, deltaPos.z) * Mathf.Rad2Deg + 90, 0);
            skidPool.GetChild(SkidManager.skidValue).gameObject.SetActive(true);
            skidPool.GetChild(SkidManager.skidValue).position = transform.position;
            skidPool.GetChild(SkidManager.skidValue).rotation = skidRot;
            SkidManager.skidValue++;
            SkidManager.skidValue %= SkidManager.skidAmount;
        }
        prePos = transform.position;
    }
}