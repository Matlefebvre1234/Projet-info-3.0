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
       argentJoueur = PlayerPrefs.GetInt("Argent Joueur");
       argentTexte.GetComponent<Text>().text = (argentJoueur.ToString());     
    }

    public void ArgentJoueurs(int argent)
    {
        argentJoueur += argent;
        argentTexte.GetComponent<Text>().text = (argentJoueur.ToString());
        PlayerPrefs.SetInt("Argent Joueur", argentJoueur);
    }
}
