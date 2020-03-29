using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArgentScript : MonoBehaviour
{
    public int montantArgent = 0;

    public GameObject argentTexte;

    int argent;

    bool valeur;
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.GetComponent<Santé>().IsDead(valeur))
        {
            //Donner argent au joueur
            argent = (int.Parse(argentTexte.GetComponent<Text>().text.ToString()));
            argent += montantArgent;
            argentTexte.GetComponent<Text>().text = (argent.ToString());

            ////Permet de sauvegardé un float avec la clé Score int et le chiffre 30
            PlayerPrefs.SetInt("Argent Joueur", argent);

        }
        else if (gameObject.transform.GetComponent<Santé>().santee <= 0)
        {
            argent = (int.Parse(argentTexte.GetComponent<Text>().text.ToString()));
            argent += montantArgent;
            argentTexte.GetComponent<Text>().text = (argent.ToString());

            ////Permet de sauvegardé un float avec la clé Score int et le chiffre 30
            PlayerPrefs.SetInt("Argent Joueur", argent);
        }

        argentTexte.GetComponent<Text>().text = (argent.ToString());
    }
}
