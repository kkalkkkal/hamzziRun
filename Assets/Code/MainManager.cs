using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObject DailyCheck;
    public GameObject DailyQuest;
    public GameObject WeeklyQuest;
    public GameObject Rank;
    public GameObject Back;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DailyCheckBtn() {
        DailyCheck.SetActive(true);
        Back.SetActive(true);
    }

    public void DailyQuestBtn() {
        DailyQuest.SetActive(true);
        WeeklyQuest.SetActive(false);
        Back.SetActive(true);
    }

    public void WeeklyQuestBtn() {
        WeeklyQuest.SetActive(true);
        DailyQuest.SetActive(false);
        Back.SetActive(true);
    }

    public void RankBtn() {
        Rank.SetActive(true);
        Back.SetActive(true);
    }

    public void BackBtn() {
        DailyCheck.SetActive(false);
        DailyQuest.SetActive(false);
        WeeklyQuest.SetActive(false);
        Rank.SetActive(false);
        Back.SetActive(false);
    }
}
