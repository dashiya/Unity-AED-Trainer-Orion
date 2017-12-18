using UnityEngine;
using System.Collections;


public class DestroyWear : MonoBehaviour
{
    OpenButton _openButton;
    GameObject _wearObj;
    DestroyWear _destroyWear;

    public AudioSource AudioSource4;
    public AudioSource AudioSource5;

    public bool isWearDestoroy = false;
    bool isPlay = false;

    //LeapHandCollisionは取得した手全体を当たり判定として用いるクラス
    LeapHandCollision _hc = new LeapHandCollision();

    void Start()
    {
        _openButton = GameObject.Find("開閉ボタン").GetComponent<OpenButton>();
        _wearObj = GameObject.Find("Wear Object");
        _destroyWear = GetComponent<DestroyWear>();


        AudioSource[] audioSources = GetComponents<AudioSource>();
        AudioSource4 = audioSources[0];
        AudioSource5 = audioSources[1];
    }


    void OnTriggerEnter(Collider obj)//服objに触れたら服を消す
    {
        if (_openButton.isWearSound == true && _hc.IsHand(obj))
        {
            Destroy(_wearObj);
            isWearDestoroy = true;
        }
    }


    void Update()
    {
        if (_destroyWear.isWearDestoroy == true && _openButton.isWearSound == true && isPlay == false)
        {
            AudioSource4.Play(12800);//袋を破いてパッドを取り出してください
            AudioSource5.Play(138400);//パッドを青いシートから剥がして、図のように右胸と左脇腹に貼ってください　
            isPlay = true;
            
        }
    }
}