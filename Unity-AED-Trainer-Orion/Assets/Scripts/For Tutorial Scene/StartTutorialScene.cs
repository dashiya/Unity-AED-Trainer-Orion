using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//スタートシーンから、ボタンに触れたときにチュートリアルシーンに移動するためのスクリプト
public class StartTutorialScene : MonoBehaviour
{

    GetBoxColliderTutorial _getBoxColliderTutorial;

    // Use this for initialization
    //RandomChangeSceneと違い、GetBoxColliderTutorialを取得してるのはOnTriggerStayでGetBoxColliderTutorialに触れたかどうかを知りたいため
    void Start()
    {
        _getBoxColliderTutorial = GameObject.Find("GetBoxColliderTutorial").GetComponent<GetBoxColliderTutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_getBoxColliderTutorial.canStartTutorial == true)
        {
            SceneManager.LoadScene("AEDTrainer-Tutorial");
        }
    }
}
