using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{   
    //스테이지 전환

    public void StageSelect1()
    {   
        SceneManager.LoadScene("StageSelect");
    }
    
    public void StageSelect2()
    {   
        SceneManager.LoadScene("Select2");
    }

    public void StageSelect3()
    {   
        SceneManager.LoadScene("Select3");
    }

    public void StageSelect4()
    {   
        SceneManager.LoadScene("Select4");
    }

    public void StageSelect5()
    {   
        SceneManager.LoadScene("Select5");
    }


    //맵 이동    

    public void GoSelc1()
    {   
        SceneManager.LoadScene("SampleScene");
    }



}