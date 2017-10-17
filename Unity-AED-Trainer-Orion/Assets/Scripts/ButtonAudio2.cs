using UnityEngine;
using System.Collections;
using System;

public class ButtonAudio2 : MonoBehaviour
{
    bool isflagtrue = false;
    private float invokeTimeButtonAudioTwo = 5.0f;
    //点滅ボタンを押す動作をシナリオ1では行わないのでAudioSource10を再生するコードを消去
    void Update()
    {
        if (FlagManager.Instance.flags[5] == true && isflagtrue == false)
        {
            Invoke("TrueFlagSeven", invokeTimeButtonAudioTwo);
            
        }
    }

    void TrueFlagSeven()
    {
        FlagManager.Instance.flags[7] = true;
        isflagtrue = true;
    }
}
