using UnityEngine;
using System.Collections;

public class AutoMoveSpotlight : MonoBehaviour
{

    GameObject spotlightPrefab;
    Transform spotlightPrefabTransform;
    float spotlightPrefabPos;

    GameObject openButtonTutorialObject;
    Transform _openButtonTutorialTransform;//実行順 1

    GameObject destroyWearObject;
    float _destroyWearPos;
    Transform _destroyWearTransform;//実行順 2

    float _pad1PositionPos;
    Transform _pad1PositionTransform;//実行順 3

    float _pad2PositionPos;
    Transform _pad2PositionTransform;//実行順 5

    float _buttonAudio1Pos;
    Transform _buttonAudio1Transform;//実行順 7

    float _buttonAudio2Pos;
    Transform _buttonAudio2Transform;//実行順 8

    float _energiationButtonPos;
    Transform _energiationButtonTransform;//実行順 9

    float _padSetPosition1Pos;
    Transform _padSetPosition1Transform;//実行順 4

    float _padSetPosition2Pos;
    Transform _padSetPosition2Transform;//実行順 6

    float _CPRAudiopos;
    Transform _CPRAudioTransform;//実行順 10

    float _tempoSoundPos;
    Transform _tempoSoundTransform;//実行順 11

    // Use this for initialization
    void Start()
    {
        spotlightPrefab = GameObject.Find("MoveSoptlight");
        spotlightPrefabTransform = spotlightPrefab.GetComponent<Transform>();

        //OpenButton_Tutorial,DestroyWear_Tutorial取得
        //それぞれのTransformにアクセス
        //MoveSpotlightの生成
        _openButtonTutorialTransform = GameObject.Find("開閉ボタン").GetComponent<Transform>();//1

        _destroyWearTransform = GameObject.Find("Wear").GetComponent<Transform>();//2

        _pad1PositionTransform = GameObject.Find("パッド1").GetComponent<Transform>();//3

        _padSetPosition1Transform = GameObject.Find("PadSetPosition1").GetComponent<Transform>();//4

        _pad2PositionTransform = GameObject.Find("Pad2Position").GetComponent<Transform>();//5

        _padSetPosition2Transform = GameObject.Find("PadSetPosition2").GetComponent<Transform>();//6

        _buttonAudio1Transform = GameObject.Find("ButtonAudio1").GetComponent<Transform>();//7

        _buttonAudio2Transform = GameObject.Find("ButtonAudio2").GetComponent<Transform>();//8

         _energiationButtonTransform  = GameObject.Find("ボタン内側").GetComponent<Transform>();//9

        _CPRAudioTransform = GameObject.Find("CPRAudio").GetComponent<Transform>();//10

        _tempoSoundTransform = GameObject.Find("TempoSound").GetComponent<Transform>();//11





        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //OpenButton_Tutorial,DestroyWear_Tutorial内、flag[0]と、isPlayAudioDestroyWearを監視、それぞれがtrueになったタイミングで上で取得したtransformつかってprefab化したspotlightを移動してチュートリアルを進める
    }
}
