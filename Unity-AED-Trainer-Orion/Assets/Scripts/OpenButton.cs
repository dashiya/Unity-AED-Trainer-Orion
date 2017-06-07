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
    private bool isPlayFirst = false;
    private bool isPlayAnnounce_3 = false;

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



    IEnumerator AudioPlay()
    {

        AudioSource4.Play(12800 + 138400 * 4);
        AudioSource5.Play(12800 + 138400 * 6);

        Debug.Log("isWearDestroy = true");
        yield return new WaitForSeconds(5.0f);
        isPlay = false;
    }


    //OpenButtonに手が触れた時の動作
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

        if (isPlayFlag == true)
        {
            //audiosource再生
            AudioSource1.Play(12800);
            AudioSource2.Play(138400);
            AudioSource3.Play(12800 + 138400 * 2);

            isPlayFlag = false; 
        }

        //AudioSource3の再生→再生終了　を調べる
        if (AudioSource3.isPlaying == true)
        {
            isPlayAnnounce_3 = true;
        }
        if (isPlayAnnounce_3 == true && AudioSource3.isPlaying == false)
        {
            isWearSound = true;
        }

        //WearがDestroyされて、AudioSource3が再生→再生終了されているなら
        if (wb.isWearDestoroy == true && isWearSound == true)  //ここから
        {
            StartCoroutine("AudioPlay");

        } else {
            Debug.Log("isWearDestroy = false"); //ここまでがupdate内で複数回判定されないので修正、おそらくフラグ周り
        }


        Debug.Log(AudioSource4.isPlaying + "AudioSource4");
        Debug.Log(AudioSource5.isPlaying + "AudioSource5");
        Debug.Log(wb.isWearDestoroy + "wb.isWearDestoroy");

    }
}





