using UnityEngine;

//CPRAudio_Scenario5は名前空間に既に存在するため、_Scenario"0"5になってます。
public class CPRAudio_Scenario5 : MonoBehaviour {
//具体的にはそれぞれのAudioClipの再生時間を取得してdelayに反映、指定秒数待って再生するやつはタイマー実装してカウント
// for chest complession and announcemennt
    AudioSource AudioSource12;
    AudioSource AudioSource13;
    AudioSource AudioSource14_1;
    AudioSource AudioSource14_2;
    AudioSource AudioSource15;
    AudioSource AudioSource17_1;

    AudioClip AudioClip12;
    AudioClip AudioClip13;
    AudioClip AudioClip14_1;
    AudioClip AudioClip14_2;
    AudioClip AudioClip15;
    AudioClip AudioClip17_1;


    bool isAudio12Played = false;
    bool isAudio13Played = false;
    bool isAudio14_1Played = false;
    bool isAudio14_2Played = false;
    bool isAudio15Played = false;
    bool isAudio16Played = false;


    public bool isTempoSoundLoop_scenario5 = true;

    //他クラスから継承
    ChestCompression _chestCompression;
    uint _pushCount;


    //ForDebug
    AudioSource AudioSource_Debug;

    // Use this for initialization
    void Start()
    {
        _chestCompression = GameObject.Find("ChestComplession").GetComponent<ChestCompression>();


        //音声とりこみ
        AudioSource[] audioSources = GetComponents<AudioSource>();

        AudioSource12 = audioSources[0];
        AudioSource13 = audioSources[1];
        AudioSource14_1 = audioSources[2];
        AudioSource14_2 = audioSources[3];
        AudioSource15 = audioSources[4];
        AudioSource17_1 = audioSources[5];

        AudioClip12 = AudioSource12.clip;
        AudioClip13 = AudioSource13.clip;
        AudioClip14_1 = AudioSource14_1.clip;
        AudioClip14_2 = AudioSource14_2.clip;
        AudioClip15 = AudioSource15.clip;
        AudioClip17_1 = AudioSource17_1.clip;

        //ForDebug
        AudioSource_Debug = audioSources[6];

    }

    void Update()
    {
        AudioDebug();

        if (FlagManager.Instance.flags[7] == true)
        {
            CPRAnnounceLoop_Scenario5();

            if ((_chestCompression.PushCount == _pushCount + 5) && isAudio14_2Played == false && isAudio16Played == false && AudioSource12.isPlaying == false && AudioSource13.isPlaying == false && AudioSource14_1.isPlaying == false)
            {
                AudioSource14_2.PlayDelayed(AudioClip14_1.length); //体から離れてください     
                isAudio14_2Played = true;
                isTempoSoundLoop_scenario5 = false;

            }
            if (isAudio14_2Played == true && AudioSource14_2.isPlaying == false && isAudio15Played == false)
            {
                AudioSource15.PlayDelayed(AudioClip14_2.length);//心電図を調べています、体に触らないでください  
                isAudio15Played = true;
            }

            if (isAudio15Played == true && AudioSource15.isPlaying == false && isAudio16Played == false)
            {
                AudioSource17_1.PlayDelayed(0.0f);//心電図を調べることができませんでした

                //CPRAnnounceLoopの各種フラグリセット
                isAudio12Played = false;
                isAudio13Played = false;
                isAudio14_1Played = false;

                isAudio16Played = true; //Update()内で1フレーム毎に実行されるの防ぐ用、if{}内が実行されるのは一度きりになる
            }

            if (isAudio15Played == true && isAudio16Played == true && AudioSource15.isPlaying == false && AudioSource17_1.isPlaying == false)
            {
                CPRAnnounceLoop_Scenario5();
            }
        }
    }

    void AudioDebug()
    {
        //Debug用コード書くところ
    }

    public void CPRAnnounceLoop_Scenario5()
    {
        double announceTime = 0.0;


        if (isAudio12Played == false)
        {
            //flags[5]→[7]が連続して処理されるので、AudioSource12の再生時間をAudioSource7,8,16の時間分遅延させる必要がある、最後の4.0fは音声の再生に間をもたせるため
            AudioSource12.PlayDelayed(AudioClip17_1.length + 4.0f); //体にさわっても大丈夫です、直ちに胸骨圧迫と人工呼吸を始めてください
            announceTime = Time.time;

            isAudio12Played = true;
            isTempoSoundLoop_scenario5 = true;
        }

        if (isAudio12Played == true && AudioSource12.isPlaying == false && isAudio13Played == false)
        {
            AudioSource13.PlayDelayed(0.0f); //胸骨圧迫と人工呼吸を続けてください、2分間、30秒ごとループ
            isAudio13Played = true;
        }

        if (isAudio13Played == true && AudioSource13.isPlaying == false && isAudio14_1Played == false)
        {
            AudioSource14_1.PlayDelayed(0.0f);//残り5回です

            _pushCount = _chestCompression.PushCount;//PushCountが5回押されたか判定する用
            isAudio14_1Played = true;
        }
    }
}