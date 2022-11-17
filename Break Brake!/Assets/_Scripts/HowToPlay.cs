using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HowToPlay : MonoBehaviour, IPointerDownHandler
{
    void Start()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        transform.parent.Find("Left").gameObject.SetActive(true);
        transform.parent.Find("Right").gameObject.SetActive(true);
        CarMovement.instance.gameState = GameState.gamePlaying;
    }
}
