using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;


//for chest compression
//手がBox Colliderに触れる→手のy座標をとる→-5cm沈んだらフラグを立てる→フラグが立った状態でBox Colliderにふれたら圧迫回数+1にする
public class ChestCompression : MonoBehaviour
{

    HandPosition hp = new HandPosition();

    LeapHandCollision hc = new LeapHandCollision();


    Vector3 StartPosition;
    private int aIndex;

    // Use this for initialization
    void Start()
    {


    }

    //BoxColliderにふれたときの座標を取得




    // Update is called once per frame
    //StartPosition - 5cmになったらフラグをたてる
    void Update()
    {

        HandPosition hp = GetComponent<HandPosition>();


        Debug.Log(hp.ConvertPosition);



    }


    void OnCollisionEnter(Collision collision)
    {
        if (hc.IsHand(collision))
        {
            for (int aIndex = 0; aIndex < collision.contacts.Length; ++aIndex)
            {
                Debug.Log(collision.contacts[aIndex].point);
            }

            Debug.Log("CPRスタート");
        }
    }


}

