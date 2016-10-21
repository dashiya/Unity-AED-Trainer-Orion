//ふた上部にあるObject"Cube"を中心として回転するプログラム

using UnityEngine;
using System.Collections;

public class TargetRotation : MonoBehaviour{

//回転角度
public float angle = 180f;
//回転の中心
private Vector3 targetPos;

    void Start() {
        //targetに"Cube"という名前がついているオブジェクトを指定する
        Transform target = GameObject.Find("Cube").transform;

        //targetにCubeの位置情報をおくる
        targetPos = target.position;
    }

    void Update() {
        //Eキーが押された時のみ動作する
        if (Input.GetKeyDown("e"))
        {
            // Spin the object around the world origin at 180 degrees
            Vector3 axis = transform.TransformDirection(Vector3.left);
            this.gameObject.transform.RotateAround(targetPos, axis, angle);
        }else {
            //何もしない
        }
}
}