using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] bool leftKey;
    GameObject car;

    static bool onTouch = false;

    void Start()
    {
        car = GameObject.Find("Player");
    }

    void Update()
    {
        if (!CarMovement.instance.isGameOver)
        {
            if (onTouch)
            {
                if (CarMovement.instance.carRot)
                {
                    CarMovement.instance.driftPower = Mathf.Lerp(CarMovement.instance.driftPower, -CarMovement.instance.maxDriftPower, Time.deltaTime);
                    Vector3 leftRot = car.transform.rotation.eulerAngles;
                    leftRot += new Vector3(0, CarMovement.instance.driftPower * Time.deltaTime, 0);
                    car.transform.rotation = Quaternion.Euler(leftRot);
                }
                else
                {
                    CarMovement.instance.driftPower = Mathf.Lerp(CarMovement.instance.driftPower, CarMovement.instance.maxDriftPower, Time.deltaTime);
                    Vector3 rightRot = car.transform.rotation.eulerAngles;
                    rightRot += new Vector3(0, CarMovement.instance.driftPower * Time.deltaTime, 0);
                    car.transform.rotation = Quaternion.Euler(rightRot);
                }
            }
            else
            {
                onTouch = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!onTouch) onTouch = true;
        CarMovement.instance.carRot = leftKey;
    }
}
