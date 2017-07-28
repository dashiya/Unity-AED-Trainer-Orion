using UnityEngine;
using System.Collections;

//テンポ100で音を鳴らす、0.5秒毎に音がなる　胸骨圧迫のタイミングのガイド音用
public class TempoSound : MonoBehaviour
{
    AudioSource AudioSource20;
    public bool isTempoPlay = false;

    //他クラスから継承
    public bool _isTempoSoundLoop;
    CPRAudio _cprAudio;

    void Start()
    {
        _cprAudio = GameObject.Find("CPRAudio").GetComponent<CPRAudio>();

        AudioSource[] audioSources = GetComponents<AudioSource>();
        AudioSource20 = audioSources[0];
    }

    void Update()
    {
        _isTempoSoundLoop = _cprAudio.isTempoSoundLoop; //_isTempoSoundLoopの中身をCPRAudio.isTempoSoundLoopから参照して更新する用

        //電気ショックが終わったら実行される
        if (_isTempoSoundLoop == true && isTempoPlay == false)
        {
            double looptime = 0.5;
            AudioSource20.PlayScheduled(looptime);
            AudioSource20.loop = true;
            isTempoPlay = true;

        }
        if (_isTempoSoundLoop == false)
        {
            AudioSource20.loop = false;
            isTempoPlay = false;
        }
    }
}
