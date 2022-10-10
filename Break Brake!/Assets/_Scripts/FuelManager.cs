using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    public static FuelManager instance;

    RectTransform needleTrans;

    [SerializeField] Vector3 angle;

    float fuelValue = 105f;
    float maxFuel =140f;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) Destroy(gameObject);
    }

    void Start()
    {
        needleTrans = GameObject.Find("Needle").GetComponent<RectTransform>();
        //angle = needleTrans.localRotation.eulerAngles;
        //angle.z = fuelValue;
    }

    void Update()
    {
        fuelValue -= Time.deltaTime * 3f;
        needleTrans.localRotation = Quaternion.Euler(new Vector3(0, 0, -fuelValue));
    }

    public void AddFuel()
    {
        Debug.Log("연료 보충");
        fuelValue = Mathf.Clamp(fuelValue + 40, 0, maxFuel);
    }
}
