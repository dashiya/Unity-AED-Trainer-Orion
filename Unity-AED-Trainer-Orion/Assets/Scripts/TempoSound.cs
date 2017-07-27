using UnityEngine;
using System.Collections;

//テンポ100で音を鳴らす、0.5秒毎に音がなる　胸骨圧迫のタイミングのガイド音用
//ToDo:ChestCompressionで胸骨圧迫が終わったら音を止めるように変更
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
        _isTempoSoundLoop = _cprAudio.isTempoSoundLoop;

        //電気ショックが終わったら実行される
        //Todo: AudioSource20.loop = true になることでループ再生しているので、他の動作(もう一回電気ショックとか)を行う場合、loop = falseにしなければならない
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

        DebugSound();
    }

    void DebugSound()
    {
        Debug.Log(_isTempoSoundLoop == true && isTempoPlay == false);
        Debug.Log(_isTempoSoundLoop + "_isTempoSoundLoop");
    }
}
