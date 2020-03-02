using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleMonstresMat : MonoBehaviour
{
    MatGrid grid;
    public int hauteur = 14;
    public int largeur = 22;
    public static float dimCell = 0.5f;
    public Vector3 origine = new Vector3(8, 1);
    // Start is called before the first frame update
    void Start()
    {
        grid = new MatGrid(largeur, hauteur, dimCell, origine);

    }

    
    public MatGrid getGrid()
    {
        return grid;

    }
    public static float getdimCell()
    {
        return dimCell;
    }
}
