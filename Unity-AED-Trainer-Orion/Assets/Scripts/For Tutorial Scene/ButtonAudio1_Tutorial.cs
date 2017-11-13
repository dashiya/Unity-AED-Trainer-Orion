using UnityEngine;
using System.Collections;

public class ButtonAudio1_Tutorial : MonoBehaviour {

    public AudioSource AudioSource7;
    public AudioSource AudioSource8;
    public AudioSource AudioSource9;

    AudioClip AudioClip7;
    AudioClip AudioClip8;
    AudioClip AudioClip9;

    // Use this for initialization
    void Start()
    {
        //音声とりこみ
        AudioSource[] audioSources = GetComponents<AudioSource>();
        AudioSource7 = audioSources[0];
        AudioSource8 = audioSources[1];
        AudioSource9 = audioSources[2];

        AudioClip7 = AudioSource7.clip;
        AudioClip8 = AudioSource8.clip;
        AudioClip9 = AudioSource9.clip;
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
            AudioSource9.PlayDelayed(AudioClip7.length + AudioClip8.length + AudioClip9.length + 2.0f);//電気ショックが必要です、充電しています

            FlagManager.Instance.flags[5] = true;

        }
    }
}
