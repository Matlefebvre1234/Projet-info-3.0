﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineObjet : MonoBehaviour
{
    public int cout;
    public GameObject objet;
    private GameObject joueur;

    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && joueur.GetComponent<ArgentJoueur>().GetArgent() > cout)
        {
            Instantiate(objet, transform.position - new Vector3(0, 0.934f, 1), Quaternion.identity);
        }
    }
}