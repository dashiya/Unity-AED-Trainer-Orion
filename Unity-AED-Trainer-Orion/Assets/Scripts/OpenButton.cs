using UnityEngine;

public class OpenButton : MonoBehaviour
{

    //ふたの回転角度
    private float rotateAngle = 180f;
    //回転の中心
    private Vector3 targetPos;
    Transform coverTransform;

    public AudioSource AudioSource1;
    public AudioSource AudioSource2;
    public AudioSource AudioSource3;

    public bool isWearSound = false;
    private bool isPlayFlag = false;
    private bool isPlayAnnounce_3 = false;

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
        Vector3 rotateAxis = transform.TransformDirection(Vector3.left);
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