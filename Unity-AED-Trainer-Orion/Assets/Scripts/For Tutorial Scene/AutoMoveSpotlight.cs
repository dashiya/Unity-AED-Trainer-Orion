using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//スポットライトを音声や動きに合わせて動かし、テキストを表示する
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
    float changeTextTime_1, chageTextTime_2 = 3.0f;
    public float time_1, time_2;

    //BackStartSceneColliderとBackStartSceneのTextの色を変える用
    MeshRenderer _backStartSceneColliderRend;
    Text _backStartSceneText;
    BackStartScene _backStartScene;
    bool _isEndTutorial;


    // Use this for initialization
    void Start()
    {
        //SpotlightのGameObject,Transform,Positionを取得
        spotlightPrefab = GameObject.Find("MoveSoptlight");
        spotlightPrefabTransform = spotlightPrefab.GetComponent<Transform>();
        spotlightPrefabPos = spotlightPrefabTransform.position;

        //Tutorial用の文字を表示するためのTextを取得
        _textTutorialText = GameObject.Find("TextTutorial").GetComponent<Text>();

        //Tutorial終了後のスタートシーンに戻るボタンを表示するためのTextとGameObjectを取得
        _backStartSceneColliderRend = GameObject.Find("BackStartSceneCollider").GetComponent<MeshRenderer>();
        _backStartScene = GameObject.Find("BackStartSceneCollider").GetComponent<BackStartScene>();
        _backStartSceneText = GameObject.Find("BackStartScene").GetComponent<Text>();

        //スタートシーンに戻るボタンのTextとGameObjectを透明にする
        _backStartSceneColliderRend.material.color = new Color(0, 0, 0, 0);
        _backStartSceneText.color = new Color(0, 0, 0, 0);


        //それぞれのTransformにアクセス、Positionを取得
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

            spotlightPrefabPos.x = -1.37f;
            spotlightPrefabPos.z = 0.81f;

            transform.position = spotlightPrefabPos;

            _textTutorialText.text = ("音声に従って、服に触れて胸を裸にしてください");
            //destroywear2

        }

        if (GameObject.Find("Wear Object") == null)//DestroyWear 服にふれたら
        {

            spotlightPrefabPos.x = 0.66f;
            spotlightPrefabPos.z = 2.48f;

            transform.position = spotlightPrefabPos;

            _textTutorialText.text = ("パッドにふれてください");
            //_pad1PositionPos3
        }

        if (FlagManager.Instance.flags[22] == true)//Pad1Position_Tutorial パッド1にふれたら
        {
            spotlightPrefabPos.x = -1.8f;
            spotlightPrefabPos.z = 1.8f;

            transform.position = spotlightPrefabPos;
            _textTutorialText.text = ("パッドを右胸に貼り付けてください");
            //_padSetPosition1Pos4
        }

        if (FlagManager.Instance.flags[23] == true)//PadSet_Tutorial
        {
            spotlightPrefabPos.x = 0.07f;
            spotlightPrefabPos.z = 2.48f;

            transform.position = spotlightPrefabPos;
            _textTutorialText.text = ("パッドにふれてください");
            //_pad2PositionPos5  

        }

        if (FlagManager.Instance.flags[24] == true)//Pad2Position_Tutorialから
        {
            spotlightPrefabPos.x = -1.2f;
            spotlightPrefabPos.z = 1.25f;

            transform.position = spotlightPrefabPos;
            _textTutorialText.text = ("パッドを左胸に貼り付けてください");
            //_pad2PositionPos6
        }

        if (FlagManager.Instance.flags[25] == true)//ButtonAudio1_Tutorialから
        {
            spotlightPrefabPos.x = _buttonAudio1Pos.x;
            spotlightPrefabPos.z = _buttonAudio1Pos.z;

            transform.position = spotlightPrefabPos;
            _textTutorialText.text = ("電気ショックの充電が終わるまで人に触らないでください\n場合によっては電気ショックは行われない場合があります");
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
            //1/20現在テキストの変更は反映されていない
            _textTutorialText.text = ("音に合わせて光っている場所を押し込んでください");

            time_1 += Time.deltaTime;
            if (time_1 > changeTextTime_1)//3秒経過したら
            {
                _textTutorialText.text = ("押し込むタイミングが早い時はFast\n遅い時はSlow、正しい時はGoodと表示されます");
            }
            if (changeTextTime_1 > (changeTextTime_1 + 3.0f))//6秒経過したら
            {
                _textTutorialText.text = ("表示されるのは圧迫深さが-5cm～-6cmになったときです");
            }

            //_CPRAudiopos10
        }
        if (FlagManager.Instance.flags[29] == true)//CPRAudio_Tutorialから
        {

            spotlightPrefabPos.x = _CPRAudiopos.x;
            spotlightPrefabPos.z = _CPRAudiopos.z;

            transform.position = spotlightPrefabPos;

            _textTutorialText.text = ("5回押し込んでください");
        }//11

        if (FlagManager.Instance.flags[30] == true)//CPRAudio_Tutorialから
        {
            spotlightPrefabPos.x = _buttonAudio1Pos.x;
            spotlightPrefabPos.z = _buttonAudio1Pos.z;

            transform.position = spotlightPrefabPos;
            _textTutorialText.text = ("心電図の解析が終わるまで人に触らないでください");

        }//12

        if (FlagManager.Instance.flags[31] == true)//CPRAudio_Tutorialから
        {

            spotlightPrefabPos.x = _CPRAudiopos.x;
            spotlightPrefabPos.z = _CPRAudiopos.z;

            transform.position = spotlightPrefabPos;

            _textTutorialText.text = ("音に合わせて光っている場所を押し込んでください");

            time_2 += Time.deltaTime;
            if (time_2 > chageTextTime_2)//3秒経過したら
            {
                _textTutorialText.text = ("押し込むタイミングが早い時はFast\n遅い時はSlow、正しい時はGoodと表示されます");
            }
            if (time_2 > (chageTextTime_2 + 3.0f))//6秒経過したら
            {
                _textTutorialText.text = ("表示されるのは圧迫深さが-5cm～-6cmになったときです");
            }

        }//_CPRAudiopos13


        if (FlagManager.Instance.flags[40] == true)//CPRAudio_Tutorialから
        {
            _textTutorialText.text = ("チュートリアルは終了です");
            _backStartSceneColliderRend.material.color = new Color(1, 1, 1, 1);//BackStartSceneColliderの色を白、不透明に
            _backStartSceneText.color = new Color(0, 0, 0, 1);//BackStartSceneのTextの色を黒、不透明に

        }

    }//Update()ここまで
}