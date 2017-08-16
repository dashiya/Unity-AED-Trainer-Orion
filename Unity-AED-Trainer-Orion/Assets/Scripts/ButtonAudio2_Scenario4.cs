using UnityEngine;
using System.Collections;
using System;

public class ButtonAudio2_Scenario4 : MonoBehaviour
{
    public AudioSource AudioSource10_Scenario4;

    // Use this for initialization
    void Start()
    {
        //音声とりこみ
        AudioSource[] audioSources = this.GetComponents<AudioSource>();
        AudioSource10_Scenario4 = audioSources[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[5] == true && FlagManager.Instance.flags[6] == false)
        {
            AudioSource10_Scenario4.Play(138400 * 6);
            FlagManager.Instance.flags[6] = true;
        }
    }
}
