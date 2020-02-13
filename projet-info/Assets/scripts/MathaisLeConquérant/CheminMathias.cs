using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheminMathias : MonoBehaviour
{
    private Grid<CheminMathias> grille;
    private int x;
    private int y;

    public int g;
    public int h;
    public int f;

    public CheminMathias casePrecedente;

    public CheminMathias(Grid<CheminMathias> n_grille, int n_x, int n_y)
    {
        grille = n_grille;
        x = n_x;
        y = n_y;
    }

    public override string ToString()
    {
        return x + ", " + y;
    }
}
