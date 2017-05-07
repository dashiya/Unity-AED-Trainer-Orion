using UnityEngine;
using System.Collections;

public class PadChilden : MonoBehaviour {
    GameObject RootObject;
    static int HandBool = 0;
	// Use this for initialization
	void Start () {
        if (HandBool == 0)
        {
            RootObject = GameObject.Find("RigidRoundHand(Clone)/palm");
            
            transform.parent = RootObject.transform;
           
        }
            }
	
	// Update is called once per frame
	void Update () {
        //ChildObject.transform.parent = null;
    
    }
}
