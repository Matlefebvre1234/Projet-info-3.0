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


    private void Start()
    {
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        PlayerPrefs.SetInt("dommage projectile", dommage);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
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
                if(tirePuissant < 1.5f)
                {
                    dommage = PlayerPrefs.GetInt("dommage projectile");
                }
                else if (tirePuissant >= 1.5f && tirePuissant < 2.0f && PlayerPrefs.GetInt("Mana") >= 7)
                {
                    dommage = (int) (1.5f * PlayerPrefs.GetInt("dommage projectile"));
                    PlayerPrefs.SetInt("Mana", PlayerPrefs.GetInt("Mana") - 7);
                    player.GetComponent<Mana>().SetManaJoueur(-7);
                }
                else if(tirePuissant >= 2.0f && tirePuissant < 3.0f && PlayerPrefs.GetInt("Mana") >= 15)
                {
                    dommage = (int)(1.75f * PlayerPrefs.GetInt("dommage projectile"));
                    PlayerPrefs.SetInt("Mana", PlayerPrefs.GetInt("Mana") - 15);
                    player.GetComponent<Mana>().SetManaJoueur(-15);
                }
                else if (tirePuissant >= 3.0f && PlayerPrefs.GetInt("Mana") >= 20)
                {
                    dommage = (2 * PlayerPrefs.GetInt("dommage projectile"));
                    PlayerPrefs.SetInt("Mana", PlayerPrefs.GetInt("Mana") - 20);
                    player.GetComponent<Mana>().SetManaJoueur(-20);
                }

                tirer();
                tempreload = 0;
                tirePuissant = 0;                
            }           
        }
       
    }

    private void tirer()
    {
        ani.SetBool("isAttacking", true);

    }
    public void StopAttackAnimation()
    {
        Instantiate(projectile, (Vector2)transform.position - new Vector2(0,0.15f), Quaternion.identity);
        ani.SetBool("isAttacking", false);


    }

    public void AmeliorationAttaque(int attaque)
    {
        dommage = attaque;
        PlayerPrefs.SetInt("dommage projectile", dommage);
    }

    public int GetDommage()
    {
        return dommage;
    }

    public void AmeliorationReloadTime(float anneau)
    {
        reloadTime = anneau;
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
