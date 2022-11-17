using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image img;
    bool isDie;

    void Start()
    {
        img = GetComponent<Image>();   
    }

    private void OnEnable()
    {
        isDie = true;
    }

    private void Update()
    {
        if (isDie)
            StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (true)
        {
            if (img.color.a < 1f)
            {
                img.color = new Color(0, 0, 0, img.color.a + Time.deltaTime * 0.2f);
                yield return null;
            }
            else
            {
                AsyncLoading.LoadScene("StartScene");
                yield break;
            }
        }
    }
}
