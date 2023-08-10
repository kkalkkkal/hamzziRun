using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Quizblock : MonoBehaviour
{
    private string nowquiz;

    public int answer = 3;
    public TextMeshProUGUI block_text;
    public GameObject Sign_O;
    public GameObject Sign_X;

    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            gameObject.SetActive(false);

            // To do : 충돌했을 때 정답이면 퀴즈 패널에 정답 사인 출력, 아니면 X 사인 출력
            // 정답 일때 누메릭 게이지 30% 충전 

            Debug.Log(block_text.text.GetType());
            if(block_text.text == answer.ToString())
            {
                
                Sign_O.SetActive(true);
                DataManager.Instance.numericPoint += DataManager.Instance.numericPointMax * 0.3f;

            } else {

                Sign_X.SetActive(true);

            }

        }
    }
}
