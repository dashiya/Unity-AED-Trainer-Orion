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
        if(FlagManager.Instance.flags[7] == true && isTempoPlay == false)
        {
            double looptime = 0.5;
            AudioSource20.loop = true;
            AudioSource20.PlayScheduled(looptime);

            isTempoPlay = true;            
        }
    }
}
    