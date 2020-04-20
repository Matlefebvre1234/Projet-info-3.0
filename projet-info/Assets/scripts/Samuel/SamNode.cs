using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represente une case dans la grille
public class SamNode
{
    private GridDemon grid;
    public int x;
    public int y;

    //Pour le calcul du A*
    public int gCost;
    public int hCost;
    public int fCost;

    public SamNode derniereCase;

    public bool obstacle;

    public SamNode(GridDemon m_grid, int m_x, int m_y)
    {
        grid = m_grid;
        x = m_x;
        y = m_y;
        obstacle = false;
    }
    public SamNode(int m_x, int m_y)
    {
        
        x = m_x;
        y = m_y;
        obstacle = false;
    }

    public void calculFCost()
    {
        fCost = gCost + hCost;
    }

    public override string ToString()
    {
        return x + "," + y;
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
