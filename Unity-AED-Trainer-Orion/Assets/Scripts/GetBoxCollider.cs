using UnityEngine;
using System.Collections;


//Cubeに一定時間触れたかどうかの判定をする→RandomChangeSceneへ
public class GetBoxCollider : MonoBehaviour
{
    float StartTime = 0.0f;
    float CurrentTime = 0.0f;
    bool isTouchTimeCount = false;
    bool isTouchStartButton = false;

    public bool canRandomChangeScene = false;
    LeapHandCollision _hc = new LeapHandCollision();
    // Use this for initialization
    void Start()
    {
        //Cubeの色変更
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
        if (_hc.IsHand(hand) && isTouchStartButton == true)
        {
            StartTime = Time.time;
            Debug.Log("時間計測開始");
        }
        if (_hc.IsHand(hand) && isTouchStartButton == false)
        {
            StartTime = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isTouchStartButton == true)
        {
            CurrentTime = Time.time;
            isTouchTimeCount = true;
        }
        if ((StartTime + 2.0f <= CurrentTime) && isTouchTimeCount == true)
        {
            canRandomChangeScene = true;
            Debug.Log("2秒こえたよ");
        }
        Debug.Log(canRandomChangeScene);
    }
}