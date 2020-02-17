using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatNode
{
    private NatGrid grid;

    public int x;
    public int y;
    public int Gcost;
    public int Fcost;
    public int Hcost;
    public bool obstacle = false;

    public NatNode cameFromNode;
    public NatNode(NatGrid grid1, int x1, int y1)
    {
        grid = grid1;
        x = x1;
        y = y1;

    }
    public NatNode(int x1, int y1)
    {
        grid = null;
        x = x1;
        y = y1;

    }

    public void CalculerFcost()
    {
        Fcost = Gcost + Hcost;
    }

    public override string ToString()
    {
        return x + " , " + y;
    }
    public void SetObastacle(bool choix)
    {
        obstacle = choix;

    }
}
