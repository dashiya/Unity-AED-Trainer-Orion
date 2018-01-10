﻿using UnityEngine;
using System.Collections;


//Cubeに一定時間触れたかどうかの判定をする→RandomChangeScene(訓練),StartTutorialScene(チュートリアル)へ分岐
public class GetBoxCollider : MonoBehaviour
{
    float StartTime = 0.0f;
    float CurrentTime = 0.0f;
    bool isTouchTimeCount = false;
    bool isTouchStartButton = false;

    public bool canRandomChangeScene, canStartTutorial = false;

    LeapHandCollision _hc = new LeapHandCollision();
    // Use this for initialization
    void Start()
    {
        //Cubeの色変更,Inspector上で変更する方法がわからなかったため
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.black);

    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (_hc.IsHand(other))
    //    {

    //        isTouchStartButton = true;

    //    } 
        

    //}
    void OnTriggerExit(Collider exithand)
    {
        isTouchStartButton = false;
        StartTime = 0.0f;
        CurrentTime = 0.0f;

    }

    void OnTriggerEnter(Collider hand)
    {
        //訓練スタートのためのタイマースタート時間とリセット
        //if (_hc.IsHand(hand) && isTouchStartButton == true)
        //{
        //    StartTime = Time.time;

        //}
        //if (_hc.IsHand(hand) && isTouchStartButton == false)//GetBoxColliderに触れて離してを繰り返すとタイマーが進む問題を解決するため、離すとタイマーがリセットされる
        //{
        //    StartTime = 0.0f;
        //    CurrentTime = 0.0f;

        //訓練スタートのためのタイマースタート時間とリセット
        //if (_hc.IsHand(hand) && isTouchStartButton == true)
        if (_hc.IsHand(hand))
         {
            StartTime = Time.time;
            isTouchStartButton = true;

        }

    }


    

    // Update is called once per frame
    void Update()
    {
        //訓練スタートのためのタイマー
        if (isTouchStartButton == true)
        {
            CurrentTime = Time.time;
            isTouchTimeCount = true;
        } else {
            CurrentTime = 0.0f;
        }

        if ((StartTime + 2.0f <= CurrentTime) && isTouchTimeCount == true && isTouchStartButton == true)
        {
            canRandomChangeScene = true;

        }

        if ( isTouchStartButton == false)//GetBoxColliderに触れて離してを繰り返すとタイマーが進む問題を解決するため、離すとタイマーがリセットされる
        {
            StartTime = 0.0f;
            CurrentTime = 0.0f;
        }

        Debug.Log(StartTime + "StartTime");

        Debug.Log(CurrentTime + "CurrentTime");
    }
}