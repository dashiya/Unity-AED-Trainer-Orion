using UnityEngine;
using System.Collections;

public class AutoMoveSpotlight : MonoBehaviour
{

    GameObject spotlightPrefab;
    Transform soptlightPrefabTransform;


    // Use this for initialization
    void Start()
    {
        spotlightPrefab = GameObject.Find("MoveSoptlight");
        soptlightPrefabTransform = spotlightPrefab.GetComponent<Transform>();

        //OpenButton_Tutorial,DestroyWear_Tutorial取得
        //それぞれのTransformにアクセス
        //MoveSpotlightの生成


    }

    // Update is called once per frame
    void Update()
    {
        //OpenButton_Tutorial,DestroyWear_Tutorial内、flag[0]と、isPlayAudioDestroyWearを監視、それぞれがtrueになったタイミングで上で取得したtransformつかってprefab化したspotlightを移動してチュートリアルを進める
    }
}
