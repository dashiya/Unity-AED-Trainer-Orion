using UnityEngine;
using System.Collections;

public class ObjParentTest : MonoBehaviour {

    

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {


        }
        void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.tag == "GameController")
        {
            this.transform.parent = other.transform;
        }
          
        }
    }
