using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffetSonores : MonoBehaviour
{
    public AudioSource audioSrc;
    public Slider sliderEffetSonore;
    public float effetsVol = 1f;
    

    private void Start()
    {
        if (this.transform.gameObject.tag == "Musique")
        {
            sliderEffetSonore.value = (PlayerPrefs.GetFloat("effetsSonores"));
        }
        
        if (!audioSrc.isPlaying.Equals(true))
        {            
            effetsVol = audioSrc.volume;
            effetsVol = PlayerPrefs.GetFloat("effetsSonores");
        }
        else
        {
            effetsVol = PlayerPrefs.GetFloat("effetsSonores");
        }
    }

    // Update is called once per frame
    void Update()
    {        
        audioSrc.volume = effetsVol;
        PlayerPrefs.SetFloat("effetsSonores", effetsVol);
        Debug.Log("Effets sonores volume = " + PlayerPrefs.GetFloat("effetsSonores"));
    }

    public void SetVolume(float vol)
    {
        effetsVol = vol;
    }
}
