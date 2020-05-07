﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    public float vitesseJoueur = 1;
    Rigidbody2D mrb;
    float deplacementX;
    Animator ani;
    SpriteRenderer sprite;
    float deplacementY;

    public Transform targetPlayer;
    Vector3 lookDirection;

    Transform target;
    public Transform shieldd;

    float speed = 100.0f;
    public GameObject shield;
    GameObject shieldClone;
    public BarreMana barreMana;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        mrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        deplacementX = Input.GetAxis("Horizontal");
         deplacementY = Input.GetAxis("Vertical");
        if (deplacementX != 0 || deplacementY != 0) ani.SetBool("isRunning", true);
        else ani.SetBool("isRunning", false);
        if (deplacementX > 0) sprite.flipX = true;
        if (deplacementX < 0) sprite.flipX = false;

        // Permet de générer un shield de magie qui protège !
        target = GameObject.FindWithTag("Player").transform;

        if (Input.GetKeyDown(KeyCode.Space) && PlayerPrefs.GetInt("Mana") >= 100)
        {
            if (shieldClone != null)
            {
                //Nothing
            }
            else
            {
                shieldClone = Instantiate(shield, target.position, Quaternion.identity);


                PlayerPrefs.SetInt("Mana", PlayerPrefs.GetInt("Mana") - 100);
                barreMana.GetComponent<BarreMana>().SetMana(PlayerPrefs.GetInt("Mana"));
            }
        }       

        if (shieldClone != null)
        {
            shieldClone.transform.position = Vector2.MoveTowards(shieldClone.transform.position, target.position, speed * Time.deltaTime);
        }

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
