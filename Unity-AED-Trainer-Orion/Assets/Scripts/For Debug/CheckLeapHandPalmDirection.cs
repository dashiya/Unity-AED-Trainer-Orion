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

    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
    }

    // Update is called once per frame
    void Update()
    {
        {
            Frame frame = provider.CurrentFrame;
            List<Hand> hands = frame.Hands;
            for (int h = 0; h < hands.Count; h++)

            {
                Hand hand = hands[h];
                if (hand.IsLeft | hand.IsRight)
                {
                
                }

            }
        }
        //Debug.Log(handDirection + "handDirection");
    }
}