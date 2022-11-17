using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.parent.gameObject.SetActive(false);
        transform.parent.parent.Find("Fade_Up").gameObject.SetActive(true);
        Debug.Log("Áý °¡ÀÚ");
    }
}
