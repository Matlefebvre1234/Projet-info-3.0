using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventaire : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject argentTexte;

    Text txt;

    //Stop all sounds
    private AudioSource[] allAudioSources;

    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    void PlaypAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Play();
        }
    }

    public GameObject MenuInventaireUI;

    // Start is called before the first frame update
    void Start()
    {
        //argentTexte.gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("Argent Joueur").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        argentTexte.gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Argent Joueur").ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            //GameIsPaused = true;

            //Resume();
        }

       
    }

    public void Resume()
    {
        MenuInventaireUI.SetActive(false);

        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    void Pause()
    {
        MenuInventaireUI.SetActive(true);

        Time.timeScale = 0f;

        GameIsPaused = true;
    }
}
