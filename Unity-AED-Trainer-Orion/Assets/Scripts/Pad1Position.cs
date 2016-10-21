using UnityEngine;
using System.Collections;

//HandPosition.csで取得した手の座標をパッド1に入れる
public class Pad1Position : MonoBehaviour
{

    public bool pad1col = false;
    //private float sizef = 5.669878f;
    private float sizef = 5.0f;


    private Vector3 pos;

    public AudioSource AudioSource5;
    public AudioSource AudioSource6;


    LeapHandCollision hc = new LeapHandCollision();

    // Use this for initialization
    void Start()
    {

        //if(ふたがあいていて、二枚のパッドが両方とも貼り付けられていなければ)
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
        //if(手がふれていてかつふたが開いているなら)
        if ( hc.IsHand(pad1col) && FlagManager.Instance.flags[0] == true)
            FlagManager.Instance.flags[1] = true;

    }


    // Update is called once per frame
    void Update()
    {

        //if(パッド1に手がふれていてかつパッド1が貼り付けられていなければ)
        if (FlagManager.Instance.flags[1] == true && FlagManager.Instance.flags[2] == false)
        {

            //HandPosition.cs取得
            HandPosition HAND = GetComponent<HandPosition>();


            //パッド位置に手の位置を入れる

           pos = this.transform.position;


            //研究室PC用の数値
            //pos.x = 1 - (sizef * HAND.ConvertPosition.x);
            //pos.y = 0.001f - (sizef * HAND.ConvertPosition.y);
            //pos.z = 3.05f + (sizef * HAND.ConvertPosition.z);

            pos.x =   HAND.ConvertPosition.x;
            pos.y =   HAND.ConvertPosition.y;
            pos.z =   HAND.ConvertPosition.z;


            transform.position = pos;
            
        }
    }

    void OnGUI()
    {
        string padlabel = "現在のパッドの座標は" + pos;
        GUI.Label(new Rect(0, 100, 200, 50), padlabel);  //Rect(x , y , Width , Height)
    }
}
