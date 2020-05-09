using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musique : MonoBehaviour
{
    private static Musique instance = null;
    public static Musique Instance
    {
        get
        {
            return instance;
        }
    }

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
        Debug.Log(instance);
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }


        DontDestroyOnLoad(transform.gameObject);
    }
}
