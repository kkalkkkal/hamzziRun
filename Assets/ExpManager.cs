using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExpManager : MonoBehaviour
{

    public GameObject ResultPanel;
    public GameObject Rank_info;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResultBtn() {
        Sfx.SoundBtn();
        Rank_info.SetActive(true);
        ResultPanel.SetActive(false);
    }

    public void BackBtn() {
        Sfx.SoundBtn();
        SceneManager.LoadScene("MainMenu");
    }
}
