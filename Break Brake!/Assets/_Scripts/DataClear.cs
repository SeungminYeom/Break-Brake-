using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DataClear : MonoBehaviour, IPointerDownHandler
{
    int clearN = 10;

    public void OnPointerDown(PointerEventData eventData)
    {
        clearN--;

        if (clearN <= 0)
        {
            PlayerPrefs.DeleteAll();
            AsyncLoading.LoadScene("StartScene");
        }
    }
}
