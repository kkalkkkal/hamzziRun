using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizZone : MonoBehaviour
{
    public TextMeshProUGUI quizblock1;
    public TextMeshProUGUI quizblock2;
    public TextMeshProUGUI quiz_content; 
    public GameObject QuizPanel;
    public GameObject Sign_O;
    public GameObject Sign_X;

    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!DataManager.Instance.PlayerDie)
        {
            QuizPanel.SetActive(false);
            Sign_O.SetActive(false);
            Sign_X.SetActive(false);
            if (collision.gameObject.tag.CompareTo("Player") == 0)
            {
                if(DataManager.Instance.tutorial == 0)
                {
                    SetQuiz();
                }

                DataManager.Instance.QuizOnOff = true;
            }
        }
    }

    // 퀴즈 설정
    void SetQuiz()
    {
        int A = 0;
        int B = 0;
        int answer = 0;
        int wrong = 0;

        int index = 0;

        A = Random.Range(1, 10);
        B = Random.Range(1, 10);
        answer = A + B;
        DataManager.Instance.answer = answer;
        wrong = Random.Range(2, 19);

        index = Random.Range(0,2); // 0~1 랜덤

        if (index == 1)
        {
            quizblock1.text = answer.ToString();
            quizblock2.text = wrong.ToString();
        } else {
            quizblock1.text = wrong.ToString();
            quizblock2.text = answer.ToString();
        }

        
        quiz_content.text = A.ToString() + " + " + B.ToString() + " = ?";

    }
}
