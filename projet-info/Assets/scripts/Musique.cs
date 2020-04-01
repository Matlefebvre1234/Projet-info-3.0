using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musique : MonoBehaviour
{
    public AudioSource audioSrc;
    private float musiqueVol = 1f;

    private void Update()
    {
        audioSrc.volume = musiqueVol;
    }

    public void SetVolume(float vol)
    {
        musiqueVol = vol;
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
