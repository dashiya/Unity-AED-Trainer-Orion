using UnityEngine;
using System.Collections;



//HandPosition.cs�Ŏ擾������̂Ђ�̍��W���p�b�h�ɑ�����ē�����
public class Pad1Position : MonoBehaviour
{

    public bool pad1col = false;
 
    private Vector3 pos;

    public AudioSource AudioSource5;
    public AudioSource AudioSource6;


    LeapHandCollision hc = new LeapHandCollision();

    // Use this for initialization
    void Start()
    {

        //if(�ӂ��������Ă��āA�񖇂̃p�b�h�������Ƃ��\��t�����Ă��Ȃ����)
        if (FlagManager.Instance.flags[0] == true && FlagManager.Instance.flags[4] == false)
        {
            for (int i = 1; i <= 3; i++)
            {
                AudioSource[] audioSources = GetComponents<AudioSource>();

                AudioSource6 = audioSources[5];
            }

            AudioSource6.Play(640000 * 3);
        }
    }




    void OnTriggerEnter(Collider pad1col)
    {
        //if(�肪�ӂ�Ă��Ă��ӂ����J���Ă���Ȃ�)
        if ( hc.IsHand(pad1col) && FlagManager.Instance.flags[0] == true)
            FlagManager.Instance.flags[1] = true;

    }


    // Update is called once per frame
    void Update()
    {

        //if(�p�b�h1�Ɏ肪�ӂ�Ă��Ă��p�b�h1���\��t�����Ă��Ȃ����)
        if (FlagManager.Instance.flags[1] == true && FlagManager.Instance.flags[2] == false)
        {

            //HandPosition.cs�擾
            HandPosition HAND = GetComponent<HandPosition>();


            //pos�̓p�b�h�ʒu

           pos = this.transform.position;


            //������PC�p�̐��l
            //pos.x = 1 - (sizef * HAND.ConvertPosition.x);
            //pos.y = 0.001f - (sizef * HAND.ConvertPosition.y);
            //pos.z = 3.05f + (sizef * HAND.ConvertPosition.z);

            pos.x =   HAND.ConvertPosition.x;
            pos.y =   HAND.ConvertPosition.y;
            pos.z =   HAND.ConvertPosition.z;


            transform.position = pos;
            
        }
    }
    
}
