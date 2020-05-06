using System;
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

    float speed = 10.0f;
    public GameObject shield;


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

        //lookDirection = (targetPlayer.position).normalized;
        //shield.transform.Translate(lookDirection * Time.deltaTime * speed);

        target = GameObject.FindWithTag("Player").transform;

        //move towards the player
        shieldd.position += shieldd.forward * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && PlayerPrefs.GetInt("Mana") >= 100)
        {
            Debug.Log("Shield");
            Instantiate(shield, targetPlayer.position, Quaternion.identity);

            PlayerPrefs.SetInt("Mana", PlayerPrefs.GetInt("Mana") - 100);
            //player.GetComponent<BarreMana>().SetMana(PlayerPrefs.GetInt("Mana"));
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
