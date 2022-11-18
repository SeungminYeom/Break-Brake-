using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
    Transform explosionThings;
    GameObject explosionThing;
    public RenderPipelineAsset blurAsset;

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

        StartCoroutine(ViewRanking());
    }

    public IEnumerator ViewRanking()
    {
        yield return new WaitForSeconds(5f);
        GraphicsSettings.renderPipelineAsset = blurAsset;
        GameObject canvas = GameObject.Find("Canvas");

        for (int i = 0; i < canvas.transform.childCount - 1; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(false);
        }

        canvas.transform.Find("Ranking").gameObject.SetActive(true);
    }
}