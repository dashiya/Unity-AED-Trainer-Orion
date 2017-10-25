using UnityEngine;
using System.Collections;

public class DestroyWear_Tutorial : MonoBehaviour {

    OpenButton_Tutorial _openButtonTutorial;
    GameObject _wearObj;
    DestroyWear_Tutorial _destroyWearTutorial;

    public AudioSource AudioSource4;
    public AudioSource AudioSource5;

    public bool isWearDestoroy = false;
    bool isPlay = false;

    //LeapHandCollisionは取得した手全体を当たり判定として用いるクラス
    LeapHandCollision _hc = new LeapHandCollision();

    void Start()
    {
        _openButtonTutorial = GameObject.Find("開閉ボタン").GetComponent<OpenButton_Tutorial>();
        _wearObj = GameObject.Find("Wear Object");
        _destroyWearTutorial = GetComponent<DestroyWear_Tutorial>();


        AudioSource[] audioSources = GetComponents<AudioSource>();
        AudioSource4 = audioSources[0];
        AudioSource5 = audioSources[1];
    }


    void OnTriggerEnter(Collider obj)
    {
        if (_openButtonTutorial.isWearSound == true && _hc.IsHand(obj))
        {
            Destroy(_wearObj);
            isWearDestoroy = true;
        }
    }


    void Update()
    {
        if (_destroyWearTutorial.isWearDestoroy == true && _openButtonTutorial.isWearSound == true && isPlay == false)
        {
            AudioSource4.Play(12800);//袋を破いてパッドを取り出してください
            AudioSource5.Play(138400);//パッドを青いシートから剥がして、図のように右胸と左脇腹に貼ってください　
            isPlay = true;
        }
    }
}