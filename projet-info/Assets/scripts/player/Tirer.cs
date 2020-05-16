using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirer : MonoBehaviour
{
    public int dommage = 30;
    public GameObject projectile;
    public float reloadTime = 0.5f;
    public float tirePuissant = 0f;
    private float tempreload = 0f;
    private AIMouvement mousePos;
    Animator ani;
    SpriteRenderer sprite;

    GameObject player;
    Color couleurProjectile;
    float vitesse;

    Rigidbody2D mrb;
    float deplacementX;
    float deplacementY;

    public float vitesseBalle = 1;

    public Vector3 grosseur = new Vector3(0.5f, 0.5f, 1f);

    private void Start()
    {
        dommage = 30;
        vitesseBalle = 1;
        mrb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        PlayerPrefs.SetInt("dommage projectile", dommage);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        deplacementX = Input.GetAxis("Horizontal");
        deplacementY = Input.GetAxis("Vertical");

        flipSprite();
        tempreload += 1 * Time.deltaTime;
        
        if(Input.GetMouseButton(0))
        {
            tirePuissant +=  Time.deltaTime;
        }
        else if (Input.GetMouseButtonUp(0))
        {           
            if (tempreload >= reloadTime)
            {
                if(tirePuissant < 1.5f || PlayerPrefs.GetFloat("Mana") < 7)
                {
                    dommage = 30;
                    grosseur = new Vector3(0.5f, 0.5f, 1f);
                    couleurProjectile = new Color(0, 1, 1, 1);
                }
                else if (tirePuissant >= 1f && tirePuissant < 2f && PlayerPrefs.GetFloat("Mana") >= 7)
                {
                    //Vert
                    dommage = (int) (1.5f * 30);
                    player.GetComponent<Mana>().SetManaJoueur(-7);
                    grosseur = new Vector3(0.60f, 0.60f, 1f);
                    couleurProjectile = new Color(0,1,0,1);
                }
                else if(tirePuissant >= 2f && tirePuissant < 3f && PlayerPrefs.GetFloat("Mana") >= 15)
                {
                    //Jaune
                    dommage = (int)(1.75f * 30);
                    player.GetComponent<Mana>().SetManaJoueur(-15);
                    grosseur = new Vector3(0.70f, 0.70f, 1f);
                    couleurProjectile = new Color(1, 0.92f, 0.016f, 1);
                }
                else if (tirePuissant >= 3f && PlayerPrefs.GetFloat("Mana") >= 20)
                {
                    //Rouge
                    dommage = (2 * 30);
                    player.GetComponent<Mana>().SetManaJoueur(-20);
                    grosseur = new Vector3(0.80f, 0.80f, 1f);
                    couleurProjectile = new Color(1, 0, 0, 1);
                }

                tirer();
                tempreload = 0;
                tirePuissant = 0;

                PlayerPrefs.SetInt("dommage projectile", dommage);
            }           
        }
       
    }

    //private void FixedUpdate()
    //{
    //    mrb.velocity = new Vector2(deplacementX * vitesseBalle, deplacementY * vitesseBalle);
    //}
    private void tirer()
    {
        ani.SetBool("isAttacking", true);

    }
    public void StopAttackAnimation()
    {
        GameObject medium;

        medium = Instantiate(projectile, (Vector2)transform.position - new Vector2(0,0.15f), Quaternion.identity);
        medium.transform.localScale = grosseur;
        medium.transform.GetComponent<SpriteRenderer>().color = couleurProjectile;
        //medium.GetComponent<Rigidbody2D>().velocity = new Vector2(deplacementX * vitesseBalle, deplacementY * vitesseBalle);
        //medium.GetComponent<Rigidbody2D>().AddForce(medium.transform.forward * (4000 * 1000));
        //medium.transform.Translate(Vector3.forward * 5 * 100);
        Debug.Log("Vitesse = " + vitesseBalle);
        ani.SetBool("isAttacking", false);
    }

    public void AmeliorationAttaque(int attaque)
    {
        if(dommage + attaque <= 150)
        dommage += attaque;
        PlayerPrefs.SetInt("dommage projectile", dommage);
    }

    public int GetDommage()
    {
        return dommage;
    }

    public Vector3 GetGrosseur()
    {
        return grosseur;
    }

    public void AmeliorationReloadTime(float anneau)
    {
        if (reloadTime - anneau >= 0.1) ;
        reloadTime -= anneau;
    }

    public void AmeliorationVitesse(float vitesse)
    {
        vitesseBalle += vitesse;
    }

    public void flipSprite()
    {
        
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if ((angle < 90 && angle >= 0) || (angle > -90 && angle < 0))
        {
            sprite.flipX = true;

        }

        if ((angle > 90 && angle < 180) || (angle > -180 && angle < -90))
        {
            sprite.flipX = false;

        }


    }
}
