using UnityEngine;


//HandPosition.csで取得した手のひらの座標をパッドに代入して動かす
public class Pad1Position : MonoBehaviour
{
    public AudioSource AudioSource5;
    public AudioSource AudioSource6;

    private Vector3 pad1Pos;

    public bool pad1col = false;

    LeapHandCollision hc = new LeapHandCollision();

    // Use this for initialization
    void Start()
    {

        //if(ふたがあいていて、二枚のパッドが両方とも貼り付けられていなければ)
        if (FlagManager.Instance.flags[0] == true && FlagManager.Instance.flags[4] == false)
        {
            AudioSource[] audioSources = GetComponents<AudioSource>();

            AudioSource5 = audioSources[0];
            //AudioSource6はパッドが貼られているが、パッドのコネクタが接続されていない場合の
            //音声なので、Attachはするが現状不要なのでコメントアウト
            // AudioSource6 = audioSources[1];

            //(640000 * 3)はおおよそのAudioSorce5の再生時間
            AudioSource5.Play(640000 * 3);
        }
    }

    void OnTriggerEnter(Collider pad1col)
    {
        //if(手がふれていてかつふたが開いているなら)
        if (hc.IsHand(pad1col) && FlagManager.Instance.flags[0] == true)
        {
            FlagManager.Instance.flags[1] = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //if(パッド1に手がふれていてかつパッド1が貼り付けられていなければ)
        if (FlagManager.Instance.flags[1] == true && FlagManager.Instance.flags[2] == false)
        {
            HandPosition handPos = GetComponent<HandPosition>();

            pad1Pos = this.transform.position;

            pad1Pos.x = handPos.ConvertPosition.x;
            pad1Pos.y = handPos.ConvertPosition.y;
            pad1Pos.z = handPos.ConvertPosition.z;

            this.transform.position = pad1Pos;

        }
    }
}
