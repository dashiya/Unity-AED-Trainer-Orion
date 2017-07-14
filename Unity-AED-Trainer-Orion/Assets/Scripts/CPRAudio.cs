using UnityEngine;
using System.Collections;

//Todo:音声周り、正しく再生されるように変更する
//具体的にはそれぞれのAudioClipの再生時間を取得してdelayに反映、指定秒数待って再生するやつはタイマー実装してカウント
// for chest complession and announcemennt
public class CPRAudio : MonoBehaviour
{
    AudioSource AudioSource12;
    AudioSource AudioSource13;
    AudioSource AudioSource14_1;
    AudioSource AudioSource14_2;
    AudioSource AudioSource15;
    AudioSource AudioSource16;
    AudioSource AudioSource17;
    AudioSource AudioSource18;
    AudioSource AudioSource19;

    AudioClip AudioClip12;
    AudioClip AudioClip13;
    AudioClip AudioClip14_1;
    AudioClip AudioClip14_2;
    AudioClip AudioClip15;
    AudioClip AudioClip16;
    AudioClip AudioClip17;
    AudioClip AudioClip18;
    AudioClip AudioClip19;

    int _pushCount;
    bool isFirstPlayed = false;
    bool isSecondPlayed = false;
    bool isAnnounceLoop = false;
    double countAnnounceTime = 0.0;
    ChestCompression _chestCompression;

    // Use this for initialization
    void Start()
    {
        _chestCompression = GameObject.Find("ChestComplession").GetComponent<ChestCompression>();

        //音声とりこみ
        AudioSource[] audioSources = this.GetComponents<AudioSource>();

        AudioSource12 = audioSources[0];
        AudioSource13 = audioSources[1];
        AudioSource14_1 = audioSources[2];
        AudioSource14_2 = audioSources[8];
        AudioSource15 = audioSources[3];
        AudioSource16 = audioSources[4];
        AudioSource17 = audioSources[5];
        AudioSource18 = audioSources[6];
        AudioSource19 = audioSources[7];

        AudioClip12 = AudioSource12.clip;
        AudioClip13 = AudioSource13.clip;
        AudioClip14_1 = AudioSource14_1.clip;
        AudioClip14_2 = AudioSource14_2.clip;
        AudioClip15 = AudioSource15.clip;
        AudioClip16 = AudioSource16.clip;
        AudioClip17 = AudioSource17.clip;
        AudioClip18 = AudioSource18.clip;
        AudioClip19 = AudioSource19.clip;

    }

    //Todo:ループ処理、72行目AudioSource13が再生されない
    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[7] == true )
        {
            CPRAnnounceLoop();

            if ((_chestCompression.PushCount == _pushCount + 5) && isSecondPlayed == false)
            {
              
                AudioSource14_2.PlayDelayed(AudioClip14_2.length); //体から離れてください

                //Todo:102-114行目、forループはできないはずなので修正
                for (int i = 0; i <= 1; i++)
                {
                    AudioSource15.PlayDelayed(AudioClip15.length);//心電図を調べています、体に触らないでください
                }

                AudioSource16.PlayDelayed(AudioClip16.length);//電気ショックは必要ありません

               // CPRAnnounceLoop(); fordebug
            }
        }
    }


  public void CPRAnnounceLoop()
    {

        //fordebug
        Debug.Log(AudioSource12.isPlaying + "AudioSource12.isPlaying");


        double announceTime = 0.0;
        if (isFirstPlayed == false)
        {
            AudioSource12.PlayDelayed(0.0f); //体にさわっても大丈夫です、直ちに胸骨圧迫と人工呼吸を始めてください
            announceTime = Time.time;
            isFirstPlayed = true;
        }

        //タイマー設置、カウントして動かす
        if (isAnnounceLoop == false && isFirstPlayed == true && AudioSource12.isPlaying == false)
        {
            AudioSource13.PlayDelayed(0.0f); //胸骨圧迫と人工呼吸を続けてください、2分間、30秒ごとループ
         

        }
        if (isAnnounceLoop == true && countAnnounceTime <=120.0 )
        {
            AudioSource14_1.PlayDelayed(AudioClip14_1.length);//残り5回です

            _pushCount = _chestCompression.PushCount;

        }

    }
}