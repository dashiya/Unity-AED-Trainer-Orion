using UnityEngine;
using System.Collections;

public class HandColTest : MonoBehaviour
{


    LeapHandCollision hc = new LeapHandCollision();

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (hc.IsHand(other))
        {
            Debug.Log("Yay! A hand collided!");
        
            //緑色に変更
            this.GetComponent<Renderer>().material.color = Color.green;

           
        }

    }


    // Update is called once per frame
    void Update()
    {

    }

}
