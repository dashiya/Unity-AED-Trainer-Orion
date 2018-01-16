using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//スタートシーンから、ボタンに触れたときに訓練用シーン3つに分岐するためのスクリプト
public class RandomChangeScene : MonoBehaviour
{
    int randomSceneNumber = 2;

    GetBoxCollider _getBoxCollider;
    // Use this for initialization
    void Start()
    {
        _getBoxCollider = GameObject.Find("GetBoxCollider").GetComponent<GetBoxCollider>();

        //randomSceneNumber = Random.Range(1, 4);//Random.Range(min(含まれる),max(含まれない))ので、1,2,3のいずれかを返す
        Debug.Log(randomSceneNumber + "randomSceneNumber");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_getBoxCollider.canRandomChangeScene == true)
        {
            switch (randomSceneNumber)
            {
                case 1:
                    SceneManager.LoadScene("AEDTrainer-Scenario1");
                    break;

                case 2:
                    SceneManager.LoadScene("AEDTrainer-Scenario4");
                    break;

                case 3:
                    SceneManager.LoadScene("AEDTrainer-Scenario5");
                    break;

                default:
                    Debug.Log("Failed to Load Scene ");
                    break;

            }
        }
    }
}