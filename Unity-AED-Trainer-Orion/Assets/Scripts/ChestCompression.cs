using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;


//for chest compression
//手がBox Colliderに触れる→手のy座標をとる→-5cm沈んだらフラグを立てる→フラグが立った状態でBox Colliderにふれたら圧迫回数+1にする
public class ChestCompression : MonoBehaviour {

    HandPosition hp = new HandPosition ();
    Vector StartPosition;

    // Use this for initialization
    void Start () {
	

	}

    //BoxColliderにふれたときの座標を取得


    void OnTriggerEnter(Collider other)
    {
        StartPosition = hp.OriginalPosition;
        Debug.Log(StartPosition);
        Debug.Log("CPRスタート");
    }
    
	
	// Update is called once per frame
    //StartPosition - 5cmになったらフラグをたてる
	void Update () {

        

        

	}
}
