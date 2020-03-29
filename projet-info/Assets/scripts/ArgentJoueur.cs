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
        if(argentJoueur != 0)
        {
            argentJoueur = PlayerPrefs.GetInt("Argent Joueur");
            argentTexte.GetComponent<Text>().text = (argentJoueur.ToString());
        }
        else
        {
            PlayerPrefs.SetInt("Argent Joueur", 0);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ArgentJoueurs(int argent)
    {
        argentJoueur += argent;
        Debug.Log("argent = " + argentJoueur);
        argentTexte.GetComponent<Text>().text = (argentJoueur.ToString());
        PlayerPrefs.SetInt("Argent Joueur", argentJoueur);
    }
}
