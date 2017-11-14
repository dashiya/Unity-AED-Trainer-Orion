using UnityEngine;
using System.Collections;

public class Pad1Position_Tutorial : MonoBehaviour {

    Vector3 _pad1Pos;
    HandPosition _handPos;

    AudioSource AudioSource5;
    AudioSource AudioSource6;

    public bool pad1col = false;

    LeapHandCollision _hc = new LeapHandCollision();

    // Use this for initialization
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        _handPos = GetComponent<HandPosition>();

        //if(ふたがあいていて、二枚のパッドが両方とも貼り付けられていなければ)
        if (FlagManager.Instance.flags[0] == true && FlagManager.Instance.flags[4] == false)
        {
            AudioSource5 = audioSources[0];

            //AudioSource6はパッドが貼られているが、パッドのコネクタが接続されていない場合の
            //音声、コネクタが再現されていない現状では不要なのでコメントアウト
            // AudioSource6 = audioSources[1];

            AudioSource5.Play(640000 * 3); //(640000 * 3)はおおよそのAudioSorce5の再生時間
        }
    }

    void OnTriggerEnter(Collider pad1col)
    {
        if (_hc.IsHand(pad1col) && FlagManager.Instance.flags[0] == true) //if(手がふれていてかつふたが開いているなら)
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
            _pad1Pos = transform.position;

            _pad1Pos.x = _handPos.ConvertPosition.x;
            _pad1Pos.y = _handPos.ConvertPosition.y;
            _pad1Pos.z = _handPos.ConvertPosition.z;

            transform.position = _pad1Pos;
        }
    }
}
