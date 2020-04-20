using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDemon : MonoBehaviour
{
    public int hauteur;
    public int largeur;
    public float dimentions = 0.5f;
    public static Vector3 origine = new Vector3(8, 1);
    static Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(largeur, hauteur);
    }

    public Grid getGrid()
    {
        if (grid == null)
        {
            grid = new Grid(hauteur, largeur);
        }

        return grid;
    }
}
