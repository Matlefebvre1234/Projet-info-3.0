using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArgentJoueur : MonoBehaviour
{
    public int argentJoueur = 0;

    public GameObject argentTexte;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Argent Joueur", 0);
        argentJoueur = 0;
        argentTexte.GetComponent<Text>().text = (argentJoueur.ToString());
        PlayerPrefs.SetInt("Argent Joueur", 0);
    }

    public void ArgentJoueurs(int argent)
    {
        int argentJoueur;
        argentJoueur = argent + PlayerPrefs.GetInt("Argent Joueur");
        argentTexte.GetComponent<Text>().text = (argentJoueur.ToString());
        PlayerPrefs.SetInt("Argent Joueur", argentJoueur);
        PlayerPrefs.SetInt("Argent Joueur Skin", PlayerPrefs.GetInt("Argent Joueur Skin") + argent);
    }



    public int GetArgent()
    {
        return argentJoueur;
        Debug.Log(argentJoueur);
    }

    public void Achat(int cout)
    {
        argentJoueur -= cout;
    }
}
