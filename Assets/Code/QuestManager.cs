using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class QuestManager : MonoBehaviour
{

    // 출력 UI 
    public TextMeshProUGUI chr_name; 
    public TextMeshProUGUI chr_script;
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


    void Awake() {
        questList = new Dictionary<int, QuestData>();
        img_data = new Dictionary<int, Sprite>();
        Black_Bakcground.SetActive(false);
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("긴급 소집", new int[] {1000,2000}));

        img_data.Add(1000 + 0, img_arr[0]);
        img_data.Add(1000 + 1, img_arr[1]);
        img_data.Add(1000 + 2, img_arr[2]);
        img_data.Add(1000 + 3, img_arr[3]);
        img_data.Add(1000 + 4, img_arr[4]);
        img_data.Add(1000 + 5, img_arr[5]);

        
    }

    // 화면 터치하면 다음 스크립트 출력
    public void next_script() { // 퀘스트 아이디와 스크립트 순서를 인자로 받음.

    /* Todo :: 첫 시나리오 돌입 시 엑셀 DB에서 퀘스트 ID와 
    그와 관련된 데이터를 모두 받아오는 작업 필요
    그리고 순차적으로 출력할 수 있도록 정제.
    */
        TA.SetMsg("asdf123");
        chr_name.text = "asdf";
        //chr_script.text = "asdf2";
        chr_img_left.sprite = img_arr[5]; 

    }

    public int GetQuestTalkIndex(int npc_id) {
        return questId;
    }

    // 버튼 함수
    public void skip_btn(){
        Black_Bakcground.SetActive(true);
        next_script_btn.GetComponent<Button>().interactable = false;
    }

    public void skipgo_btn(){ // 스킵하기 
        Debug.Log("press : 스킵하기 버튼 누름");
    }

    public void return_btn(){
        Black_Bakcground.SetActive(false);
        next_script_btn.GetComponent<Button>().interactable = true;

    }

    

}
