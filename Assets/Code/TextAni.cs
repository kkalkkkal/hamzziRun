using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAni : MonoBehaviour
{
    string targetMsg;
    public int CharPerSeconds;
    public TextMeshProUGUI msgText;
    int index;
    public static float interval;

    public GameObject EndCursor;


   

    private void Awake()
    {
        //msgText = GetComponent<TextMeshProUGUI>();
    }

    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();
    }

    void EffectStart()
    {
        // 시작할때 출력할 텍스트 영역을 비워야한다. 
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);
        QuestManager.isTypingEnd = false;

        interval = 1.0f / CharPerSeconds;
        Debug.Log(interval);

        Invoke("Effecting", interval);

    }

    void Effecting()
    {
        // 받은 텍스트를 타이핑 애니메이션을 넣어 출력해야한다. 
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];
        index++;

        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        //문장을 모두 출력하고, 터치하면 다음 문장으로 넘어가거나 종료해야한다. 
        QuestManager.isTypingEnd = true;
        EndCursor.SetActive(true);
    }

}
