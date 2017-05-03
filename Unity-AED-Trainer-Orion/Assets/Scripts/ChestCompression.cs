﻿using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;
using UnityEngine.UI;


//for chest compression
//手がBox Colliderに触れるisTouch=true→手のy座標をとる→-5cm沈んだらフラグを立てる→フラグが立った状態でBox Colliderにふれたら圧迫回数+1にするisCount = true
//ToDo:PushCount = nから、PushCount = n + 1になるまでの時間が0.5-0.6秒(100-120BPM)であれば、PushGoodを返す
public class ChestCompression : MonoBehaviour
{

    public Vector3 StartPosition;
    public int PushCount = 0;
    private int CurrentCount = 0;

    private bool isTouch = false;
    private bool isPush = false;
    private bool isStart = false;
    public bool isCount = false;
    public bool isGood = false;
    public bool isLate = false;

    private int aIndex;

    public float PushTime;
    public float CurrentTime;


    Text tTex;
    MeshRenderer tTexMesh;

    HandPosition hp = new HandPosition();

    LeapHandCollision hc = new LeapHandCollision();





    //otherは衝突相手（この場合は手）のデータが入る
    void OnTriggerEnter(Collider other)
    {

        if (FlagManager.Instance.flags[0] == false && hc.IsHand(other)) //ここの条件は必要？
        {


            if (hc.IsHand(other))
            {
                isTouch = true;


            }
        }
    }



    // Use this for initialization
    void Start()
    {
        tTex = GameObject.Find("TempoText").GetComponent<Text>();




    }

    // Update is called once per frame
    //StartPosition - 5cmになったらフラグをたてる
    void Update()
    {

        HandPosition hp = GetComponent<HandPosition>();

        if (isTouch == true && isPush == false && isStart == false)
        {
            CurrentCount = PushCount;//PushCountとCurrentCountを比較する必要があるのでここに書く、場所があってるか不明 ループ一周目はCurrentCountは0、isCount =true のところでPushCountは1
            CurrentTime = Time.time;
            StartPosition = hp.ConvertPosition;
            Debug.Log("CurrentTime" + CurrentTime);

            isGood = false;
            isLate = false;
            isStart = true;
            isCount = false;

        }

        if (isStart == true && (StartPosition.y - 0.05) >= (hp.ConvertPosition.y))//スタート位置のCollisionにふれていて、5cm沈み込んだらフラグをたてる
        {
            isPush = true;

        }

        if (isTouch == true && isPush == true && isCount == false)  //5cm押し込んでいる、かつスタート位置のCollisionに再び触れたら
        {
            PushCount++;
            PushTime = Time.time;
            isTouch = false;
            isPush = false;
            isStart = false;
          

            Debug.Log(PushTime - CurrentTime);
          
            isCount = true;

        }

        TimeJudge();
    }

    void TimeJudge()
    {
        if (0.5 <= (PushTime - CurrentTime) && (PushTime - CurrentTime) <= 0.6)  //本来の条件100-120BPM
        //if ((0.5 <= (PushTime - CurrentTime)) && ( (PushTime - CurrentTime) <= 2.0)) //デバッグ用
        {
            isGood = true;

        }

        if ((PushTime - CurrentTime) > 0.6)
        {
            isLate = true;
        }


        if (isCount == true)
        {
            if (isGood == true)
            {
                Debug.Log("Good!");

                tTex.color = new Color(255, 255, 255, 1);

                tTex.text = "Good";
            }
            if (isLate == true)
            {

                Debug.Log("Late");

                tTex.color = new Color(255, 255, 255, 1);

                tTex.text = "Late";
            }
        }

  


        if (isGood == false || isLate == false)
        {
            tTex.GetComponent<Text>().color = new Color(0, 0, 0, 0);
        }

    }



}

