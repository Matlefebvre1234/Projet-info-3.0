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

    private void Start()
    {
        if (!audioSrc.isPlaying.Equals(true))
        {
            musiqueVol = audioSrc.volume;
            musiqueVol = PlayerPrefs.GetFloat("Musique");
        }
    }

    private void Update()
    {
        audioSrc.volume = musiqueVol;
        PlayerPrefs.SetFloat("Musique", musiqueVol);
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
