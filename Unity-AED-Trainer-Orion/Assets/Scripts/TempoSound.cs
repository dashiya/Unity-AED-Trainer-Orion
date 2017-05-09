using UnityEngine;
using System.Collections;

public class TempoSound : MonoBehaviour
{

    public AudioSource AudioSource20;
    

    public bool isTempoPlay;

    // Use this for initialization

    void Start()
    {
       

        AudioSource[] audioSources = this.GetComponents<AudioSource>();
        AudioSource20 = audioSources[0];

        
        AudioSource20.playOnAwake = false;
   


    }

    // Update is called once per frame
    void Update()
    {
        if( isTempoPlay == false)
        {
            double looptime = 0.5;
            AudioSource20.loop = true;
            AudioSource20.PlayScheduled(looptime);
            isTempoPlay = true;
        }
    }
}
    