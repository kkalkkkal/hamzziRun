using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float jump = 10f; //첫번째 점프 값
    public float jump2 = 12f; //두번째 점프 값

    Rigidbody2D rigid;
    Animator animator;

    int State = 0;
    

    int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D> ();
        animator = gameObject.GetComponentInChildren<Animator> ();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCount == 0)
        {
            animator.SetInteger("State", 0);
        } 
        else if (jumpCount == 1)
        {
            animator.SetInteger("State", 1);
        }
        else if (jumpCount == 2)
        {
            animator.SetInteger("State", 2);
        }
        
    }

    //버튼에 넣을 함수.
    public void Jump_Btn()
    { 
            if (jumpCount == 0)  //점프를 한번도 안함.
            {
                rigid.velocity = new Vector3(0, jump, 0);
                jumpCount += 1;  //점프횟수 추가.
            }
            else if (jumpCount == 1) //점프 한 번 함.
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                jumpCount += 1;  //점프횟수 추가.
            }
        
    }

    //바닥과 충돌시(점프 후 착지하면) 동작
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Land") == 0)
        {
            jumpCount = 0;
        }
    }
}




