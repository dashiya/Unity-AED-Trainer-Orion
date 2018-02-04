using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//BackStartSceneColliderの色の管理はAutoMoveSpotlight最終行あたりに記述
public class BackStartScene : MonoBehaviour
{
    //タイマーとフラグ用変数
    float StartTimeTutorialEnd = 0.0f;
    float CurrentTimeTutorialEnd = 0.0f;
    bool isStartTimeCountTutorialEnd = false;
    bool isTouchTutorialButtonEnd = false;


    //色の変更用
    MeshRenderer BackStartSceneColliderMesh;

    //被験者実験用
    AutoMoveSpotlight _autoMoveSpotlight;


    LeapHandCollision _hc = new LeapHandCollision();
    // Use this for initialization
    void Start()
    {
        //色変更用
        BackStartSceneColliderMesh = this.GetComponent<MeshRenderer>();

        this.GetComponent<BoxCollider>().enabled = false;
    }

    void OnTriggerExit(Collider handmodel)
    {

        if (FlagManager.Instance.flags[40] == true)
        {
            //Colliderから手が離れたらフラグ、数値リセット
            isTouchTutorialButtonEnd = false;
            StartTimeTutorialEnd = 0.0f;
            CurrentTimeTutorialEnd = 0.0f;

            BackStartSceneColliderMesh.material.color = Color.white;//BackStartSceneのTextの色を白、不透明に
        }
    }

    void OnTriggerEnter(Collider hand)
    {
        if (_hc.IsHand(hand) && FlagManager.Instance.flags[40] == true)
        {
            BackStartSceneColliderMesh.material.color = Color.black;//BackStartSceneのTextの色を黒、不透明に
            StartTimeTutorialEnd = Time.time;
            isTouchTutorialButtonEnd = true;
        } else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagManager.Instance.flags[40] == true)
        {

            this.GetComponent<BoxCollider>().enabled = true;
            //訓練スタートのためのタイマー
            if (isTouchTutorialButtonEnd == true)
            {
                CurrentTimeTutorialEnd = Time.time;//タイマースタート
                isStartTimeCountTutorialEnd = true;
            } else
            {
                StartTimeTutorialEnd = 0.0f;
                CurrentTimeTutorialEnd = 0.0f;//条件を満たさなければタイマーリセット
            }

            if ((StartTimeTutorialEnd + 1.5f <= CurrentTimeTutorialEnd) && isStartTimeCountTutorialEnd == true && isTouchTutorialButtonEnd == true)//1.5秒以上経過してかつBackStartSceneに触れている
            {
                SceneManager.LoadScene("AEDTrainer-StartScene");//StartSceneよみこみ

            }
        }
    }//Updateここまで
}