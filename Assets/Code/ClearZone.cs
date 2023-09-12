using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearZone : MonoBehaviour
{
    public GameObject ClearPanel;
    


    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!DataManager.Instance.PlayerDie)
        {
            if (collision.gameObject.tag.CompareTo("Player") == 0)
            {
                DataManager.Instance.GameClear = true;
                Time.timeScale = 0;

            }
        }
    }

}
