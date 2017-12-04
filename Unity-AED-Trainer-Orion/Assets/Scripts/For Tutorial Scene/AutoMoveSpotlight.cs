using UnityEngine;
using System.Collections;

public class AutoMoveSpotlight : MonoBehaviour
{

    GameObject spotlightPrefab;
    Transform spotlightPrefabTransform;
    Vector3 spotlightPrefabPos;

    GameObject openButtonTutorialObject;
    Vector3 _openButtonTutorialPos;
    Transform _openButtonTutorialTransform;//実行順 1

    GameObject destroyWearObject;
    Vector3 _destroyWearPos;
    Transform _destroyWearTransform;//実行順 2

    Vector3 _pad1PositionPos;
    Transform _pad1PositionTransform;//実行順 3

    Vector3 _pad2PositionPos;
    Transform _pad2PositionTransform;//実行順 5

    Vector3 _buttonAudio1Pos;
    Transform _buttonAudio1Transform;//実行順 7

    Vector3 _buttonAudio2Pos;
    Transform _buttonAudio2Transform;//実行順 8

    Vector3 _energiationButtonPos;
    Transform _energiationButtonTransform;//実行順 9

    Vector3 _padSetPosition1Pos;
    Transform _padSetPosition1Transform;//実行順 4

    Vector3 _padSetPosition2Pos;
    Transform _padSetPosition2Transform;//実行順 6

    Vector3 _CPRAudiopos;
    Transform _CPRAudioTransform;//実行順 10

    Vector3 _tempoSoundPos;
    Transform _tempoSoundTransform;//実行順 11

    // Use this for initialization
    void Start()
    {
        spotlightPrefab = GameObject.Find("MoveSoptlight");
        spotlightPrefabTransform = spotlightPrefab.GetComponent<Transform>();
        spotlightPrefabPos = spotlightPrefabTransform.position;


        //OpenButton_Tutorial,DestroyWear_Tutorial取得
        //それぞれのTransformにアクセス
        //MoveSpotlightの生成
        _openButtonTutorialTransform = GameObject.Find("開閉ボタン").GetComponent<Transform>();//1
        _openButtonTutorialPos = _openButtonTutorialTransform.position;

        _destroyWearTransform = GameObject.Find("Wear").GetComponent<Transform>();//2
        _destroyWearPos = _destroyWearTransform.position;

        _pad1PositionTransform = GameObject.Find("パッド1").GetComponent<Transform>();//3
        _pad1PositionPos = _pad1PositionTransform.position;

        _padSetPosition1Transform = GameObject.Find("PadSetPosition1").GetComponent<Transform>();//4
        _padSetPosition1Pos = _padSetPosition1Transform.position;


        _pad2PositionTransform = GameObject.Find("パッド2").GetComponent<Transform>();//5
        _pad2PositionPos = _pad2PositionTransform.position;


        _padSetPosition2Transform = GameObject.Find("PadSetPosition2").GetComponent<Transform>();//6
        _padSetPosition2Pos = _padSetPosition2Transform.position;

        _buttonAudio1Transform = GameObject.Find("ButtonAudio1").GetComponent<Transform>();//7
        _buttonAudio1Pos = _buttonAudio1Transform.position;

        _buttonAudio2Transform = GameObject.Find("ButtonAudio2").GetComponent<Transform>();//8
        _buttonAudio2Pos = _buttonAudio2Transform.position;

        _energiationButtonTransform = GameObject.Find("ボタン内側").GetComponent<Transform>();//9
        _energiationButtonPos = _energiationButtonTransform.position;

        _CPRAudioTransform = GameObject.Find("CPRAudio").GetComponent<Transform>();//10
        _CPRAudiopos = _CPRAudioTransform.position;

        _tempoSoundTransform = GameObject.Find("TempoSound").GetComponent<Transform>();//11
        _tempoSoundPos = _tempoSoundTransform.position;




        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {


        //OpenButton_Tutorial,DestroyWear_Tutorial内、flag[0]と、isPlayAudioDestroyWearを監視、それぞれがtrueになったタイミングで上で取得したtransformつかってprefab化したspotlightを移動してチュートリアルを進める

       // spotlightPrefabPos = new Vector3(-1.296f, 4.133f, 0.81f);
        spotlightPrefabPos.x = -1.296f;
        spotlightPrefabPos.z = 0.81f;

        transform.position = spotlightPrefabPos;

           Debug.Log(_destroyWearPos + "_destroyWearPos");

        /*
                _pad1Pos = transform.position;

            _pad1Pos.x = _handPos.ConvertPosition.x;
            _pad1Pos.y = _handPos.ConvertPosition.y;
            _pad1Pos.z = _handPos.ConvertPosition.z;

            transform.position = _pad1Pos;
            */

    }
}
