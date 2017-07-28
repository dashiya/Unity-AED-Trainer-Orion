using UnityEngine;
using System.Collections;
using System;

public class ButtonAudio2 : MonoBehaviour
{
   //点滅ボタンを押す動作をシナリオ1では行わないのでAudioSource10を再生するコードを消去
    void Update()
    {
        if (FlagManager.Instance.flags[5] == true && FlagManager.Instance.flags[6] == false)
        {
            FlagManager.Instance.flags[6] = true;
        }
    }
}
