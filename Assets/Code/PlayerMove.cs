using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float jump = 10f; //첫번째 점프 값
    public float jump2 = 12f; //두번째 점프 값

    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer spriteRenderer;

    int State = 0;
    

    int jumpCount = 0;
    int slideCount = 0;

    // Start is called before the first frame update
    // gameObject는 스크립트를 할당한 오브젝트 자신을 의미함.
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D> ();
        animator = gameObject.GetComponentInChildren<Animator> ();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCount == 0)
        {
            if (slideCount == 1){
                animator.SetInteger("State", 4);
            } else {
            animator.SetInteger("State", 0);
            }
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
        if (!DataManager.Instance.PlayerDie)
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
    }

    public void Slide_Btn_Down()
    {
        if(!DataManager.Instance.PlayerDie)
        {
            slideCount = 1;
        }
    }

    public void Slide_Btn_UP(){
        if(!DataManager.Instance.PlayerDie)
        {
            slideCount = 0;
        }
    }




    //바닥과 충돌시(점프 후 착지하면) 동작
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Land") == 0)
        {
            jumpCount = 0;
        }

            // 장애물에 부딪히면 시간 줄어들기
            
        if (collision.gameObject.tag.CompareTo("Block") == 0)
        {
            DataManager.Instance.playTimeCurrent -= 2f;
            OnDamaged(); // To do :  플레이어 무적 시간 부여
        }
    }

    // 피격 시 무적 부여
    void OnDamaged(){
        gameObject.layer = 11; // 레이어를 바꾸어서 무적 상태

        // 색이 반투명하게 바뀜.
        spriteRenderer.color = new Color(1,1,1,0.4f); //

        Invoke("OffDamaged", 1); // 무적 시간 설정
        
    }

    // 무적 상태 해제
    void OffDamaged() {
        gameObject.layer = 3; // Player 레이어로 원복

        // 반투명 해제
        spriteRenderer.color = new Color(1,1,1,1); 
    }
}




