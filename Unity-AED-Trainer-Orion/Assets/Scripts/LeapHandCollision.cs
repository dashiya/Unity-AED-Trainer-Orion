using UnityEngine;
using System.Collections;

public class LeapHandCollision  {

    public bool IsHand(Collider handcol)
    {
        if (handcol.transform.parent && handcol.transform.parent.parent && handcol.transform.parent.parent.GetComponent<HandModel>())
            return true;
        else
            return false;
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
