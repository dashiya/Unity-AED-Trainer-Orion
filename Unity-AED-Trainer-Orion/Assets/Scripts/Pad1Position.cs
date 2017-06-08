using UnityEngine;


//HandPosition.cs�Ŏ擾������̂Ђ�̍��W���p�b�h�ɑ�����ē�����
public class Pad1Position : MonoBehaviour
{
    public AudioSource AudioSource5;
    public AudioSource AudioSource6;

    private Vector3 pad1Pos;

    public bool pad1col = false;

    LeapHandCollision hc = new LeapHandCollision();

    // Use this for initialization
    void Start()
    {

        //if(�ӂ��������Ă��āA�񖇂̃p�b�h�������Ƃ��\��t�����Ă��Ȃ����)
        if (FlagManager.Instance.flags[0] == true && FlagManager.Instance.flags[4] == false)
        {
            AudioSource[] audioSources = GetComponents<AudioSource>();

            AudioSource5 = audioSources[0];
            //AudioSource6�̓p�b�h���\���Ă��邪�A�p�b�h�̃R�l�N�^���ڑ�����Ă��Ȃ��ꍇ��
            //�����Ȃ̂ŁAAttach�͂��邪����s�v�Ȃ̂ŃR�����g�A�E�g
            // AudioSource6 = audioSources[1];

            //(640000 * 3)�͂����悻��AudioSorce5�̍Đ�����
            AudioSource5.Play(640000 * 3);
        }
    }

    void OnTriggerEnter(Collider pad1col)
    {
        //if(�肪�ӂ�Ă��Ă��ӂ����J���Ă���Ȃ�)
        if (hc.IsHand(pad1col) && FlagManager.Instance.flags[0] == true)
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
            HandPosition handPos = GetComponent<HandPosition>();

            pad1Pos = this.transform.position;

            pad1Pos.x = handPos.ConvertPosition.x;
            pad1Pos.y = handPos.ConvertPosition.y;
            pad1Pos.z = handPos.ConvertPosition.z;

            this.transform.position = pad1Pos;

        }
    }
}
