﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementAiMathias : MonoBehaviour
{

    private PathfindingMathias pathfinding;
    private int x;
    private int y;

    public int largeur = 22;
    public int hauteur = 14;
    public float vitesse = 0.01f;

    private float distanceMaxParcourue;

    private GameObject joueur;
    private GameObject ennemi;

    private Vector3 positionJoueur = new Vector3();

    private float tempsProchaineAction = 0.0f;
    public float periode = 0.1f;

    private List<CheminMathias> chemin;

    private int index = 1;

    private int posX;
    private int posY;

    private float x1;
    private float y1;

    private int xE;
    private int yE;

    private float dimCell = 0.5f;

    private GridMathias grille;

    private Vector3 origine = new Vector3(8, 1);

    private bool fin = false;

    private Animator anim;
   

    // Start is called before the first frame update
    void Start()
    {
        
        pathfinding = new PathfindingMathias(largeur, hauteur);
        joueur = new GameObject();
        joueur = GameObject.FindGameObjectWithTag("Player");
        ennemi = new GameObject();
        ennemi = GameObject.FindGameObjectWithTag("Orc");
        positionJoueur = joueur.transform.position;

        grille = new GridMathias(largeur, hauteur, dimCell, origine);
        index = 1;
        anim = GetComponent<Animator>();
        anim.SetFloat("Vitesse", 1);
    }

    void Update()
    {
        grille.GetXY(ennemi.transform.position, out xE, out yE);
        grille.GetXY(positionJoueur, out posX, out posY);
        positionJoueur = joueur.transform.position;
        pathfinding.GetGrid().GetXY(positionJoueur, out x, out y);
        distanceMaxParcourue = vitesse * Time.deltaTime;

        chemin = pathfinding.Chemin(xE, yE, posX, posY);
            if (fin == false)
            {
                tempsProchaineAction += periode;
                Mouvement();
            }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (Time.time > tempsProchaineAction)
        {
            tempsProchaineAction += periode;
            joueur.transform.GetComponent<Santé>().attaque(5);
        }
    }

    private void Mouvement()
    {

        if (chemin != null)
        {
            Debug.Log(index);
            Vector2 ajout = new Vector2(chemin[index].x, chemin[index].y);
            pathfinding.GetGrid().GetWorldXY(ajout, out x1, out y1);
            Vector2 destination = new Vector2(x1, y1);

            if(Vector2.Distance(ennemi.transform.position, destination) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, destination, 0.01f);
            }

            else
            {
                index++;

                if(index >= chemin.Count)
                {
                    Debug.Log("allo");
                    index = 0;
                    fin = true;
                    chemin = null;
                }
            }
        }

    }

}
