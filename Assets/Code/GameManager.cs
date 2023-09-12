using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


//UI를 추가
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // 맵 변수 
    public GameObject[] Maps;

    public GameObject[] NumberImage;
    public Sprite[] Number;

    //TImeBar 추가 
    public Image TimeBar;

    // BPFront : 누메릭 게이지 상태바 추가 (2023.08.03)
    public Image BPFront;

    // 스킬 이펙트 
    public GameObject hamzzi_skill_effect;

    //EndPanel GameObject 연동용 변수 추가
    public GameObject EndPanel;

    // PausePanel GameObject 연동용 변수 추가
    public GameObject PausePanel;

    // QuizPanel GameObject 패널 연동용 변수 추가   
    public GameObject QuizPanel;

    // 클리어 패널 연동용 변수 추가
    public GameObject ClearPanel;
    public Image first_star;
    public Image second_star;
    public Image third_star;

    public Sprite star_0;
    public Sprite star_1;
    public Sprite star_2;

    float numericGaugeMess = 15f;
    float HPGaugeMess = 20f;


    // 처음 1번만 실행
    private void Awake() {

        for (int i  = 0 ; i < 5 ; i++)
        {
            Maps[i].SetActive(false);
        }

        Maps[DataManager.Instance.now_stage_num].SetActive(true);

        // 각 스테이지 별로 스크립트 출력
        if (DataManager.Instance.now_stage_num == 0) { // 튜토리얼
            //Time.timeScale = 0; // 일시정지 하고 퀘스트 진행 : 시간을 정지시키면 타이핑 효과를 못쓰므로 다른 방식으로 해결
            DataManager.Instance.QuestAction = 1;
        } else {
            DataManager.Instance.QuestAction = 0;
        }

    }


    private void Update()
    {
        // 퀘스트 동작중 화면 정지
        if (DataManager.Instance.QuestAction == 1){
            DataManager.Instance.mapSpeed = 0f;
            numericGaugeMess = 0f;
            HPGaugeMess = 0f;
        } else {
            DataManager.Instance.mapSpeed = 8f;
            numericGaugeMess = 20f;
            HPGaugeMess = 20f;
        }


        //점수 띄우기
        //100의 단위
        int temp = DataManager.Instance.score / 100;
        NumberImage[0].GetComponent<Image>().sprite = Number[temp];
        //10의 단위. 0~99까지 계산
        int temp2 = DataManager.Instance.score % 100;
        //그걸 다시 0~9까지
        temp2 = temp2 / 10;
        NumberImage[1].GetComponent<Image>().sprite = Number[temp2];
        //1의 단위
        int temp3 = DataManager.Instance.score % 10;
        NumberImage[2].GetComponent<Image>().sprite = Number[temp3];

        if (!DataManager.Instance.PlayerDie)
        {
            // HP 게이지
            DataManager.Instance.playTimeCurrent -= HPGaugeMess * Time.deltaTime; //1초에 1%씩만 빼.

            // 누메릭 게이지 
            DataManager.Instance.numericPoint += numericGaugeMess * Time.deltaTime; // 초당 20%만 증가 (To do : 10을 1로 바꿀 것)
            BPFront.fillAmount = DataManager.Instance.numericPoint / DataManager.Instance.numericPointMax;

            // 게이지가 가득 채워지면 스킬 발동
            if(BPFront.fillAmount >= 1)
            {
                Activate_Skill();
                
                Invoke("UnActivate_Skill", 5); // Invoke는 n초 후 특정 함수를 발동시키는 함수
            }


            //TImeBar 추가
            //1 ~ 0까지의 범위에서 값이 결정 됨. 다 채워져 있는 상태가 1
            TimeBar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;

            //시간이 다 되면 죽음
            if (DataManager.Instance.playTimeCurrent < 0)
            {
                DataManager.Instance.PlayerDie = true;
                Time.timeScale = 0;
                //배경 끄기
            }

        }

        //만약 플레이어가 죽었다면 EndPanel 켜기
        if (DataManager.Instance.PlayerDie == true)
        {
            EndPanel.SetActive(true);
        }

        // 퀴즈 트리거가 작동되면 QuizPanel 켜기
        if (DataManager.Instance.QuizOnOff == true)
        {
            QuizPanel.SetActive(true);
            
        } else {
            
            //QuizPanel.SetActive(false);
        }

        // 게임 클리어 되면 ClearPanel 켜기
        if (DataManager.Instance.GameClear == true) {
            Activate_Clear();
            QuizPanel.SetActive(false);            
        }
    }


    public void Restart_Btn()
    {
        Sfx.SoundBtn();

        Time.timeScale = 1;
        DataManager.Instance.score = 0;
        DataManager.Instance.PlayerDie = false;
        DataManager.Instance.playTimeCurrent = DataManager.Instance.playTimeMax;
        //DataManager.Instance.margnetTimeCurrent = 0;

        DataManager.Instance.numericPoint = 0f;
        QuizPanel.SetActive(false);
        DataManager.Instance.QuizOnOff = false;

        SceneManager.LoadScene("SampleScene");
    }


    public void Pause_Btn()
    {
        //일시정지 버튼을 누르면 
        if (DataManager.Instance.PlayerDie == false)
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }
        Sfx.SoundBtn();
    }

    public void QuitBtn(){
        Time.timeScale = 1;
        Sfx.SoundBtn();
        SceneManager.LoadScene("AdventureStage");
    }

    // 스킬 발동 함수 
    public void Activate_Skill()
    {
        hamzzi_skill_effect.SetActive(true);
        DataManager.Instance.skillOnOff = true;

        // To do : 캐릭터 별 스킬을 발동할 수 있도록 swich문 작성
    }

    // 스킬 비활성 함수
    public void UnActivate_Skill()
    {
        DataManager.Instance.skillOnOff = false;
        hamzzi_skill_effect.SetActive(false);
        DataManager.Instance.numericPoint = 0f;
    }
    

    // 클리어 패널
    public void Activate_Clear()
    {
        // To do : 클리어 창 띄우기 
        ClearPanel.SetActive(true);
        Sfx.SoundClear();
        first_star.sprite = star_0;
        second_star.sprite = star_1;
        third_star.sprite = star_2;
        if (PlayerPrefs.GetInt("LastStage") < DataManager.Instance.now_stage_num) {
            PlayerPrefs.SetInt("LastStage", DataManager.Instance.now_stage_num);
        }
        DataManager.Instance.score = 0;
        DataManager.Instance.QuestNum++;
        //Debug.Log("userQuestnum : " + userquestnum);

    }

    public void go_adventure()
    {
        Sfx.SoundBtn();

        Time.timeScale = 1;

        if (DataManager.Instance.tutorial == 1)
        {
            DataManager.Instance.QuestNum = 6;
            DataManager.Instance.tutorial = 0;
            SceneManager.LoadScene("MainMenu");
        } else if (DataManager.Instance.now_stage_num == 5 && DataManager.Instance.QuestNum == 501) {
            
            SceneManager.LoadScene("MainMenu");
        } else {
            SceneManager.LoadScene("AdventureStage");
        }
        
        
    }


}
