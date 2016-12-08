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

    private bool isTouch = false;
    private int aIndex;

    HandPosition hp = new HandPosition();

    LeapHandCollision hc = new LeapHandCollision();




    // Use this for initialization
    void Start()
    {


    }






    // Update is called once per frame
    //StartPosition - 5cmになったらフラグをたてる
    void Update()
    {



        HandPosition hp = GetComponent<HandPosition>();

        if (isTouch == true)
        {
            Debug.Log("Convertposition" + hp.ConvertPosition);
            isTouch = false;
        }

        Debug.Log(isTouch);


    }




    //otherは衝突相手（この場合は手）のデータが入る
    void OnTriggerEnter(Collider other)
    {

        if (FlagManager.Instance.flags[0] == false && hc.IsHand(other))
        {


            if (hc.IsHand(other))
            {
                isTouch = true;

            }

            Debug.Log("CPRスタート");
        }


    }
}


