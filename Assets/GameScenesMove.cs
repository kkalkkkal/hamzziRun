using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesMove : MonoBehaviour
{
    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
