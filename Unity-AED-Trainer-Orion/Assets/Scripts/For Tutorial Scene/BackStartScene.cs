using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class BackStartScene : MonoBehaviour
{
    MeshRenderer meshrend;

    float StartTimeTutorialEnd = 0.0f;
    float CurrentTimeTutorialEnd = 0.0f;
    bool isStartTimeCountTutorialEnd = false;
    bool isTouchTutorialButtonEnd = false;

    public bool isEndTutorial = false;

    LeapHandCollision _hc = new LeapHandCollision();
    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerExit(Collider handmodel)
    {

        if (FlagManager.Instance.flags[40] == true)
        { isTouchTutorialButtonEnd = false;
            StartTimeTutorialEnd = 0.0f;
            CurrentTimeTutorialEnd = 0.0f;
                }
    }

    void OnTriggerEnter(Collider hand)
    {
        if (_hc.IsHand(hand) && FlagManager.Instance.flags[40] == true)
        {
            StartTimeTutorialEnd = Time.time;
            isTouchTutorialButtonEnd = true;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (FlagManager.Instance.flags[40] == true)
        {
            //訓練スタートのためのタイマー
            if (isTouchTutorialButtonEnd == true)
            {
                CurrentTimeTutorialEnd = Time.time;
                isStartTimeCountTutorialEnd = true;
            } else
            {
                CurrentTimeTutorialEnd = 0.0f;
            }

            if ((StartTimeTutorialEnd + 1.5f <= CurrentTimeTutorialEnd) && isStartTimeCountTutorialEnd && isTouchTutorialButtonEnd == true)
            {
                SceneManager.LoadScene("AEDTrainer-StartScene");//StartSceneよみこみ

            }

            if (isTouchTutorialButtonEnd == false)
            {
                StartTimeTutorialEnd = 0.0f;
                CurrentTimeTutorialEnd = 0.0f;
            }

            Debug.Log(StartTimeTutorialEnd + "StartTimeTutorial");
            Debug.Log(CurrentTimeTutorialEnd + "CurrentTimeTutorial");
        }
    }//Updateここまで
}