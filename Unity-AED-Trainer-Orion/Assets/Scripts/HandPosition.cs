using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;


//Leap.PalmPositionを取得するクラス
public class HandPosition : MonoBehaviour
{

    public Vector3 ConvertPosition;
    public Vector OriginalPosition;

    LeapProvider provider;

    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
    }

    // Get Habd objects from a Frame
    void Update()
    {

        //  if (FlagManager.Instance.flags[1] == true)
        {
            Frame frame = provider.CurrentFrame;
            List<Hand> hands = frame.Hands;
            for (int h = 0; h < hands.Count; h++)

            {
                Hand hand = hands[h];
                if (hand.IsLeft | hand.IsRight)
                {
                    OriginalPosition = hand.PalmPosition;

                    ConvertPosition = hand.PalmPosition.ToVector3() +
                                         hand.PalmNormal.ToVector3() *
                                        (transform.localScale.y * .5f + .02f);

                }
            }
        }
    }
}





