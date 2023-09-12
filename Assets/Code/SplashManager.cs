using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    public string usercode = "0000000";
    public string language = "kr";
    public int userlevel = 1;
    public int userexp = 0;
    public int newStart = 0;
    public int userQuestnum = 0;
    public int laststage = 0;
    public int lastquest = 0;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("Start", 0);

        // 첫 시작 여부
        if (check_start()){
            DataManager.Instance.now_stage_num = 0;       
        } else {
            DataManager.Instance.now_stage_num = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool check_start(){
        newStart = PlayerPrefs.GetInt("Start");
        Debug.Log("newStart :" + newStart);

        // 사용자 기본 정보
        load_userdata();
        
        if (newStart == 0)
        {
            //PlayerPrefs.SetInt("Start", 1); 튜토리얼이 끝났을 때 설정할 것
            PlayerPrefs.SetString("usercode", "0000000");
            PlayerPrefs.SetString("language", "kr");
            PlayerPrefs.SetInt("userlevel", 1);
            PlayerPrefs.SetInt("userexp", 0);
            PlayerPrefs.SetInt("userQuestnum", 0);
            PlayerPrefs.SetInt("LastStage", 0);
            return true;
        } else {
            return false;
        }
    }

    public void load_userdata(){
        usercode = PlayerPrefs.GetString("usercode");
        Debug.Log("usercode : " + usercode);

        language = PlayerPrefs.GetString("language");
        Debug.Log("language : " + language);

        userlevel = PlayerPrefs.GetInt("userlevel");
        Debug.Log("userlevel : " + userlevel);

        userexp = PlayerPrefs.GetInt("userexp");
        Debug.Log("userexp : " + userexp);

        userQuestnum = PlayerPrefs.GetInt("userQuestnum");
        Debug.Log("userQuestnum : " + userQuestnum);

        laststage = PlayerPrefs.GetInt("LastStage");
        Debug.Log("laststage : " + laststage);

        lastquest = PlayerPrefs.GetInt("LastQuest");
        Debug.Log("LastQuest : " + lastquest);
        

    }

    public void GoTutorial() {
        DataManager.Instance.QuestNum = userQuestnum;

        if (newStart == 0)
        {
            DataManager.Instance.tutorial = 1;
            SceneManager.LoadScene("SampleScene");
        } else {
            DataManager.Instance.tutorial = 0;
            SceneManager.LoadScene("MainMenu");        
        }
    }
}
