using UnityEngine;
using System.Collections;

public class ObjectsParentCtrl : MonoBehaviour
{

    LeapHandCollision hc = new LeapHandCollision();

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

        if (FlagManager.Instance.flags[0] == true && hc.IsHand(other))
        {
            this.transform.parent = other.transform;
            Debug.Log("パッド1が手の子Objに！");
        }
    }
}