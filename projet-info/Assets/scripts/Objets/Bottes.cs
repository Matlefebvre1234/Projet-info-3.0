using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottes : MonoBehaviour
{
    private GameObject joueur;
    public int vitesse = 5;

    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            joueur.transform.GetComponent<MouvementJoueur>().PlusVitesse(vitesse);
            Destroy(gameObject);
        }
    }
}
