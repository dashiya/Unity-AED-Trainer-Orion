using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;
using UnityEngine.UI;


//for chest compression
//手がBox Colliderに触れるisTouch=true→手のy座標をとる→-5cm沈んだらフラグを立てる→
//フラグが立った状態でBox Colliderにふれたら圧迫回数+1にするisCount = true

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
    public bool isFast = false;

    bool isCheckTime = false;
    bool isCheckCompereTime = false;
    bool isChangePushCount = false;

    private int aIndex;

    public float PushTime = 0f;
    public float CurrentTime = 0f;

    Text tTex;

    MeshRenderer tTexMesh;

    LeapHandCollision hc = new LeapHandCollision();
    //  HandPosition hp = new HandPosition(); 現状不必要なのでコメントアウト
    void Start()
    {
        tTex = GameObject.Find("TempoText").GetComponent<Text>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (hc.IsHand(other)) //For debug 
        //if (FlagManager.Instance.flags[7] == true && hc.IsHand(other))
        {
            if (hc.IsHand(other))
            {
                isTouch = true;
            }
        }
    }



    //Todo:胸骨圧迫が行われたかどうかの判断と、適切なタイミングでそれぞれの変数に時間を入れてテンポを判断するところは別の関数でやるべき
    //ex: 胸骨圧迫が一回終わる→フラグ立てる→そのタイミングの時間を保存→胸骨圧迫二回目が終わる→フラグ立てる→そのタイミングの時間を保存→一回目の時刻と比較、表示
    void Update()
    {
        HandPosition hp = GetComponent<HandPosition>();

        //flags[7]は電気ショックが終わったらtrueになる、胸骨圧迫と人工呼吸の音声と同時 1つめ　最終的にisStart=falseかtrueか判断する
       // if (isTouch == true && isPush == false && isStart == false) //falg[7] = trueにするのが面倒くさいとき用 for debug
            if (FlagManager.Instance.flags[7] == true && isTouch == true && isPush == false && isStart == false)
            {
            CurrentCount = PushCount;//PushCountとCurrentCountを比較する必要があるのでここに書く、場所があってるか不明 ループ一周目はCurrentCountは0、isCount =true のところでPushCountは1
            StartPosition = hp.ConvertPosition; //共に単位はメートル

            //各種フラグリセット
            isCount = false;
            isGood = false;
            isLate = false;
            isFast = false;

            isStart = true;
            Debug.Log(hp.ConvertPosition.y + "hp.convPos.y");
        }

        //2つめ
        if (isTouch == true && isStart == true && isPush == false && (StartPosition.y - 0.05) >= (hp.ConvertPosition.y))//スタート位置のCollisionにふれていて、5cm沈み込んだらフラグをたてる
        {
            isPush = true;
        }

        //3つめ
        if (isTouch == true && isStart == true && isPush == true && isCount == false)  //5cm押し込んでいる、かつスタート位置のCollisionに再び触れたら
        {
            PushCount++;

            //各種フラグリセット
            isTouch = false;
            isPush = false;
            isStart = false;

            isCount = true;
        }

        TimeCompere();
        TimeJudge();

        
        Debug.Log(PushCount + "回");
    }

    //胸骨圧迫→胸骨圧迫の間隔の時間を取得するクラス
    void TimeCompere()
    {
        if (isCount == true && isCheckTime == false)
        {
            //一旦胸骨圧迫したときの時間を保存           
            CurrentTime = Time.time;
            isCheckTime = true;
        }
        if (isCheckTime && isCount == false)
        {
            isChangePushCount = true;
        }
        if (isChangePushCount == true && PushCount > CurrentCount)
        {
            PushTime = Time.time;
            Debug.Log(PushTime - CurrentTime);

            //flagリセット
            isCheckTime = false;
            isChangePushCount = false;
        }
    }

    //圧迫するタイミングの判断
    void TimeJudge()
    {
        if (isCount == true)
        {
            if (0.5 <= (PushTime - CurrentTime) && (PushTime - CurrentTime) <= 0.6)
            {
                tTex.color = new Color(255, 255, 255, 1);
                tTex.text = "Good";
            }
            if (0.6 < (PushTime - CurrentTime))
            {
                tTex.color = new Color(255, 255, 255, 1);
                tTex.text = "Late";
            }
            if (0.0 < (PushTime - CurrentTime) && (PushTime - CurrentTime) < 0.5)
            {
                tTex.color = new Color(255, 255, 255, 1);
                tTex.text = "Fast";
            }
        }

        //テキストの色を透明化、ObjectをDestroyせずに見えないようにするため
        if (isCount == false)
        {
            tTex.GetComponent<Text>().color = new Color(0, 0, 0, 0);
        }
    }

    
}