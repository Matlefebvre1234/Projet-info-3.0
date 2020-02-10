using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    private Grid<Node> grid;
    public int x;
    public int y;

    public int Gcost;
    public int Fcost;
    public int Hcost;

    public Node cameFromNode;
    public Node(Grid<Node> grid1,int x1,int y1)
    {
        grid = grid1;
        x = x1;
        y = y1;

    }

    public void  CalculerFcost()
    {
        Fcost = Gcost + Hcost;
    }

    public override string ToString()
    {
        return  x + " , " + y;
    }
}
