using UnityEngine;
using System.Collections;

public class ButtonAudio1 : MonoBehaviour
{
    public AudioSource AudioSource7;
    public AudioSource AudioSource8;
    public AudioSource AudioSource16;

    AudioClip AudioClip7;
    AudioClip AudioClip8;
    AudioClip AudioClip16;

    // Use this for initialization
    void Start()
    {
        //音声とりこみ
        AudioSource[] audioSources = GetComponents<AudioSource>();
        AudioSource7 = audioSources[0];
        AudioSource8 = audioSources[1];
        AudioSource16 = audioSources[2]; //AudioSource9でないのはAudioSource9が「電気ショックを行いました」の音声だから16へ変更

        AudioClip7 = AudioSource7.clip;
        AudioClip8 = AudioSource8.clip;
        AudioClip16 = AudioSource16.clip;
    }

    // Update is called once per frame
    void Update()
    {
        //if(2枚のパッドが両方とも貼付け済みなら)
        if (FlagManager.Instance.flags[4] == true && FlagManager.Instance.flags[5] == false)
        {
            AudioSource7.PlayDelayed(AudioClip7.length);//体に触らないでください
            AudioSource8.PlayDelayed(AudioClip7.length + AudioClip8.length);//心電図を調べています、体に触らないでください
            //最後の2.0fは心電図を調べる様子を示すふりをするための間を持たせるため
            AudioSource16.PlayDelayed(AudioClip7.length + AudioClip8.length + AudioClip16.length + 2.0f);//電気ショックは必要ありません 

            FlagManager.Instance.flags[5] = true;//flags[5]→[6]→[7]はそれぞれの間に音声を流す等の処理が入らない。flags[5]=trueになるとほぼ同時に[7]=trueになる

        }
    }
}
