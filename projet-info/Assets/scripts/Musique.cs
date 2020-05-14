using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider sliderMusique;

    private float musiqueVol = 1f;

    private void Start()
    {
        if(this.transform.gameObject.tag == "Musique")
        {
            sliderMusique.value = PlayerPrefs.GetFloat("Musique");
        }

        if (!audioSrc.isPlaying.Equals(true))
        {
            
            musiqueVol = audioSrc.volume;
            musiqueVol = PlayerPrefs.GetFloat("Musique");
        }
        else
        {
            musiqueVol = PlayerPrefs.GetFloat("Musique");
        }

    }

    private void Update()
    {
        audioSrc.volume = musiqueVol;
        PlayerPrefs.SetFloat("Musique", musiqueVol);
        Debug.Log("musique volume = " + PlayerPrefs.GetFloat("Musique"));

    }

    public void SetVolume(float vol)
    {
        musiqueVol = vol;
    }

    void Awake()
    {
        if (!audioSrc.isPlaying.Equals(true))
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
}
