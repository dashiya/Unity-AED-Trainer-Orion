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

    AudioClip AudioClip12;
    AudioClip AudioClip13;
    AudioClip AudioClip14_1;
    AudioClip AudioClip14_2;
    AudioClip AudioClip15;
    AudioClip AudioClip16;

    int _pushCount;
    bool isFirstPlayed = false;
    bool isSecondPlayed = false;
    bool isAudio13Played = false;
    bool isAudio14Played = false;

    ChestCompression _chestCompression;

    //ForDebug
    AudioSource AudioSource_Debug;

    // Use this for initialization
    void Start()
    {
        _chestCompression = GameObject.Find("ChestComplession").GetComponent<ChestCompression>();

        //音声とりこみ
        AudioSource[] audioSources = this.GetComponents<AudioSource>();

        AudioSource12 = audioSources[0];
        AudioSource13 = audioSources[1];
        AudioSource14_1 = audioSources[2];
        AudioSource14_2 = audioSources[3];
        AudioSource15 = audioSources[4];
        AudioSource16 = audioSources[5];
 
        AudioClip12 = AudioSource12.clip;
        AudioClip13 = AudioSource13.clip;
        AudioClip14_1 = AudioSource14_1.clip;
        AudioClip14_2 = AudioSource14_2.clip;
        AudioClip15 = AudioSource15.clip;
        AudioClip16 = AudioSource16.clip;

        //ForDebug
        AudioSource_Debug = audioSources[6];

    }


    //Todo:AudioSource14_2,15,16が遅延せずほぼ同時に再生されて重なるのを
    void Update()
    {
        AudioDebug();

        if (FlagManager.Instance.flags[7] == true)
        {
            CPRAnnounceLoop();

            if ((_chestCompression.PushCount == _pushCount + 5) && isSecondPlayed == false)
            {
                AudioSource14_2.PlayDelayed(0.0f); //体から離れてください         
                AudioSource15.PlayDelayed(AudioClip14_2.length + AudioClip15.length);//心電図を調べています、体に触らないでください               
                AudioSource16.PlayDelayed(AudioClip14_2.length + AudioClip15.length + AudioClip16.length);//電気ショックは必要ありません  

                isSecondPlayed = true; //Update()内で1フレーム毎に実行されるの防ぐ用、if文の条件を満たして  

                //CPRAnnounceLoopの各種フラグリセット
                isFirstPlayed = false;
                isAudio13Played = false;
                isAudio14Played = false;
            }

            if(isSecondPlayed == true && AudioSource16.isPlaying == false)
            {
                CPRAnnounceLoop();
            }
        }
    }

    void AudioDebug()
    {
        Debug.Log(AudioSource_Debug.isPlaying + "AudioSource_Debug.isPlaying");
        Debug.Log(isAudio13Played + "isAudio13Played");
    }

    public void CPRAnnounceLoop()
    {
        double announceTime = 0.0;

        if (isFirstPlayed == false)
        {
            AudioSource12.PlayDelayed(0.0f); //体にさわっても大丈夫です、直ちに胸骨圧迫と人工呼吸を始めてください
            announceTime = Time.time;
            isFirstPlayed = true;
        }
        if (isFirstPlayed == true && AudioSource12.isPlaying == false && isAudio13Played == false)
        {
            //AudioSource13.PlayDelayed(0.0f); //胸骨圧迫と人工呼吸を続けてください、2分間、30秒ごとループ
            AudioSource_Debug.PlayDelayed(0.0f);//デバッグ用音声だよ
            isAudio13Played = true;
        }

        //if (isAudio13Played == true && AudioSource13.isPlaying == false)
        if (isAudio13Played == true && AudioSource_Debug.isPlaying == false  && isAudio14Played == false)     
        {
            AudioSource14_1.PlayDelayed(0.0f);//残り5回です

            _pushCount = _chestCompression.PushCount;//PushCountが5回押されたか判定する用
            isAudio14Played = true;
        }
    }
}