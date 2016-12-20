using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;


//for chest compression
//手がBox Colliderに触れる→手のy座標をとる→-5cm沈んだらフラグを立てる→フラグが立った状態でBox Colliderにふれたら圧迫回数+1にする
public class ChestCompression : MonoBehaviour
{

    public Vector3 StartPosition;
    public int PushCount = 0;

    private bool isTouch = false;
    private bool isPush = false;
    private bool isStart = false;

    private int aIndex;

    HandPosition hp = new HandPosition();

    LeapHandCollision hc = new LeapHandCollision();





    //otherは衝突相手（この場合は手）のデータが入る
    void OnTriggerEnter(Collider other)
    {

        if (FlagManager.Instance.flags[0] == false && hc.IsHand(other))
        {


            if (hc.IsHand(other))
            {
                isTouch = true;

                Debug.Log("1つめ");

            }
        }
    }



    // Use this for initialization
    void Start()
    { }

    // Update is called once per frame
    //StartPosition - 5cmになったらフラグをたてる
    void Update()
    {

        HandPosition hp = GetComponent<HandPosition>();

        if (isTouch == true && isPush == false && isStart == false) //これがループしてない→isStart = trueのままになっている
        {
            StartPosition = hp.ConvertPosition;
            Debug.Log("2つめ");
            Debug.Log((StartPosition.y - 0.05) + "触れたときの座標-5cm" + (hp.ConvertPosition.y) + "今の座標");
            isStart = true;
        }

        if (isStart == true && (StartPosition.y - 0.05) >= (hp.ConvertPosition.y))//スタート位置のCollisionにふれていて、5cm沈み込んだら
        {
            isPush = true;
            Debug.Log("3つめ");
        }

        if (isTouch == true && isPush == true )  //スタート位置のCollisionにふれていて、5cm押し込んでいる
        {
            PushCount++;
            isTouch = false;
            isPush = false;
            isStart = false;
            Debug.Log("4つめ");
            Debug.Log(PushCount + "pushcount");
        }

    }
    
}

