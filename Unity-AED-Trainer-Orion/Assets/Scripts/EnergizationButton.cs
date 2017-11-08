using UnityEngine;
using System.Collections;

//Todo:flag[7]はtrueにしないと後の処理が動かないので、その他のボタン点滅、AudioSource11の再生をオフにする
public class EnergizationButton : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //ButtonAudio2.csでflags[7]にすればEnagizationButton丸々いりませんが、flagsを順番にtrueにしていきたいので記述
        if(FlagManager.Instance.flags[6] == true)
        {
            FlagManager.Instance.flags[7] = true;
        }
    }
}