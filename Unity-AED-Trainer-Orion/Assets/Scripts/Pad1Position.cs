using UnityEngine;


//HandPosition.cs�Ŏ擾������̂Ђ�̍��W���p�b�h�ɑ�����ē�����
public class Pad1Position : MonoBehaviour
{
    Vector3 _pad1Pos;
    HandPosition _handPos;

    AudioSource AudioSource5;
    AudioSource AudioSource6;

    public bool pad1col = false;

    LeapHandCollision _hc = new LeapHandCollision();

    // Use this for initialization
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        _handPos = GetComponent<HandPosition>();

        //if(�ӂ��������Ă��āA�񖇂̃p�b�h�������Ƃ��\��t�����Ă��Ȃ����)
        if (FlagManager.Instance.flags[0] == true && FlagManager.Instance.flags[4] == false)
        {
            AudioSource5 = audioSources[0];

            //AudioSource6�̓p�b�h���\���Ă��邪�A�p�b�h�̃R�l�N�^���ڑ�����Ă��Ȃ��ꍇ��
            //�����A�R�l�N�^���Č�����Ă��Ȃ�����ł͕s�v�Ȃ̂ŃR�����g�A�E�g
            // AudioSource6 = audioSources[1];

            AudioSource5.Play(640000 * 3); //(640000 * 3)�͂����悻��AudioSorce5�̍Đ�����
        }
    }

    void OnTriggerEnter(Collider pad1col)
    {
        if (_hc.IsHand(pad1col) && FlagManager.Instance.flags[0] == true) //if(�肪�ӂ�Ă��Ă��ӂ����J���Ă���Ȃ�)
        {
            FlagManager.Instance.flags[1] = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //if(�p�b�h1�Ɏ肪�ӂ�Ă��Ă��p�b�h1���\��t�����Ă��Ȃ����)
        if (FlagManager.Instance.flags[1] == true && FlagManager.Instance.flags[2] == false)
        {
            _pad1Pos = transform.position;

            _pad1Pos.x = _handPos.ConvertPosition.x;
            _pad1Pos.y = _handPos.ConvertPosition.y;
            _pad1Pos.z = _handPos.ConvertPosition.z;

            transform.position = _pad1Pos;
        }
    }
}