using UnityEngine;
using System.Collections;


//100-120BPMのノーツの判定を返すクラス
//Todo: 100-120BPMで刻む, 23行目が仕事してないのでデバッグ
public class CompressionCount : MonoBehaviour
{


    ChestCompression cs = new ChestCompression();

    float currentTime; //Unityで時間のカウントをとる変数？

    void Start()
    {
        currentTime = 0.0f;
    }
    void update()
    {

        currentTime += Time.deltaTime;//Time.deltaTimeは一秒　最初にこのUpdateが読み込まれてからスタート
        Debug.Log(currentTime);//時間の加算　0.1fづつ増えてく
        if (currentTime > 1.0)//1.0f毎リセットする→拍子の区切りをつくる
        {
            currentTime = 0.0f;
        }

        JudgeTiming();
    }


    void JudgeTiming()
    {
        if (currentTime < 0.10 && cs.isCount == true)
        { //判定範囲　
            Debug.Log("COOL!");// OK
        }
        else {
            Debug.Log("Bad...");//NG
        }
    }
}
