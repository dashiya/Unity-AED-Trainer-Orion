using UnityEngine;
using System.Collections;


//Cubeに一定時間触れたかどうかの判定をする→RandomChangeScene(訓練),StartTutorialScene(チュートリアル)へ分岐
public class GetBoxCollider : MonoBehaviour
{
    float StartTime = 0.0f;
    float CurrentTime = 0.0f;
    bool isStartTimeCount = false;
    bool isTouchStartButton = false;
    MeshRenderer meshrend;
    public bool canRandomChangeScene = false;

    LeapHandCollision _hc = new LeapHandCollision();
    // Use this for initialization
    void Start()
    {
        meshrend = GetComponent<MeshRenderer>();
        meshrend.material.color = Color.white;

    }

    void OnTriggerExit(Collider exithand)
    {
        meshrend.material.color = Color.white;
        isTouchStartButton = false;
            StartTime = 0.0f;
            CurrentTime = 0.0f;
        

    }

    void OnTriggerEnter(Collider hand)
    {
        if (_hc.IsHand(hand))
         {
            meshrend.material.color = Color.black;
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
            isStartTimeCount = true;
        } else {
            CurrentTime = 0.0f;
        }

        if ((StartTime + 1.5f <= CurrentTime) && isStartTimeCount == true && isTouchStartButton == true)
        {
            canRandomChangeScene = true;//RandomChangeSceneへ

        }

        if ( isTouchStartButton == false)//GetBoxColliderに触れて離してを繰り返すとタイマーが進む問題を解決するため、離すとタイマーがリセットされる
        {
            StartTime = 0.0f;
            CurrentTime = 0.0f;
        }

        //Debug.Log(StartTime + "StartTime");
       // Debug.Log(CurrentTime + "CurrentTime");
    }
}