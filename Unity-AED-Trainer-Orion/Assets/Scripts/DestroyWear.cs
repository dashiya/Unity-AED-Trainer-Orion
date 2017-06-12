using UnityEngine;
using System.Collections;


public class DestroyWear : MonoBehaviour
{
    GameObject openButton;
    public GameObject wearObj;

    public AudioSource AudioSource4;
    public AudioSource AudioSource5;

    public bool isWearDestoroy = false;
    bool isPlay = false;

    //LeapHandCollisionは取得した手全体を当たり判定として用いるクラス
    LeapHandCollision hc = new LeapHandCollision();

    void Start()
    {
        openButton = GameObject.Find("開閉ボタン");
        wearObj = GameObject.Find("Wear Object");

        AudioSource[] audioSources = GetComponents<AudioSource>();
        AudioSource4 = audioSources[0];
        AudioSource5 = audioSources[1];
    }


    void OnTriggerEnter(Collider obj)
    {
        OpenButton ob = openButton.GetComponent<OpenButton>();
        if (ob.isWearSound == true && hc.IsHand(obj))
        {
            Destroy(wearObj);
            isWearDestoroy = true;
        }
    }

    void Update()
    {
        OpenButton ob = openButton.GetComponent<OpenButton>();
        DestroyWear wb = this.GetComponent<DestroyWear>();

        if (wb.isWearDestoroy == true && ob.isWearSound == true)
        {
            if (isPlay == false)
            {
                AudioSource4.Play(12800);
                AudioSource5.Play(138400);
                isPlay = true;
            }
        } else {
            //ForDebug
            Debug.Log("isWearDestroy = false");
        }
    }
}