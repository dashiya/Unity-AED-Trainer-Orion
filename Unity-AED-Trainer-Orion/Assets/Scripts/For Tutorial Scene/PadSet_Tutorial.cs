using UnityEngine;
using System.Collections;

public class PadSet_Tutorial : MonoBehaviour {

    void OnTriggerEnter(Collider humancols)
    {
        if (humancols.gameObject.tag == "Pad1")
        {
            FlagManager.Instance.flags[2] = true;
            Destroy(GetComponent<Collider>());
        }
        if (humancols.gameObject.tag == "Pad2")
        {
            FlagManager.Instance.flags[4] = true;
            Destroy(GetComponent<Collider>());
        }
    }
}