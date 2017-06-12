using UnityEngine;

public class OpenButton : MonoBehaviour
{

    Transform coverTransform;
    Vector3 targetPos;
    Vector3 rotateAxis;
    float rotateAngle = 180f;

    public AudioSource AudioSource1;
    public AudioSource AudioSource2;
    public AudioSource AudioSource3;

    public bool isWearSound = false;
    bool isPlayFlag = false;
    bool isPlayAnnounce_3 = false;

    //LeapHandCollisionは取得した手全体を当たり判定として用いるクラス
    LeapHandCollision hc = new LeapHandCollision();

    void Start()
    {
        //flagmanager初期化
        FlagManager.Instance.ResetFlags();

        AudioSource[] audioSources = GetComponents<AudioSource>();
        AudioSource1 = audioSources[0];
        AudioSource2 = audioSources[1];
        AudioSource3 = audioSources[2];

        coverTransform = GameObject.Find("ふた").transform;
        targetPos = GameObject.Find("RotationTarget").transform.position;
    }


    //OpenButtonに手が触れた時の動作
    void OnTriggerEnter(Collider other)
    {
        rotateAxis = transform.TransformDirection(Vector3.left);
        if (FlagManager.Instance.flags[0] == false && hc.IsHand(other))
        {
            coverTransform.RotateAround(targetPos, rotateAxis, rotateAngle);

            //ふたが開いている状態のフラグを立てる
            FlagManager.Instance.flags[0] = true;

            isPlayFlag = true;
        }
    }

    void Update()
    {
        if (isPlayFlag == true)
        {
            //Play()の括弧内の時間は一番最初に再生される音声からの経過時間、音声が重複して流れるのを防ぐため
            //Todo:括弧内を数字記入ではなく、それぞれの再生時間取得とか格好いいやり方に修正
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
    }
}