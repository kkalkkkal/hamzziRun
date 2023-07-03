using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


//UI를 추가
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] NumberImage;
    public Sprite[] Number;

    //TImeBar 추가 
    public Image TimeBar;

    //EndPanel GameObject 연동용 변수 추가
    public GameObject EndPanel;

    // PausePanel GameObject 연동용 변수 추가
    public GameObject PausePanel;


    private void Update()
    {
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
            DataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime; //1초에 1씩만 빼.

            //TImeBar 추가
            //1 ~ 0까지의 범위에서 값이 결정 됨. 다 채워져 있는 상태가 1
            TimeBar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;

            //시간이 다 되면 죽음
            if (DataManager.Instance.playTimeCurrent < 0)
            {
                DataManager.Instance.PlayerDie = true;
                //배경 끄기
            }

        }

        //만약 플레이어가 죽었다면 EndPanel 켜기
        if (DataManager.Instance.PlayerDie == true)
        {
            EndPanel.SetActive(true);
        }
    }


    public void Restart_Btn()
    {
        Time.timeScale = 1;
        DataManager.Instance.score = 0;
        DataManager.Instance.PlayerDie = false;
        DataManager.Instance.playTimeCurrent = DataManager.Instance.playTimeMax;
        //DataManager.Instance.margnetTimeCurrent = 0;

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
    }

}
