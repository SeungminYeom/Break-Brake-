using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    float rotY;

    void Start()
    {
        StartCoroutine(DestroyThis());
    }

    void Update()
    {
        rotY += Time.deltaTime * 10f;
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FuelManager.instance.AddFuel();
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}
