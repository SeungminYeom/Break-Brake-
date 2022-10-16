using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Transform explosionThings;
    GameObject explosionThing;

    private void OnEnable()
    {
        explosionThings = transform.Find("ExplosionThings");
        for (int i = 0; i < explosionThings.childCount - 1; i++)
        {
            explosionThing = explosionThings.GetChild(i).gameObject;
            explosionThing.GetComponent<Rigidbody>().AddForce((explosionThing.transform.position - transform.position).normalized * 20f, ForceMode.Impulse);
        }
        explosionThing = explosionThings.Find("Car").gameObject;
        explosionThing.SetActive(true);

        explosionThings = transform.Find("ExplosionFX");
        for (int i = 0; i < explosionThings.childCount - 1; i++)
        {
            explosionThing = explosionThings.GetChild(i).gameObject;
            explosionThing.GetComponent<ParticleSystem>().Play();
        }
    }
}
