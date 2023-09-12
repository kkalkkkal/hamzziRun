using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    //DataManager에 아래의 변수 하나 추가
    public bool PlayerDie = false; //사망 판단
    public bool GameClear = false;// 클리어 판단 (2023.08.03)
    public bool skillOnOff = false; // 스킬 작동 여부
    public bool QuizOnOff = false; // 퀴즈 패널 출현 여부 

    //게임 플레이 타임
    public float playTimeCurrent = 8000f;
    public float playTimeMax = 10000f;

    // 누메릭 게이지 
    public float numericPoint = 0f;
    public float numericPointMax = 1000f;

    // 선택한 스테이지
    public int now_stage_num = 0;
    public int laststage = -1;

    //새로운 변수 접근 방식 
    static DataManager instance;

    // 맵 속도
    public float mapSpeed = 8f;

    //퀘스트 여부
    public int tutorial = 0;
    public int QuestNum = 0;
    public int QuestAction = 0;
    public int Guide = 0;

    // 퀴즈 정답
    public int answer = 3;

    // 두뇌훈련 
    public int Correct_count = 0;
    public int solve_count = 0;

    public static DataManager Instance
    {
        get
        {
            return instance;
            
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            DestroyObject(gameObject); // gameObject.Destory();
        }

    }

    
    
    //실제 스코어 저장할 곳
    public int score = 0;
}
