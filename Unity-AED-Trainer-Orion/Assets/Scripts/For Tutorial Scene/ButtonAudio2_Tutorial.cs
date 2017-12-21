using UnityEngine;
using System.Collections;

public class ButtonAudio2_Tutorial : MonoBehaviour
{
    public AudioSource AudioSource10_Scenario5;

    // Use this for initialization  
    void Start()
    {
        //音声とりこみ
        AudioSource[] audioSources = this.GetComponents<AudioSource>();
        AudioSource10_Scenario5 = audioSources[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[5] == true && FlagManager.Instance.flags[6] == false)
        {
            AudioSource10_Scenario5.Play(138400 * 6);//体から離れてください 点滅ボタンをしっかりと押してください
            FlagManager.Instance.flags[6] = true;
            FlagManager.Instance.flags[26] = true;  //AutoMoveSpotlightへ
        }
    }
}