using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ranking : MonoBehaviour
{
    [SerializeField] List<string> rank_Sort_Arr = new List<string>();
    [SerializeField] TextMeshProUGUI[] rank_Arr = new TextMeshProUGUI[5];
    [SerializeField] TextMeshProUGUI myRank;
    string name;

    private void Awake()
    {
        //if (PlayerPrefs.HasKey("rankCount"))=

        //string st = PlayerPrefs.GetString("Rank_1", "empty");
        //Debug.Log(st);
        //Debug.Log("어웨이크");
        for (int i = 0; i < 5; i++)
        {
            rank_Arr[i] = transform.Find("RankingBox").GetChild(i).GetComponent<TextMeshProUGUI>();

            if (PlayerPrefs.HasKey($"Rank_{i + 1}"))
            {
                rank_Sort_Arr.Add(PlayerPrefs.GetString($"Rank_{i + 1}"));
            }
        }
        myRank = transform.Find("RankingBox").Find("MyRank").GetComponent<TextMeshProUGUI>();

        //gameObject.SetActive(false);
    }

    void Update()
    {
    }

    private void OnEnable()
    {
        string t = System.TimeSpan.FromSeconds(CarMovement.instance.survivorTime).ToString("mm\\:ss\\:ff");
        string[] token = t.Split(':');

        string newRankTime = token[0] + token[1] + token[2];
        
        Sort(newRankTime);

        for (int i = 0; i < Mathf.Clamp(rank_Sort_Arr.Count, 0, 5); i++)
        {
            rank_Arr[i].text = $"{i + 1}. {rank_Sort_Arr[i].Substring(0, 2)}:{rank_Sort_Arr[i].Substring(2, 2)}:{rank_Sort_Arr[i].Substring(4, 2)}";
        }

        myRank.text = "My : " + t;

        Save();
    }

    void Sort(string newT)
    {
        for (int i = rank_Sort_Arr.Count - 1; i >= 0; i--)
        {
            //newT가 현재 랭크보다 기록이 좋으면
            if (int.Parse(rank_Sort_Arr[i]) < int.Parse(newT))
                //상위 랭크랑 비교
                continue;
            //newT가 현재 랭크보다 기록이 낮으면
            else
            {
                //현재 랭크의 다음 자리에 기록 추가
                rank_Sort_Arr.Insert(i + 1, newT);
                return;
            }
        }
        //newT가 모든 랭크보다 기록이 좋으면 첫번째 자리에 newT 추가
        rank_Sort_Arr.Insert(0, newT);
    }

    void Save()
    {
        for (int i = 0; i < 5; i++)
        {
            if (rank_Sort_Arr.Count == i) break;

            if (PlayerPrefs.HasKey($"Rank_{i + 1}"))
            {
                PlayerPrefs.DeleteKey($"Rank_{i + 1}");
                //PlayerPrefs.SetString(rank_Sort_Arr[i], $"Rank_{i + 1}");
                PlayerPrefs.SetString($"Rank_{i + 1}", rank_Sort_Arr[i]);
                PlayerPrefs.Save();
            }
            else
            {
                //PlayerPrefs.SetString(rank_Sort_Arr[i], $"Rank_{i + 1}");
                PlayerPrefs.SetString($"Rank_{i + 1}", rank_Sort_Arr[i]);
                PlayerPrefs.Save();
            }
        }
        //PlayerPrefs.Save();
    }
}
