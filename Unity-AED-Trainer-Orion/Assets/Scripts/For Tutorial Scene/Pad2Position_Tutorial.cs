using UnityEngine;
using System.Collections;

public class Pad2Position_Tutorial : MonoBehaviour {

    HandPosition _handPos;
    Vector3 _pad2Pos;
    public bool pad2col = false;

    LeapHandCollision _hc = new LeapHandCollision();

    // Use this for initialization
    void Start()
    {
        _handPos = GetComponent<HandPosition>();
        _pad2Pos = this.transform.position;
    }

    void OnTriggerEnter(Collider pad2col)
    {
        if (_hc.IsHand(pad2col) && FlagManager.Instance.flags[2] == true)  //if(手がふれていてかつパッド1が貼付け済みなら)
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
            _pad2Pos.x = _handPos.ConvertPosition.x;
            _pad2Pos.y = _handPos.ConvertPosition.y;
            _pad2Pos.z = _handPos.ConvertPosition.z;

            this.transform.position = _pad2Pos;
            FlagManager.Instance.flags[24] = true;//AutoMoveSpotlightへ
        }
    }
}