using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject target;
    Vector3 originPos;

    void Start()
    {
        target = GameObject.Find("Player");
        originPos = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = originPos + target.transform.position;
    }
}
