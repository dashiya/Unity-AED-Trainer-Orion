using UnityEngine;
using System.Collections;

public class AutoMoveSpotlight : MonoBehaviour
{

    GameObject spotlightPrefab;
    Transform soptlightPrefabTransform;

    GameObject openButtonTutorialObject;
    Transform openButtonTutorialTransform;

    GameObject destroyWearObject;
    Transform destroyWearTransform;


    // Use this for initialization
    void Start()
    {
        spotlightPrefab = GameObject.Find("MoveSoptlight");
        soptlightPrefabTransform = spotlightPrefab.GetComponent<Transform>();

        //OpenButton_Tutorial,DestroyWear_Tutorial取得
        //それぞれのTransformにアクセス
        //MoveSpotlightの生成
        openButtonTutorialTransform = GameObject.Find("開閉ボタン").GetComponent<Transform>();
        destroyWearTransform = GameObject.Find("Wear").GetComponent<Transform>();

        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //OpenButton_Tutorial,DestroyWear_Tutorial内、flag[0]と、isPlayAudioDestroyWearを監視、それぞれがtrueになったタイミングで上で取得したtransformつかってprefab化したspotlightを移動してチュートリアルを進める
    }
}
