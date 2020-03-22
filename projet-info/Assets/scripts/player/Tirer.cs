using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirer : MonoBehaviour
{
    public int dommage = 30;
    public GameObject projectile;
    public float reloadTime = 0.5f;
    private float tempreload = 0f;
    private AIMouvement mousePos;
    Animator ani;
    SpriteRenderer sprite;

    private void Start()
    {
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        flipSprite();
        tempreload += 1 * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (tempreload >= reloadTime)
            {
                
                tirer();
                tempreload = 0;
               // mousePos.setMousePosition(Input.mousePosition);
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
