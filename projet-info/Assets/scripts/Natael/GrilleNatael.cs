using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrilleNatael
{

    private int largeurMap;
    private int hauteurMap;
    private Vector3 origine;
    private float TileDimension;
    private CasesNatael[,] listeDeNode;
    private GameObject[] obstacle;
    private GameObject[] tour;
    private GameObject[] lave;

    int positionXObs;
    int positionYObs;

    private GameObject[] listeObstacle;
    private GameObject[] listeObstacle2;

    private List<GameObject> colliderList;

    // Permet de savoir si une case dans la map n'est pas accesible
    public GrilleNatael(int width, int height, float TileDimension, Vector3 VecteurOrigine)
    {
        largeurMap = width;
        hauteurMap = height;
        this.TileDimension = TileDimension;
        origine = VecteurOrigine;
        listeDeNode = new CasesNatael[largeurMap, hauteurMap];

        obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
        tour = GameObject.FindGameObjectsWithTag("Tour");
        lave = GameObject.FindGameObjectsWithTag("Lave");

        //Listes des différentes cases que l'intelligence artificielle ne peut traverser à cause d'obstacles
        for (int x = 0; x < listeDeNode.GetLength(0); x++)
        {
            for (int y = 0; y < listeDeNode.GetLength(1); y++)
            {
                listeDeNode[x, y] = new CasesNatael(x, y);


                for (int i = 0; i < obstacle.Length; i++)
                {
                    GetXY(obstacle[i].transform.position, out int x1, out int y1);

                    if (x1 == x && y1 == y)
                    {
                        listeDeNode[x, y].SetObstacle(true);
                    }
                }
                for (int k = 0; k < tour.Length; k++)
                {
                    GetXY(tour[k].transform.position, out int x1, out int y1);

                    if (x1 == x && y1 == y)
                    {
                        listeDeNode[x, y].SetObstacle(true);
                    }
                }
                for (int j = 0; j < lave.Length; j++)
                {
                    GetXY(lave[j].transform.position, out int x1, out int y1);

                    if (x1 == x && y1 == y)
                    {
                        listeDeNode[x, y].SetObstacle(true);
                    }
                }

            }

        }
    }

    public CasesNatael GetGridObject(int x, int y)
    {
        return listeDeNode[x, y];
    }

    // Permet d'avoir la position de l'objet visé dans la map décentré
    public void GetXY(Vector3 position, out int x, out int y)
    {
        x = Mathf.FloorToInt((position.x / TileDimension) - origine.x);
        y = Mathf.FloorToInt((position.y / TileDimension) - origine.y);
    }

    // Permet d'avoir ???
    public void GetWorldXY(Vector3 position, out float x, out float y)
    {
        x = position.x * TileDimension + 4.25f;
        y = position.y * TileDimension + 0.75f;
    }

    // Permet d'avoir ???
    public void SetGrid(Vector3 worldPosition, CasesNatael value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetGrid(x, y, value);
    }

    // Permet d'avoir ???
    public void SetGrid(int x, int y, CasesNatael value)
    {
        if (x >= 0 && y > 0 && x < largeurMap && y < hauteurMap)
        {
            listeDeNode[x, y] = value;
        }
    }

    // Permet d'avoir la position exacte dans la map créé, puisqu'elle n'est pas centré à (0,0)
    public CasesNatael GetGrid(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < largeurMap && y < hauteurMap)
        {
            return listeDeNode[x, y];
        }
        else return default;
    }

    // Permet d'avoir ???
    public CasesNatael GetGrid(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetGrid(x, y);
    }

    // Permet d'avoir la largeur de la map
    public int GetLargueur()
    {
        return largeurMap;
    }

    // Permet d'avoir la hauteur de la map
    public int GetHauteur()
    {
        return hauteurMap;
    }


}
