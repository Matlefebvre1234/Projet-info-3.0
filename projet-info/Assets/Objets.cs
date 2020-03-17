﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objets : MonoBehaviour
{
    private Animator animation;
    private GameObject joueur;
    private GameObject bottes;
    public float vitesse = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
        joueur = GameObject.FindGameObjectWithTag("Player");
        bottes = GameObject.FindGameObjectWithTag("Bottes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
           
            joueur.transform.GetComponent<MouvementJoueur>().PlusVitesse(vitesse);
            animation.SetBool("Obtenu", true);
            Destroy(bottes);
        }
    }
}
