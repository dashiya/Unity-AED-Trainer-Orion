using UnityEngine;
using System.Collections;

public class CoverRotation : MonoBehaviour{


    //回転角度
    private float angle = 120f;
    //回転の中心
    private Vector3 targetPos;

    void Start()  {
        //targetに"Cube"という名前がついているオブジェクトを指定する
        Transform target = GameObject.Find("Cube").transform;

        //targetにCubeの位置情報をおくる
        targetPos = target.position;
    }

        //ハンドモデルが触れた時のみ動作する
   void OnTriggerEnter(Collider coll){  
        //OpenButton.csの参照
    OpenButton open = GetComponent<OpenButton>();

    //OpenButtonから手が電源ボタンに触れているかどうかの変数OpenCoverをとってくる
    if (open == true)  {
  
            // Spin the object around the world origin at 120 degrees
            Vector3 axis = transform.TransformDirection(Vector3.left);
            this.gameObject.transform.RotateAround(targetPos, axis, angle);

    }
    else
    {
        Debug.Log("Closed!"); //for debug
    }

    }
}