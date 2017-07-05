using UnityEngine;
using System.Collections;
using Leap.Unity;
using System;

public class LeapHandCollision 
{
    public GameObject HandModel;

    public bool IsHand(Collider handcol)
    {
        if (handcol.transform.parent && handcol.transform.parent.parent && handcol.transform.parent.parent.GetComponent<HandModel>())
            return true;
        else
            return false;
    }

    internal bool IsHand(Collision other)
    {
        throw new NotImplementedException();
    }
}
