using UnityEngine;
using System.Collections;
using System;

public class ButtonAudio2 : MonoBehaviour
{


    public AudioSource AudioSource10;


    // Use this for initialization
    void Start()
    {

        //音声とりこみ
        AudioSource[] audioSources = this.GetComponents<AudioSource>();

        AudioSource10 = audioSources[0];


    }



    // Update is called once per frame
    void Update()
    {


        //if(充電が完了して通電ボタンが押されていなければ)
        if (FlagManager.Instance.flags[5] == true && FlagManager.Instance.flags[6] == false)
        {

            AudioSource10.Play(138400 * 6);

            FlagManager.Instance.flags[6] = true;

        }


    }

}
