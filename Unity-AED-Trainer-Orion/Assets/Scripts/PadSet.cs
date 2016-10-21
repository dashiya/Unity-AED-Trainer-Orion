using UnityEngine;
using System.Collections;

public class PadSet : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        
    }

    
    void OnTriggerEnter(Collider humancols)
    {
        if (humancols.gameObject.tag == "Pad1")
        {
            FlagManager.Instance.flags[2] = true;
            Destroy(GetComponent<Collider>());
        }
        else if (humancols.gameObject.tag == "Pad2")
        {
            FlagManager.Instance.flags[4] = true;
            Destroy(GetComponent<Collider>());
        }
    }


    // Update is called once per frame
    void Update()
    {

     }
}
