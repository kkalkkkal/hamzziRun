using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WjChallenge;
using TMPro;

public enum CurrentStatus { WAITING, DIAGNOSIS, LEARNING }
public class WJ_Sample : MonoBehaviour
{
    public GameObject Sign_O;
    public GameObject Sign_X;

    public GameObject ResultPanel;
    public TextMeshProUGUI accuracy_text;
    public TextMeshProUGUI correct_text;
    public TextMeshProUGUI Exp_text;

    public GameObject Rank_info;

    [SerializeField] WJ_Connector       wj_conn;
    [SerializeField] CurrentStatus      currentStatus;
    public CurrentStatus                CurrentStatus => currentStatus;

    [Header("Panels")]
    [SerializeField] GameObject         panel_diag_chooseDiff;  //���̵� ���� �г�
    [SerializeField] GameObject         panel_question;         //���� �г�(����,�н�)

    [SerializeField] Text   textDescription;        //���� ���� �ؽ�Ʈ
    [SerializeField] TEXDraw   textEquation;           //���� �ؽ�Ʈ(��TextDraw�� ���� �ʿ�)
    [SerializeField] Button[]           btAnsr = new Button[4]; //���� ��ư��
    TEXDraw[]                textAnsr;                  //���� ��ư�� �ؽ�Ʈ(��TextDraw�� ���� �ʿ�)

    [Header("Status")]
    int     currentQuestionIndex;
    bool    isSolvingQuestion;
    float   questionSolveTime;

    [Header("For Debug")]
    [SerializeField] WJ_DisplayText     wj_displayText;         //�ؽ�Ʈ ǥ�ÿ�(�ʼ�X)
    [SerializeField] Button             getLearningButton;      //���� �޾ƿ��� ��ư

    private void Awake()
    {
        textAnsr = new TEXDraw[btAnsr.Length];
        for (int i = 0; i < btAnsr.Length; ++i)

            textAnsr[i] = btAnsr[i].GetComponentInChildren<TEXDraw>();

        wj_displayText.SetState("대기중", "", "", "");
    }

    private void OnEnable()
    {
        Setup();
    }

    private void Setup()
    {
        switch (currentStatus)
        {
            case CurrentStatus.WAITING:
                panel_diag_chooseDiff.SetActive(true);
                break;
        }

        if (wj_conn != null)
        {
            wj_conn.onGetDiagnosis.AddListener(() => GetDiagnosis());
            wj_conn.onGetLearning.AddListener(() => GetLearning(0));
        }
        else Debug.LogError("Cannot find Connector");
    }

    private void Update()
    {
        if (isSolvingQuestion) questionSolveTime += Time.deltaTime;
    }

    /// <summary>
    /// ������ ���� �޾ƿ���
    /// </summary>
    private void GetDiagnosis()
    {
        switch (wj_conn.cDiagnotics.data.prgsCd)
        {
            case "W":
                MakeQuestion(wj_conn.cDiagnotics.data.textCn, 
                            wj_conn.cDiagnotics.data.qstCn, 
                            wj_conn.cDiagnotics.data.qstCransr, 
                            wj_conn.cDiagnotics.data.qstWransr);
                wj_displayText.SetState("������ ��", "", "", "");
                break;
            case "E":
                Debug.Log("������ ��! �н� �ܰ�� �Ѿ�ϴ�.");
                wj_displayText.SetState("������ �Ϸ�", "", "", "");
                currentStatus = CurrentStatus.LEARNING;
                getLearningButton.interactable = true;
                break;
        }
    }

    /// <summary>
    ///  n ��° �н� ���� �޾ƿ���
    /// </summary>
    private void GetLearning(int _index)
    {
        if (_index == 0) currentQuestionIndex = 0;

        MakeQuestion(wj_conn.cLearnSet.data.qsts[_index].textCn,
                    wj_conn.cLearnSet.data.qsts[_index].qstCn,
                    wj_conn.cLearnSet.data.qsts[_index].qstCransr,
                    wj_conn.cLearnSet.data.qsts[_index].qstWransr);
    }

    /// <summary>
    /// �޾ƿ� �����͸� ������ ������ ǥ��
    /// </summary>
    private void MakeQuestion(string textCn, string qstCn, string qstCransr, string qstWransr)
    {
        panel_diag_chooseDiff.SetActive(false);
        panel_question.SetActive(true);

        string      correctAnswer;
        string[]    wrongAnswers;

        textDescription.text = textCn;
        textEquation.text = qstCn;

        correctAnswer = qstCransr;
        wrongAnswers    = qstWransr.Split(',');

        int ansrCount = Mathf.Clamp(wrongAnswers.Length, 0, 3) + 1;

        for(int i=0; i<btAnsr.Length; i++)
        {
            if (i < ansrCount)
                btAnsr[i].gameObject.SetActive(true);
            else
                btAnsr[i].gameObject.SetActive(false);
        }

        int ansrIndex = Random.Range(0, ansrCount);

        for(int i = 0, q = 0; i < ansrCount; ++i, ++q)
        {
            if (i == ansrIndex)
            {
                textAnsr[i].text = correctAnswer;
                --q;
            }
            else
                textAnsr[i].text = wrongAnswers[q];
        }
        isSolvingQuestion = true;
    }

    public void Correct(){
        Sign_O.SetActive(false);
        
    }
    public void Wrong(){
        Sign_X.SetActive(false);
    }


    /// <summary>
    /// ���� ������ �¾Ҵ� �� üũ
    /// </summary>
    public void SelectAnswer(int _idx)
    {
        bool isCorrect;
        string ansrCwYn = "N";

        Sfx.SoundBtn();
        switch (currentStatus)
        {
            case CurrentStatus.DIAGNOSIS:
                isCorrect   = textAnsr[_idx].text.CompareTo(wj_conn.cDiagnotics.data.qstCransr) == 0 ? true : false;
                ansrCwYn    = isCorrect ? "Y" : "N";
                DataManager.Instance.solve_count++;
                /// add Todo
                if (isCorrect){
                    Sign_O.SetActive(true);
                    Sfx.SoundCorrect();
                    Invoke("Correct", 1);
                    DataManager.Instance.Correct_count++;
                } else {
                    Sign_X.SetActive(true);
                    Sfx.SoundWrong();
                    Invoke("Wrong", 1);
                }

                ///
                // to do
                if (DataManager.Instance.solve_count >= 8)
                {
                    ResultPanel.SetActive(true);
                    correct_text.text = "x " + DataManager.Instance.Correct_count.ToString() + " 개";
                    accuracy_text.text = ((float) DataManager.Instance.Correct_count / 8f * 100f).ToString() + "%";
                    Exp_text.text = (DataManager.Instance.Correct_count * 5).ToString();
                    Sfx.SoundClear();
                }

                isSolvingQuestion = false;
                wj_conn.Diagnosis_SelectAnswer(textAnsr[_idx].text, ansrCwYn, (int)(questionSolveTime * 1000));

                wj_displayText.SetState("������ ��", textAnsr[_idx].text, ansrCwYn, questionSolveTime + " ��");

                panel_question.SetActive(false);
                questionSolveTime = 0;
                
                
                break;

            case CurrentStatus.LEARNING:
                isCorrect   = textAnsr[_idx].text.CompareTo(wj_conn.cLearnSet.data.qsts[currentQuestionIndex].qstCransr) == 0 ? true : false;
                ansrCwYn    = isCorrect ? "Y" : "N";

                isSolvingQuestion = false;
                currentQuestionIndex++;
                DataManager.Instance.solve_count++;
                /// add Todo
                if (isCorrect){
                    Sign_O.SetActive(true);
                    Sfx.SoundCorrect();
                    Invoke("Correct", 0.5f);
                    DataManager.Instance.Correct_count++;
                } else {
                    Sign_X.SetActive(true);
                    Sfx.SoundWrong();
                    Invoke("Wrong", 0.5f);
                }

                // to do
                if (DataManager.Instance.solve_count >= 8)
                {
                    ResultPanel.SetActive(true);
                    correct_text.text = "x " + DataManager.Instance.Correct_count.ToString() + " 개";
                    accuracy_text.text = ((float) DataManager.Instance.Correct_count / 8f * 100f).ToString() + "%";
                    Exp_text.text = (DataManager.Instance.Correct_count * 5).ToString();
                    Sfx.SoundClear();
                }

                ///
                //Invoke("Learning_todo", 2);
                wj_conn.Learning_SelectAnswer(currentQuestionIndex, textAnsr[_idx].text, ansrCwYn, (int)(questionSolveTime * 1000));

                wj_displayText.SetState("����Ǯ�� ��", textAnsr[_idx].text, ansrCwYn, questionSolveTime + " ��");

                if (currentQuestionIndex >= 8) 
                {
                    panel_question.SetActive(false);
                    wj_displayText.SetState("����Ǯ�� �Ϸ�", "", "", "");
                }
                else GetLearning(currentQuestionIndex);

                questionSolveTime = 0;
                
                break;
        }
    }

    public void DisplayCurrentState(string state, string myAnswer, string isCorrect, string svTime)
    {
        if (wj_displayText == null) return;

        wj_displayText.SetState(state, myAnswer, isCorrect, svTime);
    }

    #region Unity ButtonEvent
    public void ButtonEvent_ChooseDifficulty(int a)
    {
        Sfx.SoundBtn();
        Rank_info.SetActive(false);
        DataManager.Instance.solve_count = 0;
        DataManager.Instance.Correct_count = 0;
        currentStatus = CurrentStatus.DIAGNOSIS;
        wj_conn.FirstRun_Diagnosis(a);
    }
    public void ButtonEvent_GetLearning()
    {
        Sfx.SoundBtn();
        Rank_info.SetActive(false);
        DataManager.Instance.solve_count = 0;
        DataManager.Instance.Correct_count = 0;
        wj_conn.Learning_GetQuestion();
        wj_displayText.SetState("����Ǯ�� ��", "-", "-", "-");
    }
    #endregion
}
