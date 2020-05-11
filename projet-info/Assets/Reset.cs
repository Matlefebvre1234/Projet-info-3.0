using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public DifficulteScript difficulté;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Zero()
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

        difficulté.Reset();

        Debug.Log("Reset = ok !");

    }
}
