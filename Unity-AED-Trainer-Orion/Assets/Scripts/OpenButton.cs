using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class OpenButton : MonoBehaviour
{
    //変数
    public GameObject obj;
    public GameObject wearObj;

    //回転角度
    private float angle = 180f;
    //回転の中心
    private Vector3 targetPos;

    public AudioSource AudioSource1;
    public AudioSource AudioSource2;
    public AudioSource AudioSource3;
    public AudioSource AudioSource4;
    public AudioSource AudioSource5;

    public bool isWearSound = false;
    private bool isPlay = false;
    private bool isPlayFlag = false;

    LeapHandCollision hc = new LeapHandCollision();



    void Start()
    {
        //flagmanager初期化
        FlagManager.Instance.ResetFlags();

        //音声とり込み
        AudioSource[] audioSources = GetComponents<AudioSource>();

        AudioSource1 = audioSources[0];
        AudioSource2 = audioSources[1];
        AudioSource3 = audioSources[2];
        AudioSource4 = audioSources[3];
        AudioSource5 = audioSources[4];


        obj = GameObject.Find("ふた");
        wearObj = GameObject.Find("Wear");
        Transform target = GameObject.Find("RotationTarget").transform;
        targetPos = target.position;


    }

    //otherは衝突相手（この場合は手）のデータが入る
    void OnTriggerEnter(Collider other)
    {

        if (FlagManager.Instance.flags[0] == false && hc.IsHand(other))
        {

            //axisの場所情報
            Vector3 axis = transform.TransformDirection(Vector3.left);
            // Spin the object around the Cube at 180 degrees
            obj.gameObject.transform.RotateAround(targetPos, axis, angle);



            //ふたが開いている状態のフラグを立てる
            FlagManager.Instance.flags[0] = true;

            isPlayFlag = true;

        }
    }






    void Update()
    {
        DestroyWear wb = wearObj.GetComponent<DestroyWear>();

        if (isPlayFlag == true | isPlay == true)
        {
            //audiosource再生
            AudioSource1.Play(12800);
            AudioSource2.Play(138400);
            AudioSource3.Play(12800 + 138400 * 2);
            isWearSound = true;
            if (wb.isWearDestoroy == true)  //このじょうけんがみたされない
            {
                AudioSource4.Play(12800 + 138400 * 4);
                AudioSource5.Play(12800 + 138400 * 6);
                Debug.Log("isWearDestroy = true");

                isPlay = false;
            } else if (wb.isWearDestoroy == false)
            {
                Debug.Log("isWearDestroy = false");
            }

            //isPlayFlag = false;

        }
    }

}



