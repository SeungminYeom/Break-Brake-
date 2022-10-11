using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skid : MonoBehaviour
{
    TrailRenderer trail;

    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (Mathf.Abs(CarMovement.instance.driftPower) > 30)
            trail.emitting = true;
        else 
            trail.emitting = false;
    }
}