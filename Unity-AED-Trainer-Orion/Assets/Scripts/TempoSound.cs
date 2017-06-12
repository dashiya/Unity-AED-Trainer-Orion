using UnityEngine;
using System.Collections;

//テンポ100で音を鳴らす、0.5秒毎に音がなる　胸骨圧迫のタイミングのガイド音用
public class TempoSound : MonoBehaviour
{
    AudioSource AudioSource20;
    
    public bool isTempoPlay;

    void Start()
    {     
        AudioSource[] audioSources = this.GetComponents<AudioSource>();
        AudioSource20 = audioSources[0];
      
        AudioSource20.playOnAwake = false;
    }

    void Update()
    {
        //電気ショックが終わったら実行される
        //Todo: この文章だとAudioSource20.loop = true になることでループ再生しているので、他の動作(もう一回電気ショックとか)を行う場合、loop = falseにしなければならない
        //if(FlagManager.Instance.flags[7] == true && isTempoPlay == false)
        if (isTempoPlay == false) // for debug
        {
            double looptime = 0.5;
            AudioSource20.loop = true;
            AudioSource20.PlayScheduled(looptime);

            isTempoPlay = true;            
        }
    }
}
    