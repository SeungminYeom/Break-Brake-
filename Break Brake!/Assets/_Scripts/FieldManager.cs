using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    GameObject ground;
    //오브젝트 갯수
    [SerializeField] int plantAmount;
    [SerializeField] int rockAmount;
    [SerializeField] GameObject[] objects_Plant;
    [SerializeField] GameObject[] objects_Rock;
    [SerializeField] GameObject[] field;
    [SerializeField] GameObject fuel;


    void Start()
    {
        ground = GameObject.Find("Ground");
        field = new GameObject[plantAmount + rockAmount];
        SpawnObject();
        StartCoroutine(SpawnFuel());
    }

    void Update()
    {
        
    }

    void SpawnObject()
    {
        int i = 0;

        for (; i < plantAmount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-ground.transform.localScale.x * 5, ground.transform.localScale.x * 5), 0,
                                        Random.Range(-ground.transform.localScale.z * 5, ground.transform.localScale.z * 5));
            field[i] = Instantiate(objects_Plant[Random.Range(0, objects_Plant.Length)],
                                    transform.position + pos,
                                    Quaternion.Euler(0, Random.Range(0, 360), 0));
            field[i].transform.parent = transform;
        }

        for (; i < field.Length; i++)
        {
            Vector3 pos;
            while (true)
            {
                pos = new Vector3(Random.Range(-ground.transform.localScale.x * 4.5f, ground.transform.localScale.x * 4.5f), 0,
                                            Random.Range(-ground.transform.localScale.z * 4.5f, ground.transform.localScale.z * 4.5f));

                if (Mathf.Abs(pos.x) > 50f && Mathf.Abs(pos.z) > 50f) break;
            }

            field[i] = Instantiate(objects_Rock[Random.Range(0, objects_Rock.Length)],
                                    transform.position + pos,
                                    Quaternion.Euler(0, Random.Range(0, 360), 0));
            field[i].transform.parent = transform;
        }
    }

    IEnumerator SpawnFuel()
    {
        yield return new WaitForSeconds(1f);
        Vector3 pos = new Vector3(Random.Range(-ground.transform.localScale.x * 4.5f, ground.transform.localScale.x * 4.5f), 0,
                                    Random.Range(-ground.transform.localScale.z * 4.5f, ground.transform.localScale.z * 4.5f));
        Instantiate(fuel, pos, Quaternion.identity);
        StartCoroutine(SpawnFuel());
    }
}
