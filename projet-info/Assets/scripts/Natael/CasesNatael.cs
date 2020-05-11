using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CasesNatael : MonoBehaviour
{
    private GrilleNatael grid;

    public int x;
    public int y;
    public int Gcost;
    public int Fcost;
    public int Hcost;
    public bool obstacle;

    public CasesNatael casePrecedente;

    public CasesNatael(GrilleNatael grid1, int x1, int y1)
    {
        grid = grid1;
        x = x1;
        y = y1;
        obstacle = false;
    }
    public CasesNatael(int x1, int y1)
    {
        grid = null;
        x = x1;
        y = y1;
        obstacle = false;
    }

    //Setter pour la position en x de la case
    public void SetX(int x)
    {
        this.x = x;
    }

    //Setter pour la position en y de la case
    public void SetY(int y)
    {
        this.y = y;
    }

    public void CalculerFcost()
    {
        Fcost = Gcost + Hcost;
    }

    public void SetObstacle(bool obs)
    {
        obstacle = obs;
    }

    public bool GetObstacle()
    {
        return obstacle;
    }
}
