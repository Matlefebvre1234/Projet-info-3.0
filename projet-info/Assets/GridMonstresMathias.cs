using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMonstresMathias : MonoBehaviour
{
    public int hauteur = 14;
    public int largeur = 22;
    public float dimentions = 0.5f;
    public static Vector3 origine = new Vector3(8, 1);
    static GridMathias grille;

    // Start is called before the first frame update
    void Start()
    {
        grille = new GridMathias(largeur, hauteur, dimentions, origine);
    }

    public GridMathias getGrid()
    {
        if (grille == null) grille = new GridMathias(largeur, hauteur, dimentions, origine);

        return grille;
    }
    public float getdimCell()
    {
        return dimentions;
    }
    public void DestroyGrid()
    {
        grille = null;
    }
}
