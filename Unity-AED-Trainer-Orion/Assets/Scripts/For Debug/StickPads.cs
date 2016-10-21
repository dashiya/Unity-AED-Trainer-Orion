using UnityEngine;
using System.Collections;
using Leap;

public class StickPads : MonoBehaviour
{
    /** The parent HandController object for this hand. */
    protected HandController controller_;
    /** The Leap Hand object this hand model represents. */
    protected Hand hand_;
    /** Transform object for the palm object of this hand. */
    public Transform palm;
    /** Whether the parent HandController instance has been set to mirror across the z axis.*/
    protected bool mirror_z_axis_ = false;

    // 位置座標
    private Transform HandPosition;


    public Vector3 GetHandOffset()
    {
        if (controller_ == null || hand_ == null)
            return Vector3.zero;

        Vector3 additional_movement = controller_.handMovementScale - Vector3.one;
        Vector3 scaled_wrist_position = Vector3.Scale(additional_movement, hand_.WristPosition.ToUnityScaled(mirror_z_axis_));

        return controller_.transform.TransformPoint(scaled_wrist_position) -
               controller_.transform.position;
    }


    public Vector3 GetPalmPosition()
    {
        if (controller_ != null && hand_ != null)
        {
            return controller_.transform.TransformPoint(hand_.PalmPosition.ToUnityScaled(mirror_z_axis_)) + GetHandOffset();
        }
        if (palm)
        {
            return palm.position;
        }
        return Vector3.zero;
    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hand")// && myJoint == null && FlagManager.Instance.flags[0] == true)
        {
            Debug.Log("手がパッドに触れたよ");
        }
        else if (FlagManager.Instance.flags[0] == true)
        {
            Debug.Log("当たり判定とれなかったよ(・ω・｀)");
        }
    }

    void Start()
    {
    }



    void Update()
    {
        //  if (FlagManager.Instance.flags[0] == true)
        // Vector3で手の位置座標を取得する

         HandPosition = palm;
        Debug.Log(HandPosition);

    }
}
