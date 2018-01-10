using UnityEngine;
using System.Collections;


//Cubeに一定時間触れたかどうかの判定をする→RandomChangeScene(訓練),StartTutorialScene(チュートリアル)へ分岐
public class GetBoxCollider : MonoBehaviour
{
    float StartTime = 0.0f;
    float CurrentTime = 0.0f;
    bool isTouchTimeCount = false;
    bool isTouchStartButton = false;

    public bool canRandomChangeScene,canStartTutorial = false;

    LeapHandCollision _hc = new LeapHandCollision();
    // Use this for initialization
    void Start()
    {
        //Cubeの色変更,Inspector上で変更する方法がわからなかったため
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.white);

    }

    void OnTriggerStay(Collider other)
    {
        if (_hc.IsHand(other))
        {
            
              isTouchStartButton = true;
  
        }
    }

    void OnTriggerEnter(Collider hand)
    {
        //訓練スタートのためのタイマースタート時間とリセット
        if (_hc.IsHand(hand) && isTouchStartButton == true)
        {
            StartTime = Time.time;

        }
        if (_hc.IsHand(hand) && isTouchStartButton == false)//GetBoxColliderに触れて離してを繰り返すとタイマーが進む問題を解決するため、離すとタイマーがリセットされる
        {
            StartTime = 0.0f;
        }

     
    }

    // Update is called once per frame
    void Update()
    {
        //訓練スタートのためのタイマー
        if (isTouchStartButton == true)
        {
            CurrentTime = Time.time;
            isTouchTimeCount = true;
        }
        if ((StartTime + 2.0f <= CurrentTime) && isTouchTimeCount == true)
        {
            canRandomChangeScene = true;

        }


        Debug.Log(CurrentTime + "CurrentTime");
    }
}