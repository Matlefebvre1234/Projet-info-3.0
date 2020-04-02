﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetSonores : MonoBehaviour
{
    public AudioSource audioSrc;
    private float effetsVol = 1f;
    

    private void Start()
    {
        effetsVol = audioSrc.volume;
        effetsVol = PlayerPrefs.GetFloat("effetsSonores");
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = effetsVol;
        PlayerPrefs.SetFloat("effetsSonores", effetsVol);
    }

    public void SetVolume(float vol)
    {
        effetsVol = vol;
    }
}
