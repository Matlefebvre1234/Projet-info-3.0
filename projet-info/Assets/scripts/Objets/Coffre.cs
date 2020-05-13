using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffre : MonoBehaviour
{
    public Animator coffreAnimerPlein;
    public Animator coffreAnimerVide;

    private bool coffreOuvert;
    private bool coffreFermer;

    public string nomCoffre;

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        coffreOuvert = false;
        coffreFermer = false;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (coffreOuvert == false)
            {
                if (nomCoffre == "Easter Eggs_1")
                {
                    if (PlayerPrefs.GetInt("Easter Eggs_1") == 0)
                    {
                        PlayerPrefs.SetInt("Argent Joueur", PlayerPrefs.GetInt("Argent Joueur") + 10000);
                        Player.GetComponent<Mana>().SetManaJoueur(200);
                        Player.GetComponent<Santé>().SetSantee(300, 300);
                        PlayerPrefs.SetInt("Easter Eggs_1", 1);
                        coffreAnimerPlein.SetBool("coffre", true);
                        coffreOuvert = true;
                    }
                    else
                    {
                        coffreAnimerVide.SetBool("coffre vide", true);
                    }

                }
                if (nomCoffre == "Easter Eggs_2")
                {
                    if (PlayerPrefs.GetInt("Easter Eggs_2") == 0)
                    {
                        PlayerPrefs.SetInt("Argent Joueur", PlayerPrefs.GetInt("Argent Joueur") + 10000);
                        Player.GetComponent<Mana>().SetManaJoueur(200);
                        Player.GetComponent<Santé>().SetSantee(300, 300);
                        PlayerPrefs.SetInt("Easter Eggs_2", 1);
                        coffreAnimerPlein.SetBool("coffre", true);
                        coffreOuvert = true;
                    }
                    else
                    {
                        coffreAnimerVide.SetBool("coffre vide", true);
                    }
                }
                if (nomCoffre == "Easter Eggs_3")
                {
                    if (PlayerPrefs.GetInt("Easter Eggs_3") == 0)
                    {
                        PlayerPrefs.SetInt("Argent Joueur", PlayerPrefs.GetInt("Argent Joueur") + 10000);
                        Player.GetComponent<Mana>().SetManaJoueur(200);
                        Player.GetComponent<Santé>().SetSantee(300, 300);
                        PlayerPrefs.SetInt("Easter Eggs_3", 1);
                        coffreAnimerPlein.SetBool("coffre", true);
                        coffreOuvert = true;
                    }
                    else
                    {
                        coffreAnimerVide.SetBool("coffre vide", true);
                    }
                }

            }

            if (coffreOuvert == true)
            {
                coffreAnimerVide.SetBool("coffre vide", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (coffreFermer == false)
        {
            coffreAnimerPlein.SetBool("coffre", false);
            coffreFermer = true;
        }
        if (coffreFermer == true)
        {
            coffreAnimerVide.SetBool("coffre vide", false);
        }
    }
}
