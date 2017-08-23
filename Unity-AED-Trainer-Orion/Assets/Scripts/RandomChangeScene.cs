using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomChangeScene : MonoBehaviour
{

    int randomSceneNumber;

    // Use this for initialization
    void Start()
    {
        randomSceneNumber = Random.Range(1, 4);//Random.Range(min(含まれる),max(含まれない))ので、1,2,3のいずれかを返す
        Debug.Log(randomSceneNumber + "randomSceneNumber");
    }

    // Update is called once per frame
    void Update()
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
                Debug.Log("Load Scene Failed");
                break;

        }
    }
}