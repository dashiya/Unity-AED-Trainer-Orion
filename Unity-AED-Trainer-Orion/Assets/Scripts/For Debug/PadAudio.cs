//次→PadAudioSouce を作ってフォルダ内に入れる
//OpenButton.cs内OpenCover=trueの時音を鳴らしたい

using UnityEngine;
using System.Collections;

public class PadAudio : MonoBehaviour
{

    public AudioClip audioClip;
    AudioSource PadAudioSource;


    void Start()
    {
        PadAudioSource = gameObject.GetComponent<AudioSource>();

    }

    void Update()
    {
        //OpenButton.csの参照
        OpenButton open = GetComponent<OpenButton>();

        //OpenButtonから手が電源ボタンに触れているかどうかの変数OpenCoverをとってくる
        if (open == true)
        {

            // Torigger
            Debug.Log("パッドを取り出して～ の音声");
            PadAudioSource.Play();
        }
    }
}