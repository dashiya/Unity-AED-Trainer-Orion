using UnityEngine;
using System.Collections;
using Leap;

//Leapmotionで取得した手の位置をUnityの座標に変換する
//→ 手が触れたら子オブジェクトにする
public class HandPosition : MonoBehaviour
{

    public Vector3 handPosition;
    public Vector3 ConvertPosition;




    // Use this for initialization
    void Start()
    {
       GameObject controller = GameObject.Find("HandController");



    }


    // LeapのVectorからUnityのVector3に変換
    Vector3 ToUnity(Vector v)
    {
        return new Vector3(v.x, v.y, v.z);
    }


    // Get Habd objects from a Frame
    void Update()
    {
        Hand hand = GetComponent<HandModel>().GetLeapHand();

        if (FlagManager.Instance.flags[1] == true)
        {

            ConvertPosition = transform.TransformPoint(hand.PalmPosition.ToUnityScaled());

        }


    }


    void OnGUI()
    {
        string label = "現在の手のひらの座標は" + ConvertPosition;
        GUI.Label(new Rect(0, 0, 200, 50), label);
    }


}


