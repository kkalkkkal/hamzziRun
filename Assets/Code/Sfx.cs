using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip coin;
    public static AudioClip correct;
    public static AudioClip wrong;
    public static AudioClip jump;
    public static AudioClip click;
    public static AudioClip Running;
    public static AudioClip main;
    public static AudioClip clear;
    public static AudioClip skill;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coin = Resources.Load<AudioClip>("Sound/coin1");
        correct = Resources.Load<AudioClip>("Sound/correct");
        wrong = Resources.Load<AudioClip>("Sound/wrong");
        jump = Resources.Load<AudioClip>("Sound/jump");
        click = Resources.Load<AudioClip>("Sound/click");
        main = Resources.Load<AudioClip>("Sound/hamzzi_main");
        Running = Resources.Load<AudioClip>("Sound/Twirly Tops");
        clear = Resources.Load<AudioClip>("Sound/clear");
        skill = Resources.Load<AudioClip>("Sound/skill");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 코인 효과음
    public static void SoundPlay()
    {
        audioSource.PlayOneShot(coin);
    }

    // 정답 효과음
    public static void SoundCorrect()
    {
        audioSource.PlayOneShot(correct);
    }

    // 오답 효과음
    public static void SoundWrong()
    {
        audioSource.PlayOneShot(wrong);
    }

    public static void SoundJump()
    {
        audioSource.PlayOneShot(jump);
    }

    public static void SoundClear()
    {
        audioSource.PlayOneShot(clear);
    }

    public static void SoundBtn()
    {
        audioSource.PlayOneShot(click);
    }

    public static void SoundSkill()
    {
        audioSource.PlayOneShot(skill);
    }

    
}

