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
    private PointsNatael[,] litseDeNode;

    private GameObject[] listeObstacle;

    // Permet de savoir si une case dans la map n'est pas accesible
    public GrilleNatael(int width, int height, float TileDimension, Vector3 VecteurOrigine)
    {
        largeurMap = width;
        hauteurMap = height;
        this.TileDimension = TileDimension;
        origine = VecteurOrigine;
        litseDeNode = new PointsNatael[largeurMap, hauteurMap];


        listeObstacle = GameObject.FindGameObjectsWithTag("Obstacle");

        for (int w = 0; w < litseDeNode.GetLength(0); w++)
        {
            for (int e = 0; e < litseDeNode.GetLength(1); e++)
            {

                litseDeNode[w, e] = new PointsNatael(w, e);

                for (int i = 0; i < listeObstacle.Length; i++)
                {
                    GetXY(listeObstacle[i].transform.position, out int x, out int y);
                    if (w == x & e == y)
                    {
                        litseDeNode[x, y].obstacle = true;

                    }
                }
            }
        }
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
    public void SetGrid(Vector3 worldPosition, PointsNatael value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetGrid(x, y, value);
    }

    // Permet d'avoir ???
    public void SetGrid(int x, int y, PointsNatael value)
    {
        if (x >= 0 && y > 0 && x < largeurMap && y < hauteurMap)
        {
            litseDeNode[x, y] = value;
        }
    }

    // Permet d'avoir la position exacte dans la map créé, puisqu'elle n'est pas centré à (0,0)
    public PointsNatael GetGrid(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < largeurMap && y < hauteurMap)
        {
            return litseDeNode[x, y];
        }
        else return default;
    }

    // Permet d'avoir ???
    public PointsNatael GetGrid(Vector3 worldPosition)
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
