using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guide1 : MonoBehaviour
{

    public GameObject trigger;

    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            DataManager.Instance.QuestAction = 1;
            DataManager.Instance.Guide = 1;

            trigger.SetActive(false);

        }
    }
}
