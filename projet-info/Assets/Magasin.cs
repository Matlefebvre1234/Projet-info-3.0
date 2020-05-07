using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magasin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Skin", 0);
        PlayerPrefs.SetInt("Niveau", 1);
        PlayerPrefs.SetInt("Sort Ultime", 0);
    }

    public void OnClicked(Button button)
    {
        if (button.name == "Skin_1")
        {
            if (PlayerPrefs.GetInt("Argent Joueur Skin") >= 1000)
            {
                Debug.Log("Skin_1");
                PlayerPrefs.SetInt("Skin", 1);
                PlayerPrefs.SetInt("Argent Joueur Skin", PlayerPrefs.GetInt("Argent Joueur Skin") - 1000);
            }
        }
        else if (button.name == "Skin_2")
        {
            if (PlayerPrefs.GetInt("Argent Joueur Skin") >= 1000)
            {
                PlayerPrefs.SetInt("Skin", 2);
                PlayerPrefs.SetInt("Argent Joueur Skin", PlayerPrefs.GetInt("Argent Joueur Skin") - 1000);
            }

        }
        else if (button.name == "Skin_3")
        {
            if (PlayerPrefs.GetInt("Argent Joueur Skin") >= 1000)
            {
                PlayerPrefs.SetInt("Skin", 3);
                PlayerPrefs.SetInt("Argent Joueur Skin", PlayerPrefs.GetInt("Argent Joueur Skin") - 1000);
            }
        }
        else if (button.name == "Skin_4")
        {
            if (PlayerPrefs.GetInt("Argent Joueur Skin") >= 1000)
            {
                PlayerPrefs.SetInt("Skin", 4);
                PlayerPrefs.SetInt("Argent Joueur Skin", PlayerPrefs.GetInt("Argent Joueur Skin") - 1000);
            }
        }
        else if (button.name == "Niveau")
        {
            if (PlayerPrefs.GetInt("Argent Joueur Skin") >= 5000)
            {
                PlayerPrefs.SetInt("Niveau", PlayerPrefs.GetInt("Niveau") + 1);
                PlayerPrefs.SetInt("Argent Joueur Skin", PlayerPrefs.GetInt("Argent Joueur Skin") - 5000);
            }
        }
        else if (button.name == "SortUltime")
        {
            if (PlayerPrefs.GetInt("Argent Joueur Skin") >= 1000000)
            {
                Debug.Log("sort ultime");
                PlayerPrefs.SetInt("Sort Ultime", 1);
                PlayerPrefs.SetInt("Argent Joueur Skin", PlayerPrefs.GetInt("Argent Joueur Skin") - 1000000);
            }
        }
        
    }
}
