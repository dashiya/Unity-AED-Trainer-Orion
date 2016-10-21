using UnityEngine;
using System.Collections;

public class ButtonAudio1 : MonoBehaviour
{

    public AudioSource AudioSource7;
    public AudioSource AudioSource8;
    public AudioSource AudioSource9;

    // Use this for initialization
    void Start()
    {

        //音声とりこみ
        AudioSource[] audioSources = GetComponents<AudioSource>();

        AudioSource7 = audioSources[0];
        AudioSource8 = audioSources[1];
        AudioSource9 = audioSources[2];
    }

    // Update is called once per frame
    void Update()
    {

        //if(2枚のパッドが両方とも貼付け済みなら)
        if (FlagManager.Instance.flags[4] == true && FlagManager.Instance.flags[5] == false)
        {
            AudioSource7.Play(12800);

            AudioSource8.Play(138400 * 2);

            AudioSource9.Play(138400 * 4);



            Debug.Log("充電完了");
            FlagManager.Instance.flags[5] = true;

        }
    }
}
