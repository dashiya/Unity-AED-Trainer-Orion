using UnityEngine;
using System.Collections;

public class TestBoxCollider : MonoBehaviour
{
    LeapHandCollision _hc = new LeapHandCollision();
    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerStay(Collider other)
    {

        if (_hc.IsHand(other))
        {
            Debug.Log("手が触れたよ");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}