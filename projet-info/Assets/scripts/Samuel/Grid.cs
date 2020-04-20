using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grid : MonoBehaviour
{

    public int largeur;
    public int hauteur;
    private Vector3 origine = new Vector3(8,1);
    public float dimCell = 0.5f;
    private SamNode[,] listNode;
    private GameObject[] obstacle;
    private GameObject[] tour;
    private GameObject[] lave;
    
    public Grid(int m_hauteur, int m_largeur)
    {
        obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
        tour = GameObject.FindGameObjectsWithTag("Tour");
        lave = GameObject.FindGameObjectsWithTag("Lave");
        largeur = m_largeur;
        hauteur = m_hauteur;

        listNode = new SamNode[largeur, hauteur];

        for (int x = 0; x < listNode.GetLength(0); x++)
        {
            for (int y = 0; y < listNode.GetLength(1); y++)
            {
                listNode[x, y] = new SamNode(x, y);

                
                for(int i = 0; i < obstacle.Length; i++)
                {
                    GetXY(obstacle[i].transform.position, out int x1, out int y1);

                    if(x1 == x && y1 == y)
                    {
                        listNode[x, y].SetObstacle(true);
                    }
                }
                for (int k = 0; k < tour.Length; k++)
                {
                    GetXY(tour[k].transform.position, out int x1, out int y1);

                    if (x1 == x && y1 == y)
                    {
                        listNode[x, y].SetObstacle(true);
                    }
                }
                for (int j = 0; j < lave.Length; j++)
                {
                    GetXY(lave[j].transform.position, out int x1, out int y1);

                    if (x1 == x && y1 == y)
                    {
                        listNode[x, y].SetObstacle(true);
                    }
                }

            }

        }

        for (int x = 0; x < largeur; x++)
        {
            for (int y = 0; y < hauteur; y++)
            {
                //Debug.DrawLine(Position(x, y), Position(x + 1, y), Color.white, 100f);
                //Debug.DrawLine(Position(x, y), Position(x, y + 1), Color.white, 100f);

            }

        }
        //Debug.DrawLine(Position(0, hauteur), Position(largeur, hauteur), Color.white, 100f);
        //Debug.DrawLine(Position(largeur, 0), Position(largeur, hauteur), Color.white, 100f);
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

    public void GetPositionMapXY(Vector3 position, out float x, out float y)
    {
        x = position.x * dimCell + 4.25f;
        y = position.y * dimCell + 0.75f;
    }

    public Vector3 GetVector(Vector3 position)
    {
        int x = Mathf.FloorToInt((position.x / dimCell) - origine.x);
        int y = Mathf.FloorToInt((position.y / dimCell) - origine.y);
        Vector3 positionCase = new Vector3(x, y);
        return positionCase;
    }

    public void SetGridObject(Vector3 worldPosition, SamNode value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetGridObject(x, y, value);
    }
    public void SetGridObject(int x, int y, SamNode value)
    {
        if (x >= 0 && y > 0 && x < largeur && y < hauteur)
        {
            listNode[x, y] = value;
        }
    }
    public SamNode GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < largeur && y < hauteur)
        {
            return listNode[x, y];
        }
        else return default(SamNode);
    }
    public SamNode GetGridObject(Vector3 worldPosition)
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
