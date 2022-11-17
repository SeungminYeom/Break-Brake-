using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    RectTransform needleTrans;

    [SerializeField] Vector3 angle;

    [SerializeField] float fuelValue = 105f;
    float maxFuel =140f;

    void Start()
    {
        needleTrans = GameObject.Find("Needle").GetComponent<RectTransform>();
        //angle = needleTrans.localRotation.eulerAngles;
        //angle.z = fuelValue;
    }

    void Update()
    {
        if (fuelValue >= 0)
        {
            if (CarMovement.instance.gameState == GameState.gamePlaying)
            {
                fuelValue -= Time.deltaTime * 3f;
                needleTrans.localRotation = Quaternion.Euler(new Vector3(0, 0, -fuelValue));
            }
        }
        else
        {
            CarMovement.instance.gameState = GameState.isGameOver;
            gameObject.SetActive(false);
        }
    }

    public void AddFuel()
    {
        Debug.Log("연료 보충");
        fuelValue = Mathf.Clamp(fuelValue + 40, 0, maxFuel);
    }
}
