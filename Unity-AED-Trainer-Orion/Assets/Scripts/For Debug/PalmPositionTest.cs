using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;

public class PalmPositionTest : MonoBehaviour {

    LeapProvider provider;

    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
    }

    void Update()
    {
        Frame frame = provider.CurrentFrame;
        List<Hand> hands = frame.Hands;
        for (int h = 0; h < hands.Count; h++)
        {
            Hand hand = hands[h];
            if (hand.IsLeft | hand.IsRight )
            {
                transform.position = hand.PalmPosition.ToVector3() +
                                     hand.PalmNormal.ToVector3() *
                                    (transform.localScale.y * .5f + .02f);
                
            }
        }
    }
}

