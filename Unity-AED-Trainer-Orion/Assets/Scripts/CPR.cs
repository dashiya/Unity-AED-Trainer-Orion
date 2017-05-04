using UnityEngine;
using System.Collections;


// for chest complession and announcemennt
public class CPR : MonoBehaviour
{

    public AudioSource AudioSource12;
    public AudioSource AudioSource13;
    public AudioSource AudioSource14;
    public AudioSource AudioSource15;
    public AudioSource AudioSource16;
    public AudioSource AudioSource17;
    public AudioSource AudioSource18;
    public AudioSource AudioSource19;
    public AudioSource AudioSource20;

    private bool isplayed = false;

    public float timeOut = 0.5f;
    private float timeProgress;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FuncCoroutine());

        //音声とりこみ
        AudioSource[] audioSources = this.GetComponents<AudioSource>();


        AudioSource12 = audioSources[0];
        AudioSource13 = audioSources[1];
        AudioSource14 = audioSources[2];
        AudioSource15 = audioSources[3];
        AudioSource16 = audioSources[4];
        AudioSource17 = audioSources[5];
        AudioSource18 = audioSources[6];
        AudioSource19 = audioSources[7];
        AudioSource20 = audioSources[8];
    }


    IEnumerator FuncCoroutine()
    {
        while (true)
        {
            // Do anything
            AudioSource20.Play();

            yield return new WaitForSeconds(timeOut);
        }
    }
    // Update is called once per frame
    void Update()
    {



        ulong time = 128 * 100 * 22;
        ulong delaytime = 128 * 100 * 30;

        // if (FlagManager.Instance.flags[7] == true && isplayed == false) デバック用にコメントアウト

        if (isplayed == false)
        {
            AudioSource12.Play(delaytime);



            AudioSource13.Play(delaytime + time * 2);
            AudioSource13.Play(delaytime + time * 3);
            AudioSource13.Play(delaytime + time * 4);

            AudioSource14.Play(delaytime + time * 5);


            AudioSource15.Play(delaytime + time * 6);
            AudioSource15.Play(delaytime + time * 7);

            AudioSource16.Play(delaytime + time * 8);


            AudioSource17.Play(delaytime + time * 9);


            AudioSource18.Play(delaytime + time * 11);
            AudioSource18.Play(delaytime + time * 12);


            AudioSource19.Play(delaytime + time * 13);



            isplayed = true;


        }

    }

}



