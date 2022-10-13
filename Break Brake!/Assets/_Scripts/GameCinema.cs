using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CinemaFlow
{
    cameraMoving_1,
    cameraMoving_2,
    cameraMoving_3,
    cameraMoving_4
}

public class GameCinema : MonoBehaviour
{
    [SerializeField] GameObject car_1;
    [SerializeField] GameObject car_2;
    [SerializeField] GameObject camera_1;

    [SerializeField] CinemaFlow flow;

    Rigidbody carRigid;

    Vector3 destination = new Vector3(-1.712f, 20.447f, -243.04f);
    //float speedToDest;

    void Start()
    {
        car_1 = GameObject.Find("Car_1");
        car_2 = GameObject.Find("Car_2");
        carRigid = car_1.GetComponent<Rigidbody>();
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
                car_1.transform.position = car_1.transform.position + car_1.transform.right * Time.deltaTime * 20f;
                if (camera_1.transform.eulerAngles.y < 114f)
                {
                    Vector3 pos = car_1.transform.position;
                    pos.x = -240f;
                    car_1.transform.position = pos;
                    flow = CinemaFlow.cameraMoving_2;
                }
                break;
            case CinemaFlow.cameraMoving_2:
                camera_1.transform.parent = car_1.transform;
                camera_1.transform.localPosition = new Vector3(-6.2f, -0.66f, -2.47f);
                camera_1.transform.localRotation = Quaternion.Euler(new Vector3(-4.98f, 84.98f, -89.56f));
                //carRigid.velocity += Vector3.right * 80f * Time.deltaTime;
                car_1.transform.position = car_1.transform.position + car_1.transform.right * Time.deltaTime * 40f;
                car_2.transform.position = car_2.transform.position + -car_2.transform.right * Time.deltaTime * 60f;

                if (car_1.transform.position.x >= -60f)
                {
                    camera_1.transform.parent = null;
                    flow = CinemaFlow.cameraMoving_3;
                }
                break;
            case CinemaFlow.cameraMoving_3:
                car_2.transform.position = car_2.transform.position + -car_2.transform.right * Time.deltaTime * 60f;
                car_1.transform.rotation = Quaternion.Euler(car_1.transform.eulerAngles.x,
                                                            car_1.transform.eulerAngles.y - Time.deltaTime * 40f,
                                                            car_1.transform.eulerAngles.z);
                car_1.transform.position = car_1.transform.position + car_1.transform.right * Time.deltaTime * 40f;
                if (car_1.transform.position.z > -265f)
                {
                    flow = CinemaFlow.cameraMoving_4;
                    camera_1.transform.position = new Vector3(-23.4f, 4.1f, -227.2f);
                    camera_1.transform.rotation = Quaternion.Euler(-30f, 130f, 0.003f);
                    //speedToDest = Time.deltaTime * 40f;
                }
                break;
            case CinemaFlow.cameraMoving_4:
                //car_1.transform.position = car_1.transform.position + car_1.transform.right * Time.deltaTime * 40f;
                car_1.transform.position = Vector3.Lerp(car_1.transform.position, destination, Time.deltaTime * 0.8f);
                //car_1.transform.position = car_1.transform.position + car_1.transform.right * speedToDest;
                //speedToDest *= 0.998f;
                break;
        }
    }
}