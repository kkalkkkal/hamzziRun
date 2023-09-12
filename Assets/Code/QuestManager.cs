using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;

public class QuestManager : MonoBehaviour
{

    // 출력 UI 
    public GameObject talkPanel;
    public TextMeshProUGUI chr_name; 
    public TextMeshProUGUI chr_script; // talkText
    public TextAni TA;
    public Image chr_img_left;

    public GameObject Black_Bakcground;
    public GameObject next_script_btn;
    //public Image chr_img_right;
    //public Image change_img;

    // 이미지 리스트
    Dictionary<int, Sprite> img_data;
    public Sprite[] img_arr;


    // 퀘스트 정보 
    public int questId;
    Dictionary<int, QuestData> questList;
    public int questTalkIndex = 0;

    // 튜토리얼때 잠깐 보이는 UI들
    public GameObject tutorial_Timebar;
    public GameObject tutorial_Seeds;
    public GameObject tutorial_Seeds_point;
    public GameObject tutorial_Numeric;
    public GameObject tutorial_travel_btn;
    public GameObject tutorial_training_btn;


    void Awake() {
        
        questList = new Dictionary<int, QuestData>();
        img_data = new Dictionary<int, Sprite>();
        GenerateData();

        if (DataManager.Instance.tutorial == 1)
        {
            Black_Bakcground.SetActive(true);
            talkPanel.SetActive(true);
            next_script_btn.SetActive(true);
            DataManager.Instance.QuestNum = 0;
            StartTalk(0);
        } else if (DataManager.Instance.QuestNum == 7)
        {
            Black_Bakcground.SetActive(true);
            talkPanel.SetActive(true);
            next_script_btn.SetActive(true);
            StartTalk(6);
            DataManager.Instance.QuestNum = 100;
            

        } else if (DataManager.Instance.QuestNum == 501){
            Black_Bakcground.SetActive(true);
            talkPanel.SetActive(true);
            next_script_btn.SetActive(true);
            StartTalk(501);

        } else {
            DataManager.Instance.laststage = 0;//PlayerPrefs.GetInt("LastStage");

            if (DataManager.Instance.laststage < 1 && DataManager.Instance.now_stage_num == 1)
            {
                Black_Bakcground.SetActive(true);
                talkPanel.SetActive(true);
                next_script_btn.SetActive(true);
                DataManager.Instance.QuestNum = 100;
                StartTalk(100);
            } else if (DataManager.Instance.laststage < 2 && DataManager.Instance.now_stage_num == 2)
            {
                Black_Bakcground.SetActive(true);
                talkPanel.SetActive(true);
                next_script_btn.SetActive(true);
                DataManager.Instance.QuestNum = 200;
                StartTalk(200);
            } else if (DataManager.Instance.laststage < 3 && DataManager.Instance.now_stage_num == 3)
            {
                Black_Bakcground.SetActive(true);
                talkPanel.SetActive(true);
                next_script_btn.SetActive(true);
                DataManager.Instance.QuestNum = 300;
                StartTalk(300);
            } else if (DataManager.Instance.laststage < 4 && DataManager.Instance.now_stage_num == 4)
            {
                Black_Bakcground.SetActive(true);
                talkPanel.SetActive(true);
                next_script_btn.SetActive(true);
                DataManager.Instance.QuestNum = 400;
                StartTalk(400);
            } else if (DataManager.Instance.laststage < 5 && DataManager.Instance.now_stage_num == 5)
            {
                Black_Bakcground.SetActive(true);
                talkPanel.SetActive(true);
                next_script_btn.SetActive(true);
                DataManager.Instance.QuestNum = 500;
                StartTalk(500);
            }
        }
    }

    private void Update(){
        if (DataManager.Instance.QuestAction == 1 && DataManager.Instance.Guide == 1)
        {
            DataManager.Instance.Guide = 0;
            Black_Bakcground.SetActive(true);
            talkPanel.SetActive(true);
            next_script_btn.SetActive(true);
            StartTalk(DataManager.Instance.QuestNum);
        }

    }

    public TalkManager talkManager; 
    public int talkIndex = 0; 

    // 타이핑 완료 여부 
    public static bool isTypingEnd = false;

    

    // todo : 지금까지 진행한 퀘스트 번호를 플레이어 정보에 저장할 필요성이 있음. 

    void GenerateData()
    {
        questList.Add(0, new QuestData("긴급 소집", new int[] {1000,2000})); // 튜토리얼
        questList.Add(100, new QuestData("모험단 준비", new int[] {1000,4000})); // 튜토리얼 끝난 직후
        questList.Add(200, new QuestData("체력 단련", new int[] {1000,2000,3000,4000})); // 스테이지 1 퀘스트
        questList.Add(300, new QuestData("민첩성 훈련", new int[] {1000,4000}));
        questList.Add(400, new QuestData("지능도 중요해", new int[] {1000,4000}));
        questList.Add(500, new QuestData("종합 훈련", new int[] {1000,2000,4000}));

        img_data.Add(1000 + 0, img_arr[0]); // 햄찌 기본
        img_data.Add(1000 + 1, img_arr[1]); // 햄찌 눈 감음
        img_data.Add(1000 + 2, img_arr[2]); // 햄찌 분노
        img_data.Add(1000 + 3, img_arr[3]); // 햄찌 실망
        img_data.Add(1000 + 4, img_arr[4]); // 햄찌 식은땀 = 한숨
        img_data.Add(1000 + 5, img_arr[5]); // 햄찌 사랑
        img_data.Add(1000 + 6, img_arr[6]); // 햄찌 뾰루퉁
        img_data.Add(2000 + 0, img_arr[7]); // 햄똘이 버럭
        img_data.Add(2000 + 1, img_arr[8]); // 햄똘이 스탠딩
        img_data.Add(2000 + 2, img_arr[9]); // 햄똘이 슬픔
        img_data.Add(2000 + 3, img_arr[10]); // 햄똘이 어질어질
        img_data.Add(2000 + 4, img_arr[11]); // 햄똘이 초롱
        img_data.Add(3000 + 0, img_arr[12]); // 촌장 스탠딩
        img_data.Add(3000 + 1, img_arr[13]); // 촌장 웃음
        img_data.Add(3000 + 2, img_arr[14]); // 촌장 빠직
        img_data.Add(3000 + 3, img_arr[15]); // 촌장 슬픔
        img_data.Add(4000 + 0, img_arr[16]); // 대장 스탠딩
        img_data.Add(4000 + 1, img_arr[17]); // 대장 생각
        img_data.Add(4000 + 2, img_arr[18]); // 대장 화남
        img_data.Add(4000 + 3, img_arr[19]); // 대장 당황
        img_data.Add(4000 + 4, img_arr[20]); // 대장 고민/슬픔
        
    }

    public Sprite Getimg_data(int img_index) {
        return img_arr[img_index];
    }

    // 퀘스트 시작
    public void StartTalk(int questid)
    {
        //~~int questTalkIndex = GetQuestTalkIndex(questid);~~
        questId = questid;
        string talkData = talkManager.GetTalk(questId + questTalkIndex, talkIndex);
        DataManager.Instance.QuestAction = 1;

        // End Talk
        if (talkData == null) {
            Black_Bakcground.SetActive(false);
            talkPanel.SetActive(false);
            next_script_btn.SetActive(false);
            talkIndex = 0;
            //Debug.Log(checkQuest());
            DataManager.Instance.QuestAction = 0;
            return;
        }

        chr_name.text = talkData.Split(':')[0];
        //chr_script.text = talkData.Split(':')[1]; 
        // npc script
        TA.SetMsg(talkData.Split(':')[1].ToString());   //chr_script.text  = ""

        if (talkData.Split(':')[2].Length == 0)
        {
            chr_img_left.color = new Color(1,1,1,0);
        } else {
            chr_img_left.sprite = Getimg_data(int.Parse(talkData.Split(':')[2]));
            chr_img_left.color = new Color(1,1,1,1);
        }

        talkIndex++;
    
    }

    // 화면 터치하면 다음 스크립트 출력
    public void next_script() { // 퀘스트 아이디와 스크립트 순서를 인자로 받음.
        Sfx.SoundBtn();
        if(!isTypingEnd){
            
            TextAni.interval = 0.03f;
            return;
        }

        string talkData = talkManager.GetTalk(questId + questTalkIndex, talkIndex);

        //// tutorial active

        if (questId + questTalkIndex == 1 && talkIndex == 2)
        {
            Black_Bakcground.SetActive(true);
            tutorial_Timebar.SetActive(true);
        } else {
            tutorial_Timebar.SetActive(false);
        }

        if (questId + questTalkIndex == 2 && talkIndex == 1){
            Black_Bakcground.SetActive(true);
            tutorial_Seeds.SetActive(true);
            tutorial_Seeds_point.SetActive(true);
        } else {
            tutorial_Seeds.SetActive(false);
            tutorial_Seeds_point.SetActive(false);
        }

        if (questId + questTalkIndex == 4 && talkIndex == 2){
            Black_Bakcground.SetActive(true);
            tutorial_Numeric.SetActive(true);
        } else {
            tutorial_Numeric.SetActive(false);
        } 

        ////

        // End Talk
        if (talkData == null) {
            Black_Bakcground.SetActive(false);
            talkPanel.SetActive(false);
            next_script_btn.SetActive(false);
            talkIndex = 0;
            questTalkIndex++;
            //Debug.Log(checkQuest());
            DataManager.Instance.QuestAction = 0;
            if (questId + questTalkIndex >= 1 && questId + questTalkIndex <= 3)
            {
                talkPanel.SetActive(true);
                next_script_btn.SetActive(true);
                StartTalk(0);
            } 

            if (questId + questTalkIndex == 7 && DataManager.Instance.QuestNum == 100)
            {
                tutorial_travel_btn.SetActive(true);
                Debug.Log("튜토리얼 버튼 작동");
            }

            if (questId + questTalkIndex == 501 && DataManager.Instance.QuestNum == 500){
                PlayerPrefs.SetInt("LastQuest", 501);
            } else if (questId + questTalkIndex == 502 && DataManager.Instance.QuestNum == 501)
            {
                tutorial_training_btn.SetActive(true);
                DataManager.Instance.QuestNum = 502;
            } else {
                tutorial_training_btn.SetActive(false);
            }

            return;
        }

        // npc name
        chr_name.text = talkData.Split(':')[0];

        // npc script
        TA.SetMsg(talkData.Split(':')[1].ToString());   //chr_script.text  = ""

        // npc img
        if (talkData.Split(':')[2].Length == 0)
        {
            chr_img_left.color = new Color(1,1,1,0);
        } else {
            chr_img_left.sprite = Getimg_data(int.Parse(talkData.Split(':')[2]));
            chr_img_left.color = new Color(1,1,1,1);
        } 

        talkIndex++;

    }

    public int GetQuestTalkIndex(int npc_id) {
        return questId;
    }


    void NextQuest()
    {
        questId += 100;
    }


    // 버튼 함수
    public void skip_btn(){
        Black_Bakcground.SetActive(true);
        next_script_btn.GetComponent<Button>().interactable = false;
        Sfx.SoundBtn();
    }

    public void skipgo_btn(){ // 스킵하기 
        Debug.Log("press : 스킵하기 버튼 누름");
        Sfx.SoundBtn();
    }

    public void return_btn(){
        Black_Bakcground.SetActive(false);
        next_script_btn.GetComponent<Button>().interactable = true;
        Sfx.SoundBtn();
    }

    

}
