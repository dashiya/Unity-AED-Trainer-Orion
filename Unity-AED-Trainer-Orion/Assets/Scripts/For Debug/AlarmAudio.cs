using UnityEngine;
using System.Collections;

public class AlarmAudio : MonoBehaviour
{

    public AudioSource AudioAlarm;
    public AudioClip alarmclip;


    // Use this for initialization
    void Start()
    {

        //音声とりこみ
        AudioSource[] audioSources = GetComponents<AudioSource>();

        AudioAlarm = audioSources[0];

       
    }

    // Update is called once per frame
    void Update()
    {

        //if(蓋が開いていて両方のパッドが貼り付けられるまで) アラーム音をループさせる

        if (FlagManager.Instance.flags[0] == true && FlagManager.Instance.flags[4] == false)
        {

            StartCoroutine("AlarmPlay");

        }
    }

    //Update関数だと処理落ちするのでコルーチンで処理
    //アラーム音をループさせる
    IEnumerator AlarmPlay()
    {
        alarmclip = AudioAlarm.clip;
       
       AudioAlarm.PlayOneShot(alarmclip);
       yield return new WaitForSeconds(3f);
        

    }


}
