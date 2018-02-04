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
    
    public bool isPalmDirectionTrue;

    //PalmDirectionDetectorに呼ばれる
    public void ReceiveMessageDirectionTrue()
    {
        isPalmDirectionTrue = true;
    }

        
    //PalmDirectionDetectorに呼ばれる
    public void ReceiveMessageDirectionFalse()
    {
        isPalmDirectionTrue = false;
    }

   }