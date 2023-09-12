using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesMove : MonoBehaviour
{

    public GameObject tutorial_training_btn;
    public GameObject tutorial_travel_btn;

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");        
    }

    public void GoStageSelect()
    {
        if (DataManager.Instance.QuestNum == 100)
        {
            tutorial_travel_btn.SetActive(false);
        }
        SceneManager.LoadScene("AdventureStage");
    }

    public void GoBrainTrain()
    {
        if (DataManager.Instance.QuestNum == 502)
        {
            tutorial_training_btn.SetActive(false);
        }
        SceneManager.LoadScene("BrainTrain");
    }
}
