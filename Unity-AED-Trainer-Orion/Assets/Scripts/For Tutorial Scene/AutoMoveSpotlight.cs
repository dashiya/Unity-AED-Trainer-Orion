using UnityEngine;
using System.Collections;

public class AutoMoveSpotlight : MonoBehaviour {

    GameObject spotlightPrefab;
    Transform soptlightPrefabTransform;
    

	// Use this for initialization
	void Start () {
        spotlightPrefab = GameObject.Find("MoveSoptlight");
        soptlightPrefabTransform = spotlightPrefab.GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
