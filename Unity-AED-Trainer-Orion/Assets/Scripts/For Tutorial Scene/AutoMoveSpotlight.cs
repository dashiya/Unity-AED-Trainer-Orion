using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    Text _textTutorialText;

    //指定秒数後にテキストの中身を変える用
    float changeTextTime = 3.0f;
    float time = 0.0f;


    //ForDebug
    public int textNumberInt;

    // Use this for initialization
    void Start()
    {
        spotlightPrefab = GameObject.Find("MoveSoptlight");
        spotlightPrefabTransform = spotlightPrefab.GetComponent<Transform>();
        spotlightPrefabPos = spotlightPrefabTransform.position;

        _textTutorialText = GameObject.Find("TextTutorial").GetComponent<Text>();


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
    }//Start()ここまで


    // Update is called once per frame
    void Update()
    {
        //それぞれのflagがtrueになったタイミングでprefab化したspotlightを移動してチュートリアルを進める

        //if (FlagManager.Instance.flags[19] == true)//スタートボタンに触れたら（未実装）
        {
            spotlightPrefabPos.x = _openButtonTutorialPos.x;
            spotlightPrefabPos.z = _openButtonTutorialPos.z;

            transform.position = spotlightPrefabPos;

            _textTutorialText.text = ("電源ボタンに触れてAEDの電源を入れてください");

            //openbutton1
        }
        if (FlagManager.Instance.flags[20] == true)//openbutton_tutorial 開閉ボタンにふれたら
        {

            spotlightPrefabPos.x = -1.296f;
            spotlightPrefabPos.z = 0.81f;

            transform.position = spotlightPrefabPos;

            _textTutorialText.text = ("音声に従って、服に触れて胸を裸にしてください");
            //destroywear2

        }

        if (GameObject.Find("Wear Object") == null)//DestroyWear 服にふれたら
        {

            spotlightPrefabPos.x = _pad1PositionPos.x;
            spotlightPrefabPos.z = _pad1PositionPos.z;

            transform.position = spotlightPrefabPos;//todo spotlight位置ずれがあるので修正

            _textTutorialText.text = ("パッドにふれてください");
            //_pad1PositionPos3
        }

        if (FlagManager.Instance.flags[22] == true)//Pad1Position_Tutorial パッド1にふれたら
        {
            spotlightPrefabPos.x = _padSetPosition1Pos.x;
            spotlightPrefabPos.z = _padSetPosition1Pos.z;

            transform.position = spotlightPrefabPos;//todo spotlight位置が違うので修正
            _textTutorialText.text = ("パッドを右胸に貼り付けてください");
            //_padSetPosition1Pos4
        }

        if (FlagManager.Instance.flags[23] == true)//PadSet_Tutorial
        {
            spotlightPrefabPos.x = _pad2PositionPos.x;
            spotlightPrefabPos.z = _pad2PositionPos.z;

            transform.position = spotlightPrefabPos;
            _textTutorialText.text = ("パッドにふれてください");
            //_pad2PositionPos5  

        }

        if (FlagManager.Instance.flags[24] == true)//Pad2Position_Tutorialから
        {
            spotlightPrefabPos.x = _padSetPosition2Pos.x;
            spotlightPrefabPos.z = _padSetPosition2Pos.z;//spotlight位置修正

            transform.position = spotlightPrefabPos;
            _textTutorialText.text = ("パッドを左胸に貼り付けてください");
            //_pad2PositionPos6
        }

        if (FlagManager.Instance.flags[25] == true)//ButtonAudio1_Tutorialから
        {
            spotlightPrefabPos.x = _buttonAudio1Pos.x;
            spotlightPrefabPos.z = _buttonAudio1Pos.z;

            transform.position = spotlightPrefabPos;
            _textTutorialText.text = ("電気ショックの充電が終わるまで人に触らないでください");
            //_buttonAudio1Pos7
        }

        if (FlagManager.Instance.flags[26] == true)//ButtonAudio2_Tutorialから
        {
            spotlightPrefabPos.x = _buttonAudio2Pos.x;
            spotlightPrefabPos.z = _buttonAudio2Pos.z;

            transform.position = spotlightPrefabPos;
            _textTutorialText.text = ("充電されたら 点滅ボタンを押してください");
            //_buttonAudio2Pos8
        }


        if (FlagManager.Instance.flags[27] == true)//EnergizationButton_Tutorialから
        {
            spotlightPrefabPos.x = _energiationButtonPos.x;
            spotlightPrefabPos.z = _energiationButtonPos.z;

            transform.position = spotlightPrefabPos;
            _textTutorialText.text = ("電気ショックが行われました");


            //_energiationButtonPos9
        }


        if (FlagManager.Instance.flags[28] == true)//CPRAudio_Tutorialから
        {
            spotlightPrefabPos.x = _CPRAudiopos.x;
            spotlightPrefabPos.z = _CPRAudiopos.z;

            transform.position = spotlightPrefabPos;
            _textTutorialText.text = ("音に合わせて光っている場所を押し込んでください");



            //_CPRAudiopos10
        }


        //    spotlightPrefabPos.x = _tempoSoundPos.x;
        //    spotlightPrefabPos.z = _tempoSoundPos.z;

        //    transform.position = spotlightPrefabPos;

    }//Update()ここまで
}