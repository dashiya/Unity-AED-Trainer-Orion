using UnityEngine;
using System.Collections;

public class ButtonAudio1 : MonoBehaviour
{
    public AudioSource AudioSource7;
    public AudioSource AudioSource8;
    public AudioSource AudioSource16;

    // Use this for initialization
    void Start()
    {
        //音声とりこみ
        AudioSource[] audioSources = GetComponents<AudioSource>();
        AudioSource7 = audioSources[0];
        AudioSource8 = audioSources[1];
        AudioSource16 = audioSources[2]; //AudioSource9でないのはAudioSource9が「電気ショックを行いました」の音声だから16へ変更
    }

    // Update is called once per frame
    void Update()
    {
        //if(2枚のパッドが両方とも貼付け済みなら)
        if (FlagManager.Instance.flags[4] == true && FlagManager.Instance.flags[5] == false)
        {
            AudioSource7.Play(12800); //体に触らないでください
            AudioSource8.Play(138400 * 2);//心電図を調べています、体に触らないでください
            AudioSource16.Play(138400 * 4);//電気ショックは必要ありません

            FlagManager.Instance.flags[5] = true;

        }
    }
}
