﻿using UnityEngine;
using System.Collections;

public class TempoSound : MonoBehaviour
{

    public AudioSource AudioSource20;
    public double looptime;
    // Use this for initialization

    void Start()
    {
        looptime = 0.5;

        AudioSource[] audioSources = this.GetComponents<AudioSource>();
        AudioSource20 = audioSources[0];

        AudioSource20.playOnAwake = false;
        AudioSource20.loop = true;
        AudioSource20.PlayScheduled(looptime);
    }

    // Update is called once per frame
    void Update()
    {

        //for debug
        Debug.Log(AudioSource20.isPlaying);
    }
}
