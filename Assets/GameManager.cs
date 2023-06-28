using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI를 추가
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] NumberImage;
    public Sprite[] Number;

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
    }

}
