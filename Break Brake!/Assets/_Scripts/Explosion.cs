using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    GameObject explo;

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            explo = transform.GetChild(i).gameObject;
            explo.GetComponent<Rigidbody>().AddForce((explo.transform.position - transform.position).normalized * 20f, ForceMode.Impulse);
        }
        explo = transform.GetChild(transform.childCount - 1).gameObject;
        explo.SetActive(true);
    }
}
