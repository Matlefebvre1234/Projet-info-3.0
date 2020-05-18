using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toile : MonoBehaviour
{
    private MouvementJoueur mouv;
    public float division = 5f;
    void Start()
    {
        mouv = GameObject.FindGameObjectWithTag("Player").GetComponent<MouvementJoueur>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            mouv.vitesseJoueur = mouv.vitesseJoueur / division;
        }         
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            mouv.vitesseJoueur = mouv.vitesseJoueur * division;
        }        
    }
}
