using UnityEngine;
using System.Collections;

public class GetBoxColliderTutorial : MonoBehaviour {

    float StartTimeTutorial = 0.0f;
    float CurrentTimeTutorial = 0.0f;
    bool isStartTimeCountTutorial = false;
    bool isTouchTutorialButton = false;

    public bool canStartTutorial = false;

    LeapHandCollision _hc = new LeapHandCollision();
    // Use this for initialization
    void Start () {
        //Cubeの色変更,Inspector上で変更する方法がわからなかったため
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.black);
    }

    void OnTriggerExit(Collider handmodel)
    {
        isTouchTutorialButton = false;
        StartTimeTutorial = 0.0f;
        CurrentTimeTutorial = 0.0f;
    }

    void OnTriggerEnter(Collider hand)
    {     
        if (_hc.IsHand(hand))
        {
            StartTimeTutorial = Time.time;
            isTouchTutorialButton = true;

        }
    }

    // Update is called once per frame
    void Update () {

        //訓練スタートのためのタイマー
        if (isTouchTutorialButton == true)
        {
            CurrentTimeTutorial = Time.time;
            isStartTimeCountTutorial = true;
        } else
        {
            CurrentTimeTutorial = 0.0f;
        }

        if ((StartTimeTutorial + 2.0f <= CurrentTimeTutorial) && isStartTimeCountTutorial && isTouchTutorialButton == true )
        {
            canStartTutorial = true;

        }

        if(isTouchTutorialButton == false)
        {
            StartTimeTutorial = 0.0f;
            CurrentTimeTutorial = 0.0f;
        }

        Debug.Log(StartTimeTutorial + "StartTimeTutorial");
        Debug.Log(CurrentTimeTutorial + "CurrentTimeTutorial");
    }
}
