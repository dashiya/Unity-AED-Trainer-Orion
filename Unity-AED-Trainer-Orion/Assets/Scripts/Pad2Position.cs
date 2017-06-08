using UnityEngine;
using System.Collections;

public class Pad2Position : MonoBehaviour
{
    public bool pad2col = false;

    LeapHandCollision hc = new LeapHandCollision();

    // Use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter(Collider pad2col)
    {
        //if(手がふれていてかつパッド1が貼付け済みなら)
        if (hc.IsHand(pad2col) && FlagManager.Instance.flags[2] == true)
        {
            FlagManager.Instance.flags[3] = true;
        }

    }


    // Update is called once per frame
    void Update()
    {
        //if(パッド2に手がふれていてかつパッド2が貼り付けられていなければ)
        if (FlagManager.Instance.flags[3] == true && FlagManager.Instance.flags[4] == false)
        {

            HandPosition handPos = GetComponent<HandPosition>();
            
            Vector3 pad2Pos = this.transform.position;

            pad2Pos.x = handPos.ConvertPosition.x;
            pad2Pos.y = handPos.ConvertPosition.y;
            pad2Pos.z = handPos.ConvertPosition.z;

            this.transform.position = pad2Pos;

        }
    }
}

