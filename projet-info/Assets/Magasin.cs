using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magasin : MonoBehaviour
{
    public GameObject menuMagasin;
    public GameObject menuInventaire;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("Skin", 0);
        //PlayerPrefs.SetInt("Skin_1", 0);
        //PlayerPrefs.SetInt("Skin_2", 0);
        //PlayerPrefs.SetInt("Skin_3", 0);
        //PlayerPrefs.SetInt("Skin_4", 0);
        //PlayerPrefs.SetInt("Niveau", 1);
        //PlayerPrefs.SetInt("Sort Ultime", 0);
    }

    public void changerMenuInventaire()
    {
        if (!menuMagasin.activeSelf)
        {
            menuMagasin.SetActive(true);
            menuInventaire.SetActive(false);
            //createurSalle.SetActive(false);
        }
        else
        {
            menuMagasin.SetActive(false);
            menuInventaire.SetActive(true);
            //createurSalle.SetActive(true);

        }
    }



    public void OnClicked(Button button)
    {
        if (button.name == "Skin_1")
        {
            if (PlayerPrefs.GetInt("Argent Joueur Skin") >= 1000 && PlayerPrefs.GetInt("Skin_1") != 1)
            {
                //Rouge
                PlayerPrefs.SetInt("Skin_1", 1);
                PlayerPrefs.SetInt("Skin choisit", 1);
                PlayerPrefs.SetInt("Argent Joueur Skin", PlayerPrefs.GetInt("Argent Joueur Skin") - 1000);
            }
        }
        else if (button.name == "Skin_2")
        {
            if (PlayerPrefs.GetInt("Argent Joueur Skin") >= 1000 && PlayerPrefs.GetInt("Skin_2") != 1)
            {
                //Turquoise
                PlayerPrefs.SetInt("Skin_2", 1);
                PlayerPrefs.SetInt("Skin choisit", 2);
                PlayerPrefs.SetInt("Argent Joueur Skin", PlayerPrefs.GetInt("Argent Joueur Skin") - 1000);
            }
        }
        else if (button.name == "Skin_3")
        {
            //Jaune
            if (PlayerPrefs.GetInt("Argent Joueur Skin") >= 1000 && PlayerPrefs.GetInt("Skin_3") !=1)
            {
                PlayerPrefs.SetInt("Skin_3", 1);
                PlayerPrefs.SetInt("Skin choisit", 3);
                PlayerPrefs.SetInt("Argent Joueur Skin", PlayerPrefs.GetInt("Argent Joueur Skin") - 1000);
            }
        }
        else if (button.name == "Skin_4")
        {
            //Vert Foncé
            if (PlayerPrefs.GetInt("Argent Joueur Skin") >= 1000 && PlayerPrefs.GetInt("Skin_4") != 1)
            {
                PlayerPrefs.SetInt("Skin_4", 1);
                PlayerPrefs.SetInt("Skin choisit", 4);
                PlayerPrefs.SetInt("Argent Joueur Skin", PlayerPrefs.GetInt("Argent Joueur Skin") - 1000);
            }
        }
        else if (button.name == "Niveau")
        {
            if (PlayerPrefs.GetInt("Argent Joueur Skin") >= 5000 && PlayerPrefs.GetInt("Niveau") <=6)
            {
                PlayerPrefs.SetInt("Niveau", PlayerPrefs.GetInt("Niveau") + 1);
                PlayerPrefs.SetInt("Argent Joueur Skin", PlayerPrefs.GetInt("Argent Joueur Skin") - 5000);
            }
        }
        else if (button.name == "SortUltime" && PlayerPrefs.GetInt("Sort Ultime") != 1)
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
