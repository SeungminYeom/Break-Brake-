using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CinemaFlow
{
    cameraMoving_1,
    cameraMoving_2
}

public class GameCinema : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] GameObject camera_1;

    [SerializeField] CinemaFlow flow;

    Rigidbody carRigid;

    void Start()
    {
        car = GameObject.Find("car_1");
        carRigid = car.GetComponent<Rigidbody>();
        camera_1 = GameObject.Find("CinemaCamera_1");
        flow = CinemaFlow.cameraMoving_1;
    }

    void Update()
    {
        switch(flow)
        {
            case CinemaFlow.cameraMoving_1:
                camera_1.transform.rotation = Quaternion.Euler(new Vector3(camera_1.transform.eulerAngles.x - Time.deltaTime * 5,
                                                                            camera_1.transform.eulerAngles.y - Time.deltaTime * 12, 0));
                car.transform.position = car.transform.position + car.transform.right * Time.deltaTime * 20f;
                if (camera_1.transform.eulerAngles.y < 114f)
                {
                    flow = CinemaFlow.cameraMoving_2;
                }
                break;
            case CinemaFlow.cameraMoving_2:
                break;
        }
    }
}