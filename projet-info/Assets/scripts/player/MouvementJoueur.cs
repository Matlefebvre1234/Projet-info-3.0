using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    public float vitesseJoueur = 1;
    Rigidbody2D mrb;
    float deplacementX;
    float deplacementY;
    // Start is called before the first frame update
    void Start()
    {
        mrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         deplacementX = Input.GetAxis("Horizontal");
         deplacementY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        mrb.velocity = new Vector2(deplacementX * vitesseJoueur, deplacementY * vitesseJoueur);
    }
    private void Mouvement()
    {
        float deplacementX = Input.GetAxis("Horizontal") * Time.deltaTime * vitesseJoueur;
        //float EmplacementActuelleX = transform.position.x + deplacementX;

        float deplacementY = Input.GetAxis("Vertical") * Time.deltaTime * vitesseJoueur;
      //  float EmplacementActuelleY = transform.position.y + deplacementY;

        //  transform.position = new Vector2(EmplacementActuelleX, EmplacementActuelleY);
       

       
    }

    public void PlusVitesse(float plusVitesse)
    {
        vitesseJoueur = plusVitesse;
    }
}
