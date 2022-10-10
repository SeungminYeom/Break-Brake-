using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidManager : MonoBehaviour
{
    [SerializeField] GameObject skidMark;
    //��Ű�� ��ũ�� � ������ ����
    [SerializeField] public static int skidAmount = 200;
    //�ڽ��� ��Ű�� ��ũ�� ���� ����
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
