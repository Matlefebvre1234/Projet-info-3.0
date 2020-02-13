using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MatGrid
{

    private int largeur;
    private int hauteur;
    private Vector3 origine;
    private float dimCell;
    private Vector3 positionJoueur;
    private positionJoueur posJ = new positionJoueur();
    private MatNode[,] listNode;
 
    private GameObject[] colliderList;

    public MatGrid(int n_largeur, int n_hauteur, float n_dimCell, Vector3 n_origine)
    {
        largeur = n_largeur;
        hauteur = n_hauteur;
        dimCell = n_dimCell;
        origine = n_origine;
        listNode = new MatNode[largeur, hauteur];
    

        
        colliderList = GameObject.FindGameObjectsWithTag("Obstacle");

        for (int x1 = 0; x1 < listNode.GetLength(0); x1++)
        {
            for (int y2 = 0; y2 < listNode.GetLength(1); y2++)
            {

                listNode[x1, y2] = new MatNode(x1, y2);
                
               for(int i =0;i<colliderList.Length;i++)
                {
                    GetXY(colliderList[i].transform.position, out int x, out int y);
                    if(x1 == x & y2 == y)
                    {
                        listNode[x, y].obstacle = true;

                    }

                }
                

            }

        }

        for (int x = 0; x < largeur; x++)
        {
            for (int y = 0; y < hauteur; y++)
            {
                Debug.DrawLine(Position(x, y), Position(x + 1, y), Color.white, 100f);
                Debug.DrawLine(Position(x, y), Position(x, y + 1), Color.white, 100f);

            }

        }
        Debug.DrawLine(Position(0, hauteur), Position(largeur, hauteur), Color.white, 100f);
        Debug.DrawLine(Position(largeur, 0), Position(largeur, hauteur), Color.white, 100f);
    }

    private Vector3 Position(int x, int y)
    {
        return new Vector3(x + origine.x, y + origine.y) * dimCell;
    }

    public void GetXY(Vector3 position, out int x, out int y)
    {
        x = Mathf.FloorToInt((position.x / dimCell) - origine.x);
        y = Mathf.FloorToInt((position.y / dimCell) - origine.y);
    }
    public void GetWorldXY(Vector3 position, out int x, out int y)
    {
        x = Mathf.FloorToInt((position.x * dimCell) + origine.x);
        y = Mathf.FloorToInt((position.y * dimCell) + origine.y);
    }

    //  public void setPosJ(Vector3 posJ)
    // {
    //     positionJoueur = posJ;
    // }

    // public Vector3 getPosJ()
    // {
    //     return positionJoueur;
    //}

    public void SetGridObject(Vector3 worldPosition, MatNode value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetGridObject(x, y, value);
    }
    public void SetGridObject(int x, int y, MatNode value)
    {
        if (x >= 0 && y > 0 && x < largeur && y < hauteur)
        {
            listNode[x, y] = value;
        }
    }
    public MatNode GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < largeur && y < hauteur)
        {
            return listNode[x, y];
        }
        else return default(MatNode);
    }
    public MatNode GetGridObject(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetGridObject(x, y);
    }
    public void ValeurArrondie(Vector3 pos)
    {
        int x, y;
        GetXY(pos, out x, out y);

        Debug.Log("(" + x + ", " + y + ")");
    }

    public int GetLargueur()
    {
        return largeur;
    }
    public int GetHauteur()
    {
        return hauteur;
    }


}
