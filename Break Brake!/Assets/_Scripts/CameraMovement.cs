using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraMovement : MonoBehaviour
{
    GameObject target;
    Vector3 originPos;

    void Start()
    {
        //GetComponent<UniversalAdditionalCameraData>().renderPostProcessing = false;
        DepthOfField dOF;
        GameObject.Find("Global Volume").GetComponent<Volume>().profile.TryGet<DepthOfField>(out dOF);
        dOF.active = false;
        target = GameObject.Find("Player");
        originPos = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = originPos + target.transform.position;
    }
}
