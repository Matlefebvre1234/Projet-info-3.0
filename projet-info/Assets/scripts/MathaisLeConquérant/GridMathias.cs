using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridMathias
{

    private int largeur;
    private int hauteur;
    private Vector3 origine;
    private float dimCell;
    private Vector3 positionJoueur;
    private positionJoueur posJ = new positionJoueur();
    private CheminMathias[,] listNode;

    public GridMathias(int n_largeur, int n_hauteur, float n_dimCell, Vector3 n_origine, Func<GridMathias, int, int, CheminMathias> createGridObjet)
    {
        
        largeur = n_largeur;
        hauteur = n_hauteur;
        dimCell = n_dimCell;
        origine = n_origine;
        listNode = new CheminMathias[largeur, hauteur];
        Debug.Log(largeur + (" ") +hauteur);


        for (int x = 0; x < listNode.GetLength(0); x++)
        {
            for (int y = 0; y < listNode.GetLength(1); y++)
            {
                listNode[x, y] = createGridObjet(this, x, y);

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

    public void SetGridObject(Vector3 worldPosition, CheminMathias value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetGridObject(x, y, value);
    }
    public void SetGridObject(int x, int y, CheminMathias value)
    {
        if (x >= 0 && y > 0 && x < largeur && y < hauteur)
        {
            listNode[x, y] = value;
        }
    }
    public CheminMathias GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < largeur && y < hauteur)
        {
            return listNode[x, y];
        }
        else return default(CheminMathias);
    }
    public CheminMathias GetGridObject(Vector3 worldPosition)
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
