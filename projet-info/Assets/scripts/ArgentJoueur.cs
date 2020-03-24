using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArgentJoueur : MonoBehaviour
{
    public int argentJoueur;

    public GameObject argentTexte;
    // Start is called before the first frame update
    void Start()
    {
        ////Permet de sauvegardé un float avec la clé Score float et le chiffre 30
        //PlayerPrefs.SetFloat("Score float", 30);
        //
        ////Permet de sauvegardé un float avec la clé Score int et le chiffre 30
        //PlayerPrefs.SetInt("Score int", 30);
        //
        ////Permet de sauvegardé un float avec la clé Texte et le string test
        //PlayerPrefs.SetString("Texte", "test");

        argentTexte.GetComponent<Text>().text = (argentJoueur.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        argentJoueur = PlayerPrefs.GetInt("Argent Joueur");
    }
}
