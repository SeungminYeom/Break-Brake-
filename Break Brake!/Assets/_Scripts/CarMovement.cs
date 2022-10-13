using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarMovement : MonoBehaviour
{
    public static CarMovement instance;

    public GameObject explosion;

    Rigidbody carRigid;

    TextMeshProUGUI text;

    [SerializeField] float _driftPower = 0f;
    [SerializeField] float _maxDriftPower = 30f;
    [SerializeField] bool _carRot = false;
    [SerializeField] float carSpeed = 5;

    bool _isGameOver;

    public float driftPower
    {
        get { return _driftPower; }
        set { _driftPower = value; }
    }  

    public float maxDriftPower
    {
        get { return _maxDriftPower; }
        set { _maxDriftPower = value; }
    }    
    
    public bool carRot
    {
        get { return _carRot; }
        set { _carRot = value; }
    }

    public bool isGameOver
    {
        get { return _isGameOver; }
        set { _isGameOver = value; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        carRigid = GetComponent<Rigidbody>();
        text = GameObject.Find("Speed").GetComponent<TextMeshProUGUI>();
        carRigid.AddForce(transform.forward * 10f, ForceMode.VelocityChange);
    }

    void Update()
    {
        if (!isGameOver)
        {
            carRigid.AddForce(transform.forward * carSpeed, ForceMode.Acceleration);
            carSpeed += Time.deltaTime * 0.01f;
            text.text = carSpeed.ToString();
        }
        else
        {
            maxDriftPower = Mathf.Lerp(maxDriftPower, 0, Time.deltaTime * 2f);
            Vector3 vec = carRigid.velocity;
            vec = Vector3.Lerp(vec, Vector3.zero, Time.deltaTime);
            carRigid.velocity = vec;
        }
    }

    public void AddSpeed()
    {
        carSpeed += 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            gameObject.SetActive(false);
            explosion.transform.position = transform.position;
            Vector3 angle = transform.eulerAngles;
            angle.x -= 10f;
            explosion.transform.rotation = Quaternion.Euler(angle);
            explosion.SetActive(true);
        }
    }
}
