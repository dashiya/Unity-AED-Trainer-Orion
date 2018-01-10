using UnityEngine;
using System.Collections;

public class GetBoxColliderTutorial : MonoBehaviour {

    float  StartTimeTutorial, CurrentTimeTutorial = 0.0f;
    bool isTouchTimeCountTutorial, isTouchTutorialButton = false;

    public bool canStartTutorial = false;

    LeapHandCollision _hc = new LeapHandCollision();
    // Use this for initialization
    void Start () {
        //Cubeの色変更,Inspector上で変更する方法がわからなかったため
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.white);
    }

    void OnTriggerStay(Collider other)
    {
        if (_hc.IsHand(other))
        {
           
             isTouchTutorialButton = true;

        }
    }

    void OnTriggerEnter(Collider hand)
    {      //チュートリアルスタートのためのタイマースタート時間とリセット
        if (_hc.IsHand(hand) && isTouchTutorialButton == true)
        {
            StartTimeTutorial = Time.time;

        }
        if (_hc.IsHand(hand) && isTouchTutorialButton == false)//GetBoxColliderに触れて離してを繰り返すとタイマーが進む問題を解決するため、離すとタイマーがリセットされる
        {
            StartTimeTutorial = 0.0f;
        }
    }

    // Update is called once per frame
    void Update () {

        //訓練スタートのためのタイマー
        if (isTouchTutorialButton == true)
        {
            CurrentTimeTutorial = Time.time;
            isTouchTimeCountTutorial = true;
        }
        if ((StartTimeTutorial + 2.0f <= CurrentTimeTutorial) && isTouchTimeCountTutorial == true)
        {
            canStartTutorial = true;

        }

        Debug.Log(CurrentTimeTutorial + "CurrentTimeTutorial");
    }
}
