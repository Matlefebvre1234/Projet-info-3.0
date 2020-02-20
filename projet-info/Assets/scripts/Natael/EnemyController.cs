﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hauteur = 14;
    public int largeur = 22;
    public int rangeIAMax = 3;
    public int rangeIAMin = -3;
    public int rangeAttaquePlayer = 4;
    public int rangeMouvement = 5;

    public float raycastMaxDistance = 10f;
    public float speed = 0.02f;

    public Animator animator;

    public GameObject barricade;
    public GameObject Mine;
    public GameObject explosion;

    private NatPathfinding pathfinding;
    private NatGrid grid;
    private Vector3 origine = new Vector3(8, 1);
    private List<NatNode> path;

    private float elapseTime = 0;

    private int node = 0;
    private int randomTime = 0;
    private int randomx;
    private int randomy;
    private int conteur = 0;

    private bool bougerConstruit = false;
    private bool pathIsEnd = false;
    private bool obstacle = false;

    GameObject player;

    void Start()
    {
        pathfinding = new NatPathfinding(largeur, hauteur);
        //grid = new NatGrid(largeur, hauteur, 0.5f, origine);
        //grid.GetXY(transform.position, out int x, out int y);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.gameObject.tag == "Barricade" || collision.gameObject.tag == "Mine")
        {
            Debug.Log("obstacle");
            obstacle = true;
        }
        else
        {
            obstacle = false;
        }
    }

    void Update()
    {
        if (pathIsEnd == false)
        {
            if (elapseTime == randomTime && animator.GetBool("collision_Joueur") == false)
            {
                bougerRadom();
            }

            elapseTime += 1 * Time.deltaTime;

            if (bougerConstruit == true)
            {
                suivrePath();
            }
        }
        else
        {
            if (conteur < 300)
            {
                conteur++;
                return;
            }
            else
            {
                pathIsEnd = false;
                conteur = 0;
            }
        }

        //if (pathIsEnd == true)
        //{
        //    if (elapseTime == randomTime && animator.GetBool("collision_Joueur") == false)
        //    {
        //        bougerRadom();
        //    }
        //
        //    elapseTime += 1 * Time.deltaTime;
        //    
        //    pathIsEnd = false;
        //}
        //
        //if (bougerConstruit == true)
        //{
        //    suivrePath();
        //}



        float rangeAttaque = Vector2.Distance(transform.position, player.transform.position);
        if (rangeAttaque < 1 && animator.GetBool("collision_Joueur") == false)
        {
            //Explosion du bonhomme
            animator.SetBool("collision_Joueur", true);
            player.GetComponent<Santé>().attaque(15);
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Explosion_Joueur"))
        {
            animator.SetBool("collision_Joueur", false);
            transform.gameObject.SetActive(false);
        }
    }

    public void bougerRadom()
    {
            pathfinding.getGrid().GetXY(transform.position, out int x, out int y);

            do
            {
                randomx = Random.Range(rangeIAMin, rangeIAMax);
                randomy = Random.Range(rangeIAMin, rangeIAMax);

                while ((x + randomx) >= largeur || (x + randomx) < 0)
                {
                    randomx = Random.Range(rangeIAMin, rangeIAMax);
                }
                while ((y + randomy) >= hauteur || (y + randomy) < 0)
                {
                    randomy = Random.Range(rangeIAMin, rangeIAMax);
                }

                path = pathfinding.FindPath(x, y, x + randomx, y + randomy);

            } while (path == null);

            bougerConstruit = true;
    }

    public void suivrePath()
    {
        if (path != null)
        {
            pathfinding.getGrid().GetWorldXY(new Vector2(path[node].x, path[node].y), out float z, out float w);
            Vector2 targetPosition = new Vector2(z, w);

            if (Vector2.Distance(transform.position, targetPosition) > 0.0001f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
            }
            else
            {
                node++;
                if (node >= path.Count)
                {
                    node = 0;
                    path = null;
                    elapseTime = 0;
                    pathIsEnd = true;
                    bougerConstruit = false;
                    int x = Random.Range(0,10);
                    if (x < 3 || x > 7)
                    {
                        if (x == 0)
                        {
                            Instantiate(Mine, transform.position, Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(barricade, transform.position, Quaternion.identity);
                        }
                    }
                }
            }
        }
    }
}