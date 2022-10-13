using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartScene : MonoBehaviour
{
    TextMeshProUGUI gameStartText;
    Rigidbody carRigid;
    bool accel;
    Animator player;
    GameObject startText;

    void Start()
    {
        gameStartText = GetComponent<TextMeshProUGUI>();
        carRigid = GetComponent<Rigidbody>();
        player = GetComponent<Animator>();
        startText = GameObject.Find("GameStart");
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            player.SetBool("isStart", true);
            startText.GetComponent<Animator>().SetBool("isStart", true);
            startText.SetActive(false);

        }
    }

    //void FixedUpdate()
    //{
    //    if (accel) carRigid.AddForce(transform.forward * 50, ForceMode.Acceleration);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Collider")
            SceneManager.LoadScene("IntroScene");
    }
}
