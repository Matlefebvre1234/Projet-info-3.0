using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheminMathias
{
    private GridMathias grille;
    public int x;
    public int y;

    public int g;
    public int h;
    public int f;

    public CheminMathias casePrecedente;

    public CheminMathias(GridMathias n_grille, int n_x, int n_y)
    {
        grille = n_grille;
        x = n_x;
        y = n_y;
    }

    public CheminMathias(int n_x, int n_y)
    {
        grille = null;
        x = n_x;
        y = n_y;
    }

    public override string ToString()
    {
        return x + ", " + y;
    }

    public void CalculerF()
    {
        f = g + h;
    }
}
