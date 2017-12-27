using UnityEngine;
using System.Collections;

public class OpenButton_Tutorial : MonoBehaviour {

   public Transform _coverTransform;

    Vector3 _targetPos;
    Vector3 _rotateAxis;

    float rotateAngle = 180.0f;

    bool isPlayFlag = false;
    bool isPlayAnnounce_3 = false;

    public AudioSource AudioSource1;
    public AudioSource AudioSource2;
    public AudioSource AudioSource3;

    public bool isWearSound = false;

    //LeapHandCollisionは取得した手全体を当たり判定として用いるクラス
    LeapHandCollision _hc = new LeapHandCollision();

    void Start()
    {
        //flagmanager初期化
        FlagManager.Instance.ResetFlags();

        AudioSource[] audioSources = GetComponents<AudioSource>();
        AudioSource1 = audioSources[0];
        AudioSource2 = audioSources[1];
        AudioSource3 = audioSources[2];

        _coverTransform = GameObject.Find("ふた").transform;
        _targetPos = GameObject.Find("RotationTarget").transform.position;
    }


    //OpenButtonに手が触れた時の動作
    void OnTriggerEnter(Collider other)
    {
        _rotateAxis = transform.TransformDirection(Vector3.left);

        if (FlagManager.Instance.flags[0] == false && _hc.IsHand(other))
        {
            _coverTransform.RotateAround(_targetPos, _rotateAxis, rotateAngle);

            //ふたが開いている状態のフラグを立てる
            FlagManager.Instance.flags[0] = true;
            FlagManager.Instance.flags[20] = true;//AutoMoveSpotlightへ

            isPlayFlag = true;
        }
    }


    void Update()
    {

        if (isPlayFlag == true)
        {
            //Play()の括弧内の時間は一番最初に再生される音声からの経過時間、音声が重複して流れるのを防ぐため
            //Todo:括弧内を数字記入ではなく、それぞれの再生時間取得とか格好いいやり方に修正
            AudioSource1.Play(12800);//成人モードです
            AudioSource2.Play(138400);//意識、呼吸を確認してください
            AudioSource3.Play(12800 + 138400 * 2);//胸を裸にして、AEDのふたから四角い袋を取り出してください

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
    }//Updateここまで
}