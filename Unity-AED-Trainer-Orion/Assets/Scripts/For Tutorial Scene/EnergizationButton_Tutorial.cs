using UnityEngine;
using System.Collections;

public class EnergizationButton_Tutorial : MonoBehaviour {

    GameObject enebutton;
    Renderer enerend;
    bool isinvoking;
    public AudioSource AudioSource11_Scenario4;

    LeapHandCollision hc = new LeapHandCollision();

    // Use this for initialization
    void Start()
    {
        //音声とりこみ
        AudioSource[] audioSources = this.GetComponents<AudioSource>();
        AudioSource11_Scenario4 = audioSources[0];

        //通電ボタン点滅用の設定

        GameObject enebutton = GameObject.Find("ボタン内側 1");

        enerend = enebutton.GetComponent<Renderer>();
        enerend.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[6] == true && FlagManager.Instance.flags[7] == false)
        {
            Invoke("enebuttonblink", 20);
        }
    }

    void enebuttonblink()
    {
        // Find out whether current second is odd or even
        bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;

        // Enable renderer accordingly
        enerend.enabled = oddeven;
    }

    void OnTriggerEnter(Collider enecol)
    {
        //if(手が触れていてかつ音声がすべて再生すみなら)
        if (hc.IsHand(enecol) && FlagManager.Instance.flags[6] == true && FlagManager.Instance.flags[7] == false)
        {
            AudioSource11_Scenario4.Play(12800);//電気ショックを行いました
            FlagManager.Instance.flags[7] = true; 
            FlagManager.Instance.flags[27] = true;//AutoMoveSpotlightへ 
        }
    }
}