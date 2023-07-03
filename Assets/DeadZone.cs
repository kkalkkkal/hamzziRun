using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!DataManager.Instance.PlayerDie)
        {
            if (collision.gameObject.tag.CompareTo("Player") == 0)
            {
                DataManager.Instance.PlayerDie = true;
            }
        }
    }
}
