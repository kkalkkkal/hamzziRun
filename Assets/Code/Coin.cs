using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            DataManager.Instance.score += 1;
            //나 자신을 화면에서 꺼
            gameObject.SetActive(false);

        }
    }
}
