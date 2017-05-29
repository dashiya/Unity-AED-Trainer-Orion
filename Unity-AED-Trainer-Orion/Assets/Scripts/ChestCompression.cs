using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;
using UnityEngine.UI;


//for chest compression
//手がBox Colliderに触れるisTouch=true→手のy座標をとる→-5cm沈んだらフラグを立てる→フラグが立った状態でBox Colliderにふれたら圧迫回数+1にするisCount = true

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

    private int aIndex;

    public float PushTime = 0f;
    public float CurrentTime = 0f;


    Text tTex;
    Text hpTex;

    MeshRenderer tTexMesh;

    LeapHandCollision hc = new LeapHandCollision();
    //  HandPosition hp = new HandPosition();




    //otherは衝突相手（この場合は手）のデータが入る
    void OnTriggerEnter(Collider other)
    {
        if (FlagManager.Instance.flags[7] == true && hc.IsHand(other))
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
        hpTex = GameObject.Find("ChestComplession").GetComponent<Text>();


    }

    // Update is called once per frame
    //StartPosition - 5cmになったらフラグをたてる
    void Update()
    {
        HandPosition hp = GetComponent<HandPosition>();

        //flags[7]は電気ショックが終わったらtrueになる、胸骨圧迫と人工呼吸の音声と同時
        if (FlagManager.Instance.flags[7] == true && isTouch == true && isPush == false && isStart == false)
        // if (isTouch == true && isPush == false && isStart == false)
        {
            CurrentCount = PushCount;//PushCountとCurrentCountを比較する必要があるのでここに書く、場所があってるか不明 ループ一周目はCurrentCountは0、isCount =true のところでPushCountは1
            CurrentTime = Time.time;
            StartPosition = hp.ConvertPosition;

            //各種フラグリセット
            isCount = false;
            isGood = false;
            isLate = false;
            isFast = false;

            isStart = true;

        }

        if (isTouch == true && isStart == true && (StartPosition.y - 0.05) >= (hp.ConvertPosition.y))//スタート位置のCollisionにふれていて、5cm沈み込んだらフラグをたてる
        {
            isPush = true;
        }

        if (isTouch == true && isPush == true && isCount == false)  //5cm押し込んでいる、かつスタート位置のCollisionに再び触れたら
        {
            PushCount++;
            PushTime = Time.time;

            //各種フラグリセット
            isTouch = false;
            isPush = false;
            isStart = false;

            Debug.Log(PushTime - CurrentTime);

            isCount = true;

            Debug.Log(PushTime + "     " + CurrentTime);

        }

        TimeJudge();
 
    }

    //圧迫するタイミングの判断
    void TimeJudge()
    {

        Debug.Log(PushCount + "回");

        if (0.5 <= (PushTime - CurrentTime) && (PushTime - CurrentTime) <= 0.6)
        {
            tTex.color = new Color(255, 255, 255, 1);
            tTex.text = "Good";

        } else if (0.6 < (PushTime - CurrentTime))
        {
            tTex.color = new Color(255, 255, 255, 1);
            tTex.text = "Late";

        } else if (0.0 < (PushTime - CurrentTime) && (PushTime - CurrentTime) < 0.5)
        {
            tTex.color = new Color(255, 255, 255, 1);
            tTex.text = "Fast";
        }


        if (isCount == false)
        {
            tTex.GetComponent<Text>().color = new Color(0, 0, 0, 0);
        }

    }


    void PushDepth()
    {

    }

    


}

