using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;

public class CheckLeapHandPalmDirection : MonoBehaviour
{

    LeapHandCollision hc = new LeapHandCollision();

    Vector3 palmDirectionVector3;
    LeapProvider provider;

    Vector handDirection;

    public bool isPalmDirectionTrue = true;

    //PalmDirectionDetectorのSendMessageに呼ばれる
    public void ReceiveMessageDirectionTrue()
    {
        isPalmDirectionTrue = true;
        Debug.Log("isPalmDirectionTrue" + isPalmDirectionTrue);
    }

    public void ReceiveMessageDirectionFalse()
    {
        isPalmDirectionTrue = false;
        Debug.Log("isPalmDirectionTrue" + isPalmDirectionTrue);
    }
}