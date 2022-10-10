using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidManager : MonoBehaviour
{
    [SerializeField] GameObject skidMark;
    //스키드 마크를 몇개 만들지 결정
    [SerializeField] public static int skidAmount = 200;
    //자식인 스키드 마크를 세는 변수
    [SerializeField] public static int skidValue = 0;


    void Start()
    {
        for (int i = 0; i < skidAmount; i++)
        {
            GameObject gameObject = Instantiate(skidMark);
            gameObject.transform.parent = transform;
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
