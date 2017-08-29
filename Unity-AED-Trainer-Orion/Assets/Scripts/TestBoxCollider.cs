using UnityEngine;
using System.Collections;

public class TestBoxCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnColliderEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "Hand")
        {
            Debug.Log("手が触れたよ");
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
