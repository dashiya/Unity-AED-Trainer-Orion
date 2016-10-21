using UnityEngine;
using System.Collections;


public class PadBehaviour : MonoBehaviour
{

    public float force, torque;
    private FixedJoint myJoint;
    private GameObject obj;

    public Rigidbody hand;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand" )  //&& myJoint == null)

        {
                 Debug.Log("手がパッドに触れたよ");

                //FixedJointアタッチ
                var Joint = GetComponent<FixedJoint>();
                //RigidRoundHandさがす
                obj = GameObject.Find("RigidRoundHand");
                //handにRigidRoundHandのrigidbodyを指定
                hand = obj.GetComponent<Rigidbody>();

                //くっつける
                Joint.connectedBody = hand;
                Debug.Log("くっつける");

          }
        else if (FlagManager.Instance.flags[0] == true)
        {
            Debug.Log("当たり判定とれなかったよ(・ω・｀)");      
        }
        
    }
}
