using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public enum GameState
{
    howPlay,
    gamePlaying,
    isGameOver,
    goToMenu
}

public class CarMovement : MonoBehaviour
{
    public static CarMovement instance;

    public GameObject explosion;

    Rigidbody carRigid;

    TextMeshProUGUI text;

    [SerializeField] float _driftPower = 0f;
    [SerializeField] float _maxDriftPower = 30f;
    [SerializeField] bool _carRot = false;
    [SerializeField] float carSpeed = 10;
    float _survivorTime = 0;

    bool _isGameOver;

    public GameState gameState = GameState.howPlay;

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

    public float survivorTime
    {
        get { return _survivorTime; }
        set { _survivorTime = value; }
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
        //text = GameObject.Find("Speed").GetComponent<TextMeshProUGUI>();
        //carRigid.AddForce(transform.forward * 10f, ForceMode.VelocityChange);
        carRigid.velocity = transform.forward * 10f;
    }

    void FixedUpdate()
    {
        //carRigid.AddForce(transform.forward);
        switch (gameState)
        {
            case GameState.howPlay:
                break;
            case GameState.gamePlaying:
                //carRigid.AddForce(transform.forward * carSpeed, ForceMode.Acceleration);
                if (carRigid.velocity.magnitude < 6f)
                    carRigid.velocity = transform.forward * 6f;

                carRigid.AddForce(transform.forward * carSpeed);
                Debug.Log(carSpeed);
                //carRigid.velocity = (transform.forward * carSpeed);
                //Debug.DrawRay(transform.position, transform.forward, Color.red);
                //carSpeed += Time.deltaTime * 0.01f;
                carSpeed += 0.005f;
                //text.text = carSpeed.ToString();
                survivorTime += Time.deltaTime;
                break;
            case GameState.isGameOver:
                maxDriftPower = Mathf.Lerp(maxDriftPower, 0, Time.deltaTime * 2f);
                Vector3 vec = carRigid.velocity;
                vec = Vector3.Lerp(vec, Vector3.zero, Time.deltaTime);
                carRigid.velocity = vec;
                if (carRigid.velocity == Vector3.zero)
                {
                    StartCoroutine(OpenRanking());
                    gameState = GameState.goToMenu;
                }
                break;
            case GameState.goToMenu:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            gameState = GameState.isGameOver;
            gameObject.SetActive(false);
            explosion.transform.position = transform.position;
            Vector3 angle = transform.eulerAngles;
            angle.x -= 10f;
            explosion.transform.rotation = Quaternion.Euler(angle);
            explosion.SetActive(true);
        }
    }

    IEnumerator OpenRanking()
    {
        //yield return new WaitForSeconds(5f);
        yield return null;
        StartCoroutine(explosion.GetComponent<Explosion>().ViewRanking());
    }
}
