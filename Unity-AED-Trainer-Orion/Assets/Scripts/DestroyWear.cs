using UnityEngine;
using System.Collections;


//Todo:AudioSource4,5をWearにアタッチ
public class DestroyWear : MonoBehaviour
{
    GameObject wearChild;
    GameObject openButton;
    public GameObject wearObj;

    public AudioSource AudioSource4;
    public AudioSource AudioSource5;

    public bool isWearDestoroy = false;
    private bool isPlay = false;

    LeapHandCollision hc = new LeapHandCollision();

    void Start()
    {
        openButton = GameObject.Find("開閉ボタン");
        wearChild = GameObject.Find("Wear Object");

        AudioSource[] audioSources = GetComponents<AudioSource>();
        AudioSource4 = audioSources[0];
        AudioSource5 = audioSources[1];

    }


    IEnumerator AudioPlay()
    {
        AudioSource4.Play(12800);
        AudioSource5.Play(138400);

        yield return new WaitForSeconds(3.0f);
        isPlay = false;
    }


    void OnTriggerEnter(Collider obj)
    {
        OpenButton ob = openButton.GetComponent<OpenButton>();
        if (ob.isWearSound == true && hc.IsHand(obj))
        {
            isWearDestoroy = true;
            Destroy(wearChild);
            wearChild = null;
        }
    }


    void Update()
    {
        OpenButton ob = openButton.GetComponent<OpenButton>();
        DestroyWear wb = wearObj.GetComponent<DestroyWear>();
        if (wb.isWearDestoroy == true && ob.isWearSound == true)
        {
            StartCoroutine("AudioPlay");

        } else {

            Debug.Log("isWearDestroy = false");
        }
        //For Debug
        Debug.Log(AudioSource4.isPlaying + "AudioSource4");
        Debug.Log(AudioSource5.isPlaying + "AudioSource5");
    }
}