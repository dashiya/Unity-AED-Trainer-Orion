using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChestCompression_Tutorial : MonoBehaviour
{

    public Vector3 StartPosition;

    public uint PushCount = 0;
    private uint CurrentCount = 0;

    public bool isTouch = false;
    public bool isPush = false;
    public bool isStart = false;
    public bool isCount = false;
    public bool isGood = false;
    public bool isLate = false;
    public bool isFast = false;

    bool isCheckTime = false;
    bool isChangePushCount = false;

    private int aIndex;

    public float PushTime = 0.0f;
    public float CurrentTime = 0.0f;

    Text _tTex;
    MeshRenderer _tTexMesh;

    LeapHandCollision _hc = new LeapHandCollision();
    //  HandPosition hp = new HandPosition(); 現状不必要なのでコメントアウト
    void Start()
    {
        _tTex = GameObject.Find("TempoText").GetComponent<Text>();
    }


    void OnTriggerEnter(Collider other)
    {
        //if (_hc.IsHand(other)) //For debug 
        if (FlagManager.Instance.flags[7] == true && _hc.IsHand(other))
        {
            if (_hc.IsHand(other))
            {
                isTouch = true;
            }
        }
    }

    //手がBox Colliderに触れるisTouch=true→手のy座標をとる→-5cm沈んだらフラグを立てる→
    //フラグが立った状態でBox Colliderにふれたら圧迫回数+1にするisCount = true　が一連の流れ
    void Update()
    {
        HandPosition hp = GetComponent<HandPosition>();

        //flags[7]は電気ショックが終わったらtrueになる、胸骨圧迫と人工呼吸の音声と同時 1つめ　最終的にisStart=falseかtrueか判断する
        //if (isTouch == true && isPush == false && isStart == false) // for debug
        if (FlagManager.Instance.flags[7] == true && isTouch == true && isPush == false && isStart == false)
        {
            CurrentCount = PushCount;//PushCountとCurrentCountを比較する必要があるのでここに書くループ一周目はCurrentCountは0、isCount =true のところでPushCountは1
            StartPosition = hp.ConvertPosition; //共に単位はメートル

            //各種フラグリセット
            isCount = false;
            isGood = false;
            isLate = false;
            isFast = false;

            isStart = true;
        }


        if (isTouch == true && isStart == true && isPush == false && (hp.ConvertPosition.y) <= (StartPosition.y - 0.25f) && (StartPosition.y - 0.30f) < (hp.ConvertPosition.y))//スタート位置のCollisionにふれていて、5cm-6cm沈み込んだらフラグをたてる、-0.25=-0.05*5,-0.30=-0.06*5なのはLeapHandControllerのScaleが5なため
        {
            isPush = true;
        }


        if (isTouch == true && isStart == true && isPush == true && isCount == false)  //5cm押し込んでいる、かつスタート位置のCollisionに再び触れたら
        {
            PushCount++;

            //各種フラグリセット
            isTouch = false;
            isPush = false;
            isStart = false;

            isCount = true;
        }

        TimeCompare();
        TimeJudge();
        if (FlagManager.Instance.flags[7] == true)
        { // Debug.Log(PushCount + "回");
        }
    }//Update終了

    //胸骨圧迫→胸骨圧迫の間隔の時間を取得するクラス
    void TimeCompare()
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
                _tTex.color = new Color(255, 255, 255, 1);//白、不透明
                _tTex.text = "Good";
            }
            if (0.6 < (PushTime - CurrentTime))
            {
                _tTex.color = new Color(255, 255, 255, 1);
                _tTex.text = "Slow";
            }
            if (0.0 < (PushTime - CurrentTime) && (PushTime - CurrentTime) < 0.5)
            {
                _tTex.color = new Color(255, 255, 255, 1);
                _tTex.text = "Fast";
            }
        }

        //テキストの色を透明化、ObjectをDestroyせずに見えないようにするため
        if (isCount == false)
        {
            _tTex.GetComponent<Text>().color = new Color(0, 0, 0, 0);
        }
    }//TimeJudge終了
}//ChestCompression_Tutorial終了