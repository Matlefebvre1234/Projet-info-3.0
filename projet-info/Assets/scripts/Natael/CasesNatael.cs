using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasesNatael
{
    private GrilleNatael grid;

    public int x;
    public int y;
    public int Gcost;
    public int Fcost;
    public int Hcost;
    public bool obstacle = false;

    public CasesNatael NodePrecedente;

    public CasesNatael(GrilleNatael grid1, int x1, int y1)
    {
        grid = grid1;
        x = x1;
        y = y1;

    }
    public CasesNatael(int x1, int y1)
    {
        grid = null;
        x = x1;
        y = y1;

    }

    public void CalculerFcost()
    {
        Fcost = Gcost + Hcost;
    }

    public void SetObastacle(bool choix)
    {
        obstacle = choix;
    }
}
