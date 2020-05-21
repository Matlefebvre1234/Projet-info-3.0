﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvocateurInvoque : MonoBehaviour
{
    public float nbCaseDistance = 8.0f;
    public float speedInitial = 5f;
    private float speed;
    private PathfindingInverse pathfinding;
    private matPathfinding pathfingRapprochement;
    private SpriteRenderer spriterenderer;
    private Animator animatorInvocateur;
    public GameObject projectile;
    public float reloadTime = 20f;
    private float timeBeforeReaload = 0;
    private bool isMoving = false;
    public GameObject bloob;
    public int nombreMaxBloobs = 5;
    public int nombreBloobPresent = 0;
    public float santeMax = 100f;
    private float sante;
    private float dimCell;
    private bool isTakingDommage = false;
    private InvocateurModifierBoss boss;




    List<MatNode> chemin;
    int index = 1;
    Vector3 positionSouris;

    GameObject player;
    bool cheminAtteint = false;

    void Start()
    {
        dimCell = FindObjectOfType<GrilleMonstresMat>().getdimCell();
        sante = santeMax;
        speed = speedInitial;
        pathfinding = new PathfindingInverse();
        pathfingRapprochement = new matPathfinding();
        spriterenderer = GetComponent<SpriteRenderer>();
        animatorInvocateur = GetComponent<Animator>();
        speed = speed * Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player");

    }



    private void Update()
    {
        flipSprite();

        timeBeforeReaload = timeBeforeReaload + 1 * Time.deltaTime;
        speed = speedInitial;
        speed = speed * Time.deltaTime;
        EloignerPlayer();

        if (timeBeforeReaload >= reloadTime && isMoving == false && nombreBloobPresent < nombreMaxBloobs)
        {

            Invoquer();
            timeBeforeReaload = 0;
        }


    }


    public void Invoquer()
    {
        animatorInvocateur.SetBool("attack", true);



    }

    private void stopAttackAnimation()
    {
        animatorInvocateur.SetBool("attack", false);
        GameObject bloob2 = Instantiate(bloob, transform.position, Quaternion.identity);
        BloobBoss scriptBloob2 = bloob2.GetComponent<BloobBoss>();
        scriptBloob2.setInvocateur(gameObject);

        nombreBloobPresent++;
    }

    private void EloignerPlayer()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= (nbCaseDistance * dimCell) || isTakingDommage == true)
        {

            cheminAtteint = false;
            isTakingDommage = false;
            pathfinding.limiteDistance = 0;
            if (pathfinding.getGrid() == null) Debug.Log("null");
            pathfinding.getGrid().GetXY(transform.position, out int x1, out int y1);
            pathfinding.getGrid().GetXY(player.transform.position, out int x2, out int y2);
            index = 1;
            chemin = pathfinding.FindPath(x1, y1, x2, y2);


        }

        SuivreChemin();
    }

    private void SuivreChemin()
    {

        if (chemin != null)
        {

            pathfinding.getGrid().GetWorldXY(new Vector2(chemin[index].x, chemin[index].y), out float x, out float y);
            Vector2 targetPosition = new Vector2(x, y);

            if (Vector2.Distance(transform.position, targetPosition) > 0.0001f)
            {

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
                isMoving = true;
            }
            else
            {
                index++;
                if (index >= chemin.Count)
                {
                    chemin = null;
                    isMoving = false;
                    animatorInvocateur.SetBool("isWalking", false);
                    index = 0;
                    cheminAtteint = true;
                }
            }



        }


    }


    public void flipSprite()
    {

        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if ((angle < 90 && angle >= 0) || (angle > -90 && angle < 0))
        {
            spriterenderer.flipX = false;

        }

        if ((angle > 90 && angle < 180) || (angle > -180 && angle < -90))
        {
            spriterenderer.flipX = true;

        }


    }

    public void BloobMeure()
    {
        nombreBloobPresent -= 1;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {

            isTakingDommage = true;
            EloignerPlayer();

        }
    }
    public void setInvocateur(GameObject idBoss)
    {

        boss = idBoss.GetComponent<InvocateurModifierBoss>();

    }

    private void OnDestroy()
    {
        boss.InvoquateurMeure();
    }
}
