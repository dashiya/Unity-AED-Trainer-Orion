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


    //ForDebug
    public int textNumberInt;

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
    }//Start()ここまで

    // Update is called once per frame
    void Update()
    {


        //OpenButton_Tutorial,DestroyWear_Tutorial内、flag[0]と、isPlayAudioDestroyWearを監視、それぞれがtrueになったタイミングで上で取得したtransformつかってprefab化したspotlightを移動してチュートリアルを進める

     
        /*
                _pad1Pos = transform.position;

            _pad1Pos.x = _handPos.ConvertPosition.x;
            _pad1Pos.y = _handPos.ConvertPosition.y;
            _pad1Pos.z = _handPos.ConvertPosition.z;
        
            transform.position = _pad1Pos;
            */

        switch (textNumberInt)
        {

            case 1:
                spotlightPrefabPos.x = -1.296f;
                spotlightPrefabPos.z = 0.81f;

                transform.position = spotlightPrefabPos;
                break;
            //destroywear2

            case 2:
                spotlightPrefabPos.x = _openButtonTutorialPos.x;
                spotlightPrefabPos.z = _openButtonTutorialPos.z;

                transform.position = spotlightPrefabPos;
                break;
            //openbutton1

            case 3:
                spotlightPrefabPos.x = _pad1PositionPos.x;
                spotlightPrefabPos.z = _pad1PositionPos.z;

                transform.position = spotlightPrefabPos;
                break;
            //_pad1PositionPos3

            case 4:
                spotlightPrefabPos.x = _padSetPosition1Pos.x;
                spotlightPrefabPos.z = _padSetPosition1Pos.z;

                transform.position = spotlightPrefabPos;
                break;
            //_padSetPosition1Pos4

            case 5:
                spotlightPrefabPos.x = _pad2PositionPos.x;
                spotlightPrefabPos.z = _pad2PositionPos.z;

                transform.position = spotlightPrefabPos;
                break;
            //_pad2PositionPos5


            case 6:
                spotlightPrefabPos.x = _padSetPosition2Pos.x;
                spotlightPrefabPos.z = _padSetPosition2Pos.z;

                transform.position = spotlightPrefabPos;
                break;
            //_pad2PositionPos6

            case 7:
                spotlightPrefabPos.x = _buttonAudio1Pos.x;
                spotlightPrefabPos.z = _buttonAudio1Pos.z;

                transform.position = spotlightPrefabPos;
                break;
            //_buttonAudio1Pos7

            case 8: 
                spotlightPrefabPos.x = _buttonAudio2Pos.x;
                spotlightPrefabPos.z = _buttonAudio2Pos.z;

                transform.position = spotlightPrefabPos;
                break;
            //_buttonAudio2Pos8

            case 9:
                spotlightPrefabPos.x = _energiationButtonPos.x;
                spotlightPrefabPos.z = _energiationButtonPos.z;

                transform.position = spotlightPrefabPos;
                break;
            //_energiationButtonPos9

            case 10:
                spotlightPrefabPos.x = _CPRAudiopos.x;
                spotlightPrefabPos.z = _CPRAudiopos.z;

                transform.position = spotlightPrefabPos;
                break;
            //_CPRAudiopos10


            case 11:
                spotlightPrefabPos.x = _tempoSoundPos.x;
                spotlightPrefabPos.z = _tempoSoundPos.z;

                transform.position = spotlightPrefabPos;
                break;

            default:
                break;
                //_tempoSoundPos11
        }//switchここまで


    }//Update()ここまで
}