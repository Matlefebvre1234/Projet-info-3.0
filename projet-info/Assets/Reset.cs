using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public DifficulteScript difficulté;
    public Musique musique;
    public EffetSonores effetSonore;
    public GameObject verification;
    //public Button oui;
    //public Button non;

    public Slider sliderMusique;
    public Slider sliderEffetSonore;

    bool choix = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (choix == true)
        {
            PlayerPrefs.SetInt("Argent Joueur", 0);
            PlayerPrefs.SetInt("Argent Joueur Skin", 0);
            PlayerPrefs.SetInt("Niveau Difficulté", 1);
            PlayerPrefs.SetInt("Skin", 0);
            PlayerPrefs.SetInt("Skin_1", 0);
            PlayerPrefs.SetInt("Skin_2", 0);
            PlayerPrefs.SetInt("Skin_3", 0);
            PlayerPrefs.SetInt("Skin_4", 0);
            PlayerPrefs.SetFloat("Mana", 0);
            PlayerPrefs.SetInt("Niveau", 1);
            PlayerPrefs.SetInt("Skin choisit", 0);
            PlayerPrefs.SetInt("Sort Ultime", 0);
            PlayerPrefs.SetFloat("effetsSonores", 1);
            PlayerPrefs.SetFloat("Musique", 1);

            musique.SetVolume(1);
            effetSonore.SetVolume(1);

            sliderMusique.value = 1;
            sliderEffetSonore.value = 1;

            difficulté.Reset();

            choix = false;
        }
    }

    public void Zero()
    {
        Verification();
    }

    public void Verification()
    {
        verification.SetActive(true);
    }

    public void OnClicked(Button button)
    {
        if(button.name == "Oui")
        {
            choix = true;
            verification.SetActive(false);
        }
        else if(button.name == "Non")
        {
            choix = false;
            verification.SetActive(false);
        }
    }
}
