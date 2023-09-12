using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{

    //static public float mapSpeed = 1f; // 맵 속도

    // Start is called before the first frame update
    void Start()
    {
        
    }

     private void Update()
    {
        // 죽으면 끝
        if (!DataManager.Instance.PlayerDie)
        {

            if(DataManager.Instance.skillOnOff)
            {
                //맵 스피드만큼 -x 축으로 이동
                transform.Translate(-DataManager.Instance.mapSpeed * Time.deltaTime * 1.3f, 0, 0); // 30% 빠른 스피드
                //if(DataManager.)
            } else {
                //맵 스피드만큼 -x 축으로 이동
                transform.Translate(-DataManager.Instance.mapSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
}
