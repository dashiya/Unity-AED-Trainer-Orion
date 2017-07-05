using UnityEngine;
using System.Collections;

//Todo:"残り5回です"の音声が流れた後、ChestCompression.PushCountが+5されたら次の音声が流れるように
//Todo:PushCountの判定処理追加する
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

    float timeProgress;
    bool isFirstPlayed = false;
    bool isSecondPlayed = false;

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
        AudioSource15 = audioSources[3];
        AudioSource16 = audioSources[4];
        AudioSource17 = audioSources[5];
        AudioSource18 = audioSources[6];
        AudioSource19 = audioSources[7];
        AudioSource14_2 = audioSources[8];
    }


    // Update is called once per frame
    void Update()
    {
        ulong time = 128 * 100 * 22;
        ulong delaytime = 128 * 100 * 30;

        if (FlagManager.Instance.flags[7] == true)
        {
            if (isFirstPlayed == false)
            {
                AudioSource12.Play(delaytime);

                AudioSource13.Play(delaytime + time * 2);
                AudioSource13.Play(delaytime + time * 3);
                AudioSource13.Play(delaytime + time * 4);
                AudioSource14_1.Play(delaytime + time * 5);
                isFirstPlayed = true;
            }

            if (/*PushCountが5つ増えたら*/)
            {
                AudioSource14_2.Play(delaytime + time * 6);

                AudioSource15.Play(delaytime + time * 7);
                AudioSource15.Play(delaytime + time * 8);

                AudioSource16.Play(delaytime + time * 9);

                AudioSource17.Play(delaytime + time * 10);

                AudioSource18.Play(delaytime + time * 11);
                AudioSource18.Play(delaytime + time * 12);

                AudioSource19.Play(delaytime + time * 13);

                isSecondPlayed = true;
            }
        }
    }
}