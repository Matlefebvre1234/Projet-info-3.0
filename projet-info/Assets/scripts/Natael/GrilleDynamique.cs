using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleDynamique : MonoBehaviour
{
    static GrilleNatael grid;
    public int hauteur = 14;
    public int largeur = 22;
    public float dimCell = 0.5f;
    public static Vector3 origine = new Vector3(8, 1);
    // Start is called before the first frame update
    void Start()
    {
        grid = new GrilleNatael(largeur, hauteur, dimCell, origine);
    }

    public GrilleNatael getGrid()
    {
        if (grid == null)
        {
            grid = new GrilleNatael(largeur, hauteur, dimCell, origine);
        }

        return grid;

    }
    public float getDimCell()
    {
        return dimCell;
    }

    public void DestroyGrid()
    {

        grid = null;

    }
}
