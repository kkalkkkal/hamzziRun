using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.IO;


struct stage {
    public string stage_num;
    public bool stage_star1;
    public bool stage_star2;
    public bool stage_star3;
    public string stage_title;
    public string stage_story;
    public string stage_reward;

    public stage(string stage_num, string stage_title, string stage_story, string stage_reward)
    {
        this.stage_star1 = false;
        this.stage_star2 = false;
        this.stage_star3 = false;

        this.stage_num = stage_num;
        this.stage_title = stage_title;
        this.stage_story = stage_story;
        this.stage_reward = stage_reward;
    }
};

public class StageManagement : MonoBehaviour
{
    public GameObject[] Player_icons;
    public GameObject Stageinfo;
    public TextMeshProUGUI stage_num;
    public TextMeshProUGUI stage_title;
    public TextMeshProUGUI stage_story;
    public TextMeshProUGUI stage_reward;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public TextMeshProUGUI last_stage; // 마지막 여정
    public TextMeshProUGUI clear_state; // 클리어 상태

    public TextMeshProUGUI seed_point;
    public TextMeshProUGUI stanina_point;
    public TextMeshProUGUI star_point;

    int select_num = 0;
    //int selected_num = 1;

    stage[] stages = new stage[6];

    public void init(){
        DataManager.Instance.GameClear = false;
        StreamReader sr = new StreamReader(Application.dataPath + "/Resources/CSV/" + "hamzzi_stage.csv");

        int num = 0;

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if(data_String == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split(',');
            for(int i = 1; i < data_values.Length; i++)
            {
                Debug.Log("v: " + i.ToString() + " " + data_values[i].ToString());
                
            }

        
            if (num > 0)
            {
                stages[num].stage_num = data_values[1].ToString();
                stages[num].stage_star1 = checkbool(data_values[2].ToString());
                stages[num].stage_star2 = checkbool(data_values[3].ToString());
                stages[num].stage_star3 = checkbool(data_values[4].ToString());
                stages[num].stage_title = data_values[5].ToString();
                stages[num].stage_story = data_values[6].ToString();
                stages[num].stage_reward = data_values[7].ToString();

                Debug.Log("stage_num : " + stages[num].stage_num + ", stage_star1 : " + stages[num].stage_star1 + ", stage_star2 : " + stages[num].stage_star2 + ", stage_star3 : " + stages[num].stage_star3 + ", stage_title : " + stages[num].stage_title + ", stage_story" + stages[num].stage_story + ", stage_reward" + stages[num].stage_reward);
            }
            num += 1;
            
        }
        
    }

    bool checkbool(string check){
        if (check == "FALSE")
        {
            return false;
        }else {
            return true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        select_num = 1;
        init(); // 초기화
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void stage1_click() {
        Sfx.SoundBtn();
        if (select_num != 1){
            Player_icons[select_num - 1].SetActive(false);
            select_num = 1;
            Player_icons[select_num - 1].SetActive(true);
        } else {
            // 진입 팝업창 뜨기
            popup_stageinfo();
        }
    }

    public void stage2_click() {
        Sfx.SoundBtn();
        if (select_num != 2){
            Player_icons[select_num - 1].SetActive(false);
            select_num = 2;
            Player_icons[select_num - 1].SetActive(true);
        } else {
            // 진입 팝업창 뜨기
            popup_stageinfo();
        }
    }

    public void stage3_click() {
        Sfx.SoundBtn();
        if (select_num != 3){
            Player_icons[select_num - 1].SetActive(false);
            select_num = 3;
            Player_icons[select_num - 1].SetActive(true);
        } else {
            // 진입 팝업창 뜨기
            popup_stageinfo();
        }
    }

    public void stage4_click() {
        Sfx.SoundBtn();
        if (select_num != 4){
            Player_icons[select_num - 1].SetActive(false);
            select_num = 4;
            Player_icons[select_num - 1].SetActive(true);
        } else {
            // 진입 팝업창 뜨기
            popup_stageinfo();
        }
    }

    public void stage5_click() {
        Sfx.SoundBtn();
        if (select_num != 5){
            Player_icons[select_num - 1].SetActive(false);
            select_num = 5;
            Player_icons[select_num - 1].SetActive(true);
        } else {
            // 진입 팝업창 뜨기
            popup_stageinfo();
        }
    }

    void popup_stageinfo() {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        // 선택한 스테이지에 따라 출력되는 문구를 다르게.

        stage_num.text = stages[select_num].stage_num; 
        if (stages[select_num].stage_star1)
        {
            star1.SetActive(true);
        }

        if (stages[select_num].stage_star2)
        {
            star2.SetActive(true);
        }

        if (stages[select_num].stage_star3)
        {
            star3.SetActive(true);
        }

        stage_title.text = stages[select_num].stage_title;
        stage_story.text = stages[select_num].stage_story;
        stage_reward.text = "x " + stages[select_num].stage_reward;

        //팝업창 출력
        Stageinfo.SetActive(true); 


    }

    // 달성 별 수 확인
    void star_check() {


    }

    public void back_btn1(){
        Sfx.SoundBtn();
        SceneManager.LoadScene("MainMenu");
    }

    public void back_btn2(){
        Sfx.SoundBtn();
        Stageinfo.SetActive(false); 
    }
    public void start_stage() { 
        Sfx.SoundBtn();
        DataManager.Instance.now_stage_num = select_num;
        SceneManager.LoadScene("SampleScene");

    }
}
