using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArgentScript : MonoBehaviour
{
    public int montantArgent = 0;

    public GameObject argentTexte;

    bool valeur;
    // Update is called once per frame
    void Update()
    {
        if(transform.GetComponent<Santé>().IsDead(valeur))
        {
            //Donner argent au joueur
            int argent;
            argent = (int.Parse(argentTexte.GetComponent<Text>().text.ToString()));
            argent += montantArgent;
            argentTexte.GetComponent<Text>().text = (argent.ToString());

            ////Permet de sauvegardé un float avec la clé Score int et le chiffre 30
            PlayerPrefs.SetInt("Argent Joueur", argent);

        }
        else if (transform.GetComponent<Santé>().santee <= 0)
        {
            int argent;
            argent = (int.Parse(argentTexte.GetComponent<Text>().text.ToString()));
            argent += montantArgent;
            argentTexte.GetComponent<Text>().text = (argent.ToString());

            ////Permet de sauvegardé un float avec la clé Score int et le chiffre 30
            PlayerPrefs.SetInt("Argent Joueur", argent);
        }
        }
    }
