using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

//Leap.PalmPositionをパッドに代入してパッドを動かす
public class HandPosition : MonoBehaviour
{

    public Vector3 handPosition;
    public Vector3 ConvertPosition;
    public object controller;




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
        //Hand hand = GetComponent<HandModel>().GetLeapHand();

        if (FlagManager.Instance.flags[1] == true)
        {

            ConvertPosition = controller.Frame().Hand(20).PalmPosition;

        }


    }


    void OnGUI()
    {
        string label = "現在の手のひらの座標は" + ConvertPosition;
        GUI.Label(new Rect(0, 0, 200, 50), label);
    }


}


