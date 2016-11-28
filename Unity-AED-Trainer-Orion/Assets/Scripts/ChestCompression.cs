using UnityEngine;
using System.Collections;


//for chest compression
public class ChestCompression : MonoBehaviour {

    HandPosition hp = new HandPosition ();
    Vector3 ComparePosition;

    // Use this for initialization
    void Start () {
	

	}
    
	
	// Update is called once per frame
	void Update () {

        ComparePosition = hp.ConvertPosition;

        

	}
}
